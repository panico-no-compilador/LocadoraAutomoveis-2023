using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;

namespace LocadoraAutomoveis.Aplicacao.ModuloConfiguracaoPrecos
{
    public class ServicoConfiguracaoPrecos
    {
        IRepositorioConfiguracaoPrecos repositorioConfiguracaoPrecos;
        ValidadorConfiguracaoPrecos validadorConfiguracaoPrecos;

        public ServicoConfiguracaoPrecos(
            IRepositorioConfiguracaoPrecos repositorioConfiguracaoPrecos, 
            ValidadorConfiguracaoPrecos validadorConfiguracaoPrecos
            )
        {
            this.repositorioConfiguracaoPrecos = repositorioConfiguracaoPrecos;
            this.validadorConfiguracaoPrecos = validadorConfiguracaoPrecos;
        }
        public Result ConfigurarPrecoCombustiveis(Combustivel combustivel)
        {
            Log.Debug("Tentando configurar preço de combustivel...{@m}", combustivel);

            List<string> erros = ValidarPrecoCombustivel(combustivel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioConfiguracaoPrecos.ConfigurarPrecoCombustiveis(combustivel);

                Log.Debug("Preço de combustivel {CombustivelId} inserida com sucesso", combustivel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Preço de combustivel.";

                Log.Error(exc, msgErro + "{@m}", combustivel);

                return Result.Fail(msgErro);
            }
        }
        public Result Inserir(Combustivel combustivel)
        {
            Log.Debug("Tentando inserir preço de combustivel...{@m}", combustivel);

            List<string> erros = ValidarPrecoCombustivel(combustivel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioConfiguracaoPrecos.Inserir(combustivel);

                Log.Debug("Preço de combustivel {CombustivelId} inserida com sucesso", combustivel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Preço de combustivel.";

                Log.Error(exc, msgErro + "{@m}", combustivel);

                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Combustivel combustivel)
        {
            Log.Debug("Tentando editar combustivel...{@m}", combustivel);

            List<string> erros = ValidarPrecoCombustivel(combustivel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioConfiguracaoPrecos.Editar(combustivel);

                Log.Debug("Combustivel {CombustivelId} editado com sucesso", combustivel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar matéria.";

                Log.Error(exc, msgErro + "{@m}", combustivel);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Combustivel combustivel)
        {
            Log.Debug("Tentando excluir Combustivel...{@m}", combustivel);

            try
            {
                repositorioConfiguracaoPrecos.Excluir(combustivel);

                Log.Debug("Combustivel {CombustivelId} editado com sucesso", combustivel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);

                erros.Add(msgErro);

                Log.Logger.Error(ex, msgErro + " {MateriaId}", combustivel.Id);

                return Result.Fail(erros);
            }
        }
        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            if (ex.Message.Contains("FK_TBCombustivel"))
                msgErro = "Esta combustivel está relacionada com um... e não pode ser excluída";
            else
                msgErro = "Este combustivel não pode ser excluído";

            return msgErro;
        }
        private List<string> ValidarPrecoCombustivel(Combustivel combustivel)
        {
            List<string> erros = validadorConfiguracaoPrecos.Validate(combustivel)
                .Errors.Select(x => x.ErrorMessage).ToList();

            if (NomeDuplicado(combustivel))
                erros.Add($"Este '{combustivel.ToString()}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Combustivel combustivel)
        {
            Combustivel combustivelEncontrado = repositorioConfiguracaoPrecos.SelecionarPorCombustivel(combustivel);

            if (combustivelEncontrado != null &&
                combustivelEncontrado.Id != combustivel.Id &&
                combustivelEncontrado.PrecoGasolina == combustivel.PrecoGasolina &&
                combustivelEncontrado.PrecoGas == combustivel.PrecoGas &&
                combustivelEncontrado.PrecoEtanol == combustivel.PrecoEtanol &&
                combustivelEncontrado.PrecoDiesel == combustivel.PrecoDiesel
            )
            {
                return true;
            }

            return false;
        }
    }
}
