using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros
{
    public class RepositorioCupomEmOrm : RepositorioBaseEmOrm<Cupom>, IRepositorioCupom
    {
        public RepositorioCupomEmOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public Cupom SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public List<Cupom> SelecionarTodos(bool incluirParceiro = false)
        {
            if (incluirParceiro)
                return registros.Include(x => x.Parceiro).ToList();

            return registros.ToList();
        }
    }
}
