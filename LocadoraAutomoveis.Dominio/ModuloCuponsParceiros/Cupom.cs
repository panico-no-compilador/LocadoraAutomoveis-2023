using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public class Cupom : EntidadeBase<Cupom>
    {
        public string Nome { get; set; }
        public Parceiro Parceiro { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public Cupom(Guid id, string nome,Parceiro parceiro,decimal valor, DateTime dataValidade) 
        {
         this.Id = id;
        }
        public Cupom()
        {
            
        }
        public override void Atualizar(Cupom cupom)
        {
            Nome = cupom.Nome;
            Parceiro = cupom.Parceiro;
            Valor = cupom.Valor;
            DataValidade = cupom.DataValidade;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Nome, Valor);
        }
        public override bool Equals(object obj)
        {
            return obj is Cupom cupom &&
                   Id == cupom.Id &&
                   Nome == cupom.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Valor, DataValidade, Parceiro);
        }


    }
}
