using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public interface IRepositorioCupom : IRepositorio<Cupom>
    {
       public Cupom SelecionarPorNome(string nome);

        List<Cupom> SelecionarTodos(bool incluirParceiro = false);
    }
}
