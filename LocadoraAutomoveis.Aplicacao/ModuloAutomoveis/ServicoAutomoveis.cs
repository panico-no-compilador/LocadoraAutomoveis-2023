using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

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

        private List<string> ValidarAutomoveis(Automovel automoveis)
        {
            var resultadoValidacao = validadorAutomoveis.Validate(automoveis);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (PlacaDuplicada(automoveis))
                erros.Add($"Esta placa '{automoveis.Placa}' já está sendo utilizada em outro veiculo");

            if (ValidarPlacaNova(automoveis) || ValidarPlacaAntiga(automoveis))
                erros.Add($"Este formato de placa '{automoveis.Placa}' nào pode ser utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
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
