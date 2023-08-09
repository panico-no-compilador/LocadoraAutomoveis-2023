using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca
{
    public class ServicoPlanoCobranca
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        IValidadorPlanoCobranca validadorPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IValidadorPlanoCobranca validadorPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlanoCobranca = validadorPlanoCobranca;
        }
        public Result Inserir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando inserir um plano de cobrança...{@m}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);

                Log.Debug("O Plano de Cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir um plano de cobrança.";

                Log.Error(exc, msgErro + "{@m}", planoCobranca);

                return Result.Fail(msgErro);
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
        public Result Editar(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando editar plano de cobrança...{@m}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioPlanoCobranca.Editar(planoCobranca);

                Log.Debug("Plano de Cobrança {PlanoCobrancaId} editada com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar plano de cobrança.";

                Log.Error(exc, msgErro + "{@m}", planoCobranca);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando excluir plano de cobrança...{@m}", planoCobranca);

            try
            {
                repositorioPlanoCobranca.Excluir(planoCobranca);

                Log.Debug("Plano de Cobrança {PlanoCobrancaId} editada com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);

                erros.Add(msgErro);

                Log.Logger.Error(ex, msgErro + " {PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(erros);
            }
        }
        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            if (ex.Message.Contains("FK_TBAutomoveis_Aluguel"))
                msgErro = "Este plano de cobrança está relacionada com um aluguel e não pode ser excluída";
            else
                msgErro = "Este plano de cobrança não pode ser excluído";

            return msgErro;
        }
    }
}
