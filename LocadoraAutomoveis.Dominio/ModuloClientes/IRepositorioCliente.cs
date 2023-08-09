using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloClientes
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        public Cliente SelecionarPorNome(string nome);

        List<Cliente> SelecionarTodos();
    }
}
