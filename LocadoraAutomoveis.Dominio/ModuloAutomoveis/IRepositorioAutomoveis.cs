using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public interface IRepositorioAutomoveis : IRepositorio<Automovel>
    {
        Automovel SelecionarPorPlaca(string nome);
        List<Automovel> SelecionarTodos(bool incluirCategoriaGrupAuto = false);
        List<Automovel>? SelecionarPorGrupo(GrupoAutomovel grupo);
    }
}
