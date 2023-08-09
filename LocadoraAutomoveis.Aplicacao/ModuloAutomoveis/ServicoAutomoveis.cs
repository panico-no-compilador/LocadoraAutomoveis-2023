using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;

namespace LocadoraAutomoveis.Aplicacao.ModuloAutomoveis
{
    public class ServicoAutomoveis
    {
        IRepositorioAutomoveis repositorioAutomoveis;
        IValidadorAutomoveis validadorAutomoveis;
        IContextoPersistencia contextoPersistencia;
        public ServicoAutomoveis(
            IRepositorioAutomoveis repositorioAutomoveis,
            IValidadorAutomoveis validadorAutomoveis,
            IContextoPersistencia contextoPersistencia
            )
        {
            this.repositorioAutomoveis = repositorioAutomoveis;
            this.validadorAutomoveis = validadorAutomoveis;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Automovel automovel)
        {
            Log.Debug("Tentando inserir um automóvel...{@m}", automovel);

            List<string> erros = ValidarAutomoveis(automovel);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioAutomoveis.Inserir(automovel);

                contextoPersistencia.GravarDados();

                Log.Debug("Automóvel {AutomovelId} inserido com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir um automóvel.";

                Log.Error(exc, msgErro + "{@a}", automovel);

                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Automovel automovel)
        {
            Log.Debug("Tentando editar automovel...{@a}", automovel);

            List<string> erros = ValidarAutomoveis(automovel);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();
                
                return Result.Fail(erros);
            }

            try
            {
                repositorioAutomoveis.Editar(automovel);

                contextoPersistencia.GravarDados();

                Log.Debug("Automóvel {AutomovelId} editado com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar um automóvel.";

                Log.Error(exc, msgErro + "{@a}", automovel);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Automovel automovel)
        {
            Log.Debug("Tentando excluir automóvel...{@a}", automovel);

            try
            {
                bool automovelExiste = repositorioAutomoveis.Existe(automovel);
                if (automovelExiste)
                {
                    Log.Warning("Automóvel {AutomovelId} não encontrado para excluir", automovel.Id);

                    return Result.Fail("Automóvel não encontrado");
                }
                repositorioAutomoveis.Excluir(automovel);

                contextoPersistencia.GravarDados();

                Log.Debug("Automovel {AutomovelId} excluido com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {AutomovelId}", automovel.Id);

                return Result.Fail(erros);
            }
        }
        private List<string> ValidarAutomoveis(Automovel automoveis)
        {
            var resultadoValidacao = validadorAutomoveis.Validate(automoveis);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (PlacaDuplicada(automoveis))
                erros.Add($"Esta placa '{automoveis.Placa}' já está sendo utilizada em outro veiculo");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            if (ex.Message.Contains("FK_TBAutomoveis_Aluguel"))
                msgErro = "Este automovel está relacionada com um aluguel e não pode ser excluída";
            else
                msgErro = "Este automóvel não pode ser excluído";

            return msgErro;
        }
        private bool PlacaDuplicada(Automovel grupoAutomoveis)
        {
            Automovel GrupoAutomoveisEncontrada = repositorioAutomoveis.SelecionarPorPlaca(grupoAutomoveis.Placa);

            if (GrupoAutomoveisEncontrada != null &&
                GrupoAutomoveisEncontrada.Id != grupoAutomoveis.Id &&
                GrupoAutomoveisEncontrada.Placa == grupoAutomoveis.Placa)
            {
                return true;
            }

            return false;
        }
    }
}
