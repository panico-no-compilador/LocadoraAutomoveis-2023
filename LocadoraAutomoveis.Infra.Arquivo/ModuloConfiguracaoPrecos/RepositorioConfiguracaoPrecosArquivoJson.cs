using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.Infra.Arquivo.Compartilhado;

namespace LocadoraAutomoveis.Infra.Arquivo.ModuloConfiguracaoPrecos
{
    public class RepositorioConfiguracaoPrecosArquivoJson : RepositorioArquivoBase<Combustivel>, IRepositorioConfiguracaoPrecos
    {
        public RepositorioConfiguracaoPrecosArquivoJson(ContextoDados contexto) : base(contexto)
        {
        }
        public void ConfigurarPrecoCombustiveis(Combustivel combustivel)
        {
            if (contextoDados.listaCombustiveis == null)
            {
                base.Inserir(combustivel);
            }
            else 
            {
                base.Editar(combustivel.Id, combustivel);
            }
        }
        public void Editar(Combustivel registro)
        {
            base.Editar(registro.Id, registro);
        }
        public bool Existe(Combustivel registro)
        {
            return contextoDados.listaCombustiveis.Contains(registro);
        }
        public Combustivel SelecionarPorCombustivel(Combustivel combustivel)
        {
            return contextoDados.listaCombustiveis.FirstOrDefault(x => x.PrecoGasolina == combustivel.PrecoGasolina);
        }
        protected override List<Combustivel> ObterRegistros()
        {
            return contextoDados.listaCombustiveis;
        }
    }
}
