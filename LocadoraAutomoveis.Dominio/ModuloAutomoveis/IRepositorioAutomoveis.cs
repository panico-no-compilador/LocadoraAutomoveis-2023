namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public interface IRepositorioAutomoveis : IRepositorio<Automovel>
    {
        Automovel SelecionarPorPlaca(string nome);
    }
}
