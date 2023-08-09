using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace LocadoraAutomoveis.Infra.Arquivo.Compartilhado
{
    public class ContextoDados
    {
        private const string NOME_ARQUIVO = "ArquivoConfiguracaoPreco.json";
        public List<Combustivel> listaCombustiveis;

        public ContextoDados()
        {
            listaCombustiveis = new List<Combustivel>();
        }
        public ContextoDados(bool carregarDados) : this()
        {
            CarregarDoArquivoJson();
        }
        public void GravarEmArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();
            string registrosJson = JsonSerializer.Serialize(this, config);
            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();
            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);
                if (registrosJson.Length > 0)
                {
                    ContextoDados contextoDo = JsonSerializer.Deserialize<ContextoDados>(registrosJson, config);
                    this.listaCombustiveis = contextoDo.listaCombustiveis;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;
            return opcoes;
        }
    }
}
