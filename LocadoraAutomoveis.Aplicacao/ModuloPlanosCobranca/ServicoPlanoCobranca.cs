using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca
{
    public class ServicoPlanoCobranca
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        IValidadorPlanoCobranca validadorPlanoCobranca;
        IContextoPersistencia contextoPersistencia;

        public ServicoPlanoCobranca(
            IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IValidadorPlanoCobranca validadorPlanoCobranca,
            IContextoPersistencia contextoPersistencia
            )
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlanoCobranca = validadorPlanoCobranca;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando inserir um plano de cobrança...{@p}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);

                contextoPersistencia.GravarDados();

                Log.Debug("O Plano de Cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir um plano de cobrança.";

                Log.Error(exc, msgErro + "{@p}", planoCobranca);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando editar plano de cobrança...{@p}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioPlanoCobranca.Editar(planoCobranca);

                contextoPersistencia.GravarDados();

                Log.Debug("Plano de Cobrança {PlanoCobrancaId} editada com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar plano de cobrança.";

                Log.Error(exc, msgErro + "{@p}", planoCobranca);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando excluir plano de cobrança...{@p}", planoCobranca);

            try
            {
                repositorioPlanoCobranca.Excluir(planoCobranca);

                contextoPersistencia.GravarDados();

                Log.Debug("Plano de Cobrança {PlanoCobrancaId} editada com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);

                erros.Add(msgErro);

                Log.Logger.Error(ex, msgErro + " {PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = validadorPlanoCobranca.Validate(planoCobranca);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (PlanoDuplicado(planoCobranca))
                erros.Add($"O grupo '{planoCobranca.CategoriaGrupAuto}' já está usando o plano '{planoCobranca.TipoPlano}'");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool PlanoDuplicado(PlanoCobranca planoCobranca)
        {
            PlanoCobranca planoCobrancaEncontrado =
                repositorioPlanoCobranca.SelecionarPorNome(planoCobranca.TipoPlano);

            if (planoCobrancaEncontrado != null &&
                planoCobrancaEncontrado.Id != planoCobranca.Id &&
                planoCobrancaEncontrado.CategoriaGrupAuto == planoCobranca.CategoriaGrupAuto &&
                planoCobrancaEncontrado.TipoPlano == planoCobranca.TipoPlano)
            {
                return true;
            }

            return false;
        }

        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            if (ex.Message.Contains("FK_TBPlanoCobranca_GrupoAutomovel"))
                msgErro = "Este plano de cobrança está relacionada com um grupo automovel e não pode ser excluída";
            else
                msgErro = "Este plano de cobrança não pode ser excluído";

            return msgErro;
        }
    }
}
