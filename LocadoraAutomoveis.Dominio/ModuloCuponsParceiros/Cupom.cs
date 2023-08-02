using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public class Cupom : EntidadeBase<Cupom>
    {
        public Parceiro parceiro { get; set; }
        public Cupom() 
        {
         
        }

        public override void Atualizar(Cupom registro)
        {
            throw new NotImplementedException();
        }
    }
}
