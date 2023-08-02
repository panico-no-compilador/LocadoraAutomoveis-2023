using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        
        public Parceiro() 
        {
            Cupoms = new List<Cupom>();
        }
        public string Nome { get; set; }
        public Parceiro(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
      
        public List<Cupom> Cupoms { get; set; }
        public override void Atualizar(Parceiro registro)
        {
            throw new NotImplementedException();
        }
    }
}
