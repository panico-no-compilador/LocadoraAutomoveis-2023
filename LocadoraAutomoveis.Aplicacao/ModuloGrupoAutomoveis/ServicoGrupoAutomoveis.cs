using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis
{
    public class ServicoGrupoAutomoveis
    {
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        private IValidadorGrupoAutomoveis validadorGrupoAutomoveis;
        private IContextoPersistencia contextoPersistencia;

        public ServicoGrupoAutomoveis(
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            IValidadorGrupoAutomoveis validadorGrupoAutomoveis,
            IContextoPersistencia contextoPersistencia
            )
        {
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.validadorGrupoAutomoveis = validadorGrupoAutomoveis;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(GrupoAutomovel grupoAutomoveis)
        {
            Log.Debug("Tentando inserir grupo de automóveis...{@g}", grupoAutomoveis);

            List<string> erros = ValidarGrupoAutomoveis(grupoAutomoveis);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros); //cenário 2
            }

            try
            {
                repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);
                
                contextoPersistencia.GravarDados();
                
                Log.Debug("Grupo de Automóveis {GrupoAutomoveisId} inserida com sucesso", grupoAutomoveis.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Grupo de Automóveis.";

                Log.Error(exc, msgErro + "{@g}", grupoAutomoveis);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(GrupoAutomovel grupoAutomoveis)
        {
            Log.Debug("Tentando editar Grupo de Automoveis...{@g}", grupoAutomoveis);

            List<string> erros = ValidarGrupoAutomoveis(grupoAutomoveis);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioGrupoAutomoveis.Editar(grupoAutomoveis);
                
                contextoPersistencia.GravarDados();

                Log.Debug("Grupo de Automoveis {GrupoAutomoveisId} editada com sucesso", grupoAutomoveis.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Grupo de Automoveis.";

                Log.Error(exc, msgErro + "{@g}", grupoAutomoveis);

                return Result.Fail(msgErro);
            }
        }
        
        public Result Excluir(GrupoAutomovel grupoAutomoveis)
        {
            Log.Debug("Tentando excluir GrupoAutomoveis...{@g}", grupoAutomoveis);

            try
            {
                bool GrupoAutomoveisExiste = repositorioGrupoAutomoveis.Existe(grupoAutomoveis);

                if (GrupoAutomoveisExiste == false)
                {
                    Log.Warning("GrupoAutomoveis {GrupoAutomoveisId} não encontrada para excluir", grupoAutomoveis.Id);

                    return Result.Fail("GrupoAutomoveis não encontrada");
                }

                repositorioGrupoAutomoveis.Excluir(grupoAutomoveis);

                contextoPersistencia.GravarDados();

                Log.Debug("GrupoAutomoveis {GrupoAutomoveisId} excluída com sucesso", grupoAutomoveis.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

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
        
        private List<string> ValidarGrupoAutomoveis(GrupoAutomovel grupoAutomoveis)
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

        private bool NomeDuplicado(GrupoAutomovel grupoAutomoveis)
        {
            GrupoAutomovel GrupoAutomoveisEncontrada = repositorioGrupoAutomoveis.SelecionarPorNome(grupoAutomoveis.Tipo);

            if (GrupoAutomoveisEncontrada != null &&
                GrupoAutomoveisEncontrada.Id != grupoAutomoveis.Id &&
                GrupoAutomoveisEncontrada.Tipo == grupoAutomoveis.Tipo)
            {
                return true;
            }

            return false;
        }
    }
}
