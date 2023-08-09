using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public interface IRepositorioAutomoveis : IRepositorio<Automovel>
    {
        Automovel SelecionarPorPlaca(string nome);
        List<Automovel> SelecionarTodos(bool incluirCategoriaGrupAuto = false);

    }
}
