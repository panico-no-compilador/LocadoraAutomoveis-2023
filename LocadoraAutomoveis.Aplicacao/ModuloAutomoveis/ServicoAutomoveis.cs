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
        public bool ValidarPlacaAntiga(Automovel grupoAutomoveis)
        {
            string placa = grupoAutomoveis.Placa;
            if (string.IsNullOrEmpty(placa) || placa.Length != 7)
            {
                return false;
            }

            string letras = placa.Substring(0, 3);
            string numeros = placa.Substring(3);

            // Verifica se as três primeiras posições são letras e as quatro últimas são números
            if (!letras.All(char.IsLetter) || !numeros.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        public bool ValidarPlacaNova(Automovel grupoAutomoveis)
        {
            string placa = grupoAutomoveis.Placa;
            if (string.IsNullOrEmpty(placa) || placa.Length != 8)
            {
                return false;
            }

            string letrasParte1 = placa.Substring(0, 3);
            string algarismo = placa.Substring(3, 1);
            string letra = placa.Substring(4, 1);
            string numerosParte2 = placa.Substring(5);

            // Verifica se as três primeiras posições são letras, o quarto é um dígito, a quinta é uma letra e as últimas três são números
            if (!letrasParte1.All(char.IsLetter) || !char.IsDigit(algarismo[0]) || !char.IsLetter(letra[0]) || !numerosParte2.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
