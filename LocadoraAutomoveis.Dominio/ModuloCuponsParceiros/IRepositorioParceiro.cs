using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public interface IRepositorioParceiro : IRepositorio<Parceiro>
    {
        Parceiro SelecionarPorNome(string nome);
    }
}
