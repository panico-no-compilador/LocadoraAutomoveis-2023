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
            GrupoAutomoveis GrupoAutomoveisEncontrada = repositorioGrupoAutomoveis.SelecionarPorNome(grupoAutomoveis.Tipo);

            if (GrupoAutomoveisEncontrada != null &&
                GrupoAutomoveisEncontrada.Id != grupoAutomoveis.Id &&
                GrupoAutomoveisEncontrada.Tipo == grupoAutomoveis.Tipo)
            {
                return true;
            }

            return false;
        }
        public Result Excluir(GrupoAutomoveis grupoAutomoveis)
        {
            Log.Debug("Tentando excluir GrupoAutomoveis...{@d}", grupoAutomoveis);

            try
            {
                bool GrupoAutomoveisExiste = repositorioGrupoAutomoveis.Existe(grupoAutomoveis);

                if (GrupoAutomoveisExiste == false)
                {
                    Log.Warning("GrupoAutomoveis {GrupoAutomoveisId} não encontrada para excluir", grupoAutomoveis.Id);

                    return Result.Fail("GrupoAutomoveis não encontrada");
                }

                repositorioGrupoAutomoveis.Excluir(grupoAutomoveis);

                Log.Debug("GrupoAutomoveis {GrupoAutomoveisId} excluída com sucesso", grupoAutomoveis.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBMateria_TBGrupoAutomoveis"))
                    msgErro = "Esta GrupoAutomoveis está relacionada com uma matéria e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir GrupoAutomoveis";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {GrupoAutomoveisId}", grupoAutomoveis.Id);

                return Result.Fail(erros);
            }
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
    }
}
