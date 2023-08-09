using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Dominio.ModuloTaxasServicos
{
    public class TaxasServicos : EntidadeBase<TaxasServicos>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public PlanoCalculoEnum PlanoCalculo { get; set; }
        public TaxasServicos()
        {
            
        }
        public override void Atualizar(TaxasServicos registro)
        {
            this.Nome = registro.Nome;
            this.Preco = registro.Preco;
            this.PlanoCalculo = registro.PlanoCalculo;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Preco, PlanoCalculo);
        }
        public override string ToString()
        {
            return Nome.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is TaxasServicos grupAuto &&
                   Id == grupAuto.Id &&
            Nome == grupAuto.Nome &&
            Preco == grupAuto.Preco &&
            PlanoCalculo == grupAuto.PlanoCalculo;
        }
    }
}
