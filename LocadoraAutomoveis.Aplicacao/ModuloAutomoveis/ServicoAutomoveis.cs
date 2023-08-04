using LocadoraAutomoveis.Dominio.ModuloAutomoveis;

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
