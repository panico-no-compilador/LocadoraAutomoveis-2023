using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxasServicos
{
    public class RepositorioTaxasServicos : RepositorioBaseEmOrm<TaxasServicos>, IRepositorioTaxasServicos
    {
        public RepositorioTaxasServicos(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public TaxasServicos SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
