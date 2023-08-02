using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis
{
    public class ServicoGrupoAutomoveis
    {
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        private IValidadorGrupoAutomoveis validadorGrupoAutomoveis;
        public ServicoGrupoAutomoveis(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis, IValidadorGrupoAutomoveis validadorGrupoAutomoveis)
        {
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.validadorGrupoAutomoveis = validadorGrupoAutomoveis;
        }

        private List<string> ValidarGrupoAutomoveis(GrupoAutomoveis grupoAutomoveis)
        {
            var resultadoValidacao = validadorGrupoAutomoveis.Validate(grupoAutomoveis);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(grupoAutomoveis))
                erros.Add($"Este tipo '{grupoAutomoveis.Tipo}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(GrupoAutomoveis grupoAutomoveis)
        {
            GrupoAutomoveis disciplinaEncontrada = repositorioGrupoAutomoveis.SelecionarPorNome(grupoAutomoveis.Tipo);

            if (disciplinaEncontrada != null &&
                disciplinaEncontrada.Id != grupoAutomoveis.Id &&
                disciplinaEncontrada.Tipo == grupoAutomoveis.Tipo)
            {
                return true;
            }

            return false;
        }
        public Result Inserir(GrupoAutomoveis grupoAutomoveis)
        {
            Log.Debug("Tentando inserir grupo de automóveis...{@d}", grupoAutomoveis);

            List<string> erros = ValidarGrupoAutomoveis(grupoAutomoveis);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

                Log.Debug("Grupo de Automóveis {GrupoAutomoveisId} inserida com sucesso", grupoAutomoveis.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Grupo de Automóveis.";

                Log.Error(exc, msgErro + "{@d}", grupoAutomoveis);

                return Result.Fail(msgErro); //cenário 3
            }
        }
        public Result Editar(GrupoAutomoveis grupoAutomoveis)
        {
            Log.Debug("Tentando editar Grupo de Automoveis...{@d}", grupoAutomoveis);

            List<string> erros = ValidarGrupoAutomoveis(grupoAutomoveis);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomoveis.Editar(grupoAutomoveis);

                Log.Debug("Grupo de Automoveis {GrupoAutomoveisId} editada com sucesso", grupoAutomoveis.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Grupo de Automoveis.";

                Log.Error(exc, msgErro + "{@d}", grupoAutomoveis);

                return Result.Fail(msgErro);
            }
        }
    }
}
