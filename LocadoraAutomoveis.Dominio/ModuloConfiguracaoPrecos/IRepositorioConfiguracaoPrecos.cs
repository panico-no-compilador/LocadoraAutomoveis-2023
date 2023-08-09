namespace LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos
{
    public interface IRepositorioConfiguracaoPrecos : IRepositorio<Combustivel>
    {
        public Combustivel SelecionarPorCombustivel(Combustivel preco);
        public void ConfigurarPrecoCombustiveis(Combustivel combustivel);
    }
}
