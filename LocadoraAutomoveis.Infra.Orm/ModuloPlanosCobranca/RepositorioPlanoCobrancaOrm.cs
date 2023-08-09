using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Infra.Orm.ModuloPlanosCobranca
{
    public class RepositorioPlanoCobrancaOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public PlanoCobranca SelecionarPorNome(TipoPlanoEnum tipo)
        {
            return registros.FirstOrDefault(x => x.TipoPlano == tipo);
        }

        public List<PlanoCobranca> SelecionarTodos(bool incluirCategoriaGrupAuto = false)
        {
            if (incluirCategoriaGrupAuto)
                return registros.Include(x => x.CategoriaGrupAuto).ToList();

            return registros.ToList();
        }
    }
}
