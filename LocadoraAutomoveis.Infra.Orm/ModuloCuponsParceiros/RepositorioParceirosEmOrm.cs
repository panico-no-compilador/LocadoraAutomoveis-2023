using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros
{
    public class RepositorioParceiroEmOrm : RepositorioBaseEmOrm<Parceiro>, IRepositorioParceiro
    {
        public RepositorioParceiroEmOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }
        
        public Parceiro SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
  
    }
}
