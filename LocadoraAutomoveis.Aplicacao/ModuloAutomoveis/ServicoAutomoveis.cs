using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System.Drawing.Drawing2D;

namespace LocadoraAutomoveis.Aplicacao.ModuloAutomoveis
{
    public class ServicoAutomoveis
    {
        IRepositorioAutomoveis repositorioAutomoveis;
        IValidadorAutomoveis validadorAutomoveis;

        public ServicoAutomoveis(
            IRepositorioAutomoveis repositorioAutomoveis,
            IValidadorAutomoveis validadorAutomoveis)
        {
            this.repositorioAutomoveis = repositorioAutomoveis;
            this.validadorAutomoveis = validadorAutomoveis;
        }
        public Result Inserir(Automovel automovel)
        {
            Log.Debug("Tentando inserir o automovel...{@m}", automovel);

            List<string> erros = ValidarAutomoveis(automovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAutomoveis.Inserir(automovel);

                Log.Debug("Automovel {AutomovelId} inserida com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir o automovel.";

                Log.Error(exc, msgErro + "{@m}", automovel);

                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Automovel automovel)
        {
            Log.Debug("Tentando editar automovel...{@m}", automovel);

            List<string> erros = ValidarAutomoveis(automovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAutomoveis.Editar(automovel);

                Log.Debug("Automovel {AutomovelId} editada com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar automovel.";

                Log.Error(exc, msgErro + "{@m}", automovel);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Automovel automovel)
        {
            Log.Debug("Tentando excluir automovel...{@m}", automovel);

            try
            {
                repositorioAutomoveis.Excluir(automovel);

                Log.Debug("Automovel {AutomovelId} editada com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);

                erros.Add(msgErro);

                Log.Logger.Error(ex, msgErro + " {AutomovelId}", automovel.Id);

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
                msgErro = "Este automovel não pode ser excluída";

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
