using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxasServicos
{
    public class RepositorioTaxasServicosOrm : RepositorioBaseEmOrm<TaxasServicos>, IRepositorioTaxasServicos
    {
        public RepositorioTaxasServicosOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public TaxasServicos SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
