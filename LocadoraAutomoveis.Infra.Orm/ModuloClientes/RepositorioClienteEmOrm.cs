using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloClientes
{
    public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public Cliente SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }


        List<Cliente> IRepositorioCliente.SelecionarTodos()
        {
            return registros.ToList();
        }
    }
}

