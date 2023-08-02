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

        private List<string> ValidarGrupoAutomoveis(GrupoAutomoveis disciplina)
        {
            var resultadoValidacao = validadorGrupoAutomoveis.Validate(disciplina);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(disciplina))
                erros.Add($"Este nome '{disciplina.Tipo}' já está sendo utilizado");

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
    }
}
