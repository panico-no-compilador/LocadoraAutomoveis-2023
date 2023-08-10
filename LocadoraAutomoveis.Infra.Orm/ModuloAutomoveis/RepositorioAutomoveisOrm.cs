using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis
{
    public class RepositorioAutomoveisOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomoveis
    {
        public RepositorioAutomoveisOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public Automovel SelecionarPorPlaca(string placa)
        {
            return registros.FirstOrDefault(_automovel => _automovel.Placa == placa);
        }
        public List<Automovel> SelecionarTodos(bool incluirCategoriaGrupAuto = false)
        {
            if (incluirCategoriaGrupAuto)
                return registros.Include(x => x.Categoria).ToList();

            return registros.ToList();
        }
        public List<Automovel>? SelecionarPorGrupo(GrupoAutomovel grupoDeAutomoveis)
        {
            return registros.Where(x => x.Categoria == grupoDeAutomoveis).ToList();
        }
    }
}
