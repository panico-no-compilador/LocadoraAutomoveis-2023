namespace LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos
{
    public class Combustivel : EntidadeBase<Combustivel>
    {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoGas { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoEtanol { get; set; }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, PrecoGasolina, PrecoGas, PrecoDiesel, PrecoEtanol);
        }
        public override string ToString()
        {
            return string.Format("Gasolina: R${0} | Gás: R${1} | Diesel: R${2} | Etanol: R${3}", PrecoGasolina, PrecoGas, PrecoDiesel, PrecoEtanol);
        }
        public override bool Equals(object obj)
        {
            return obj is Combustivel grupAuto &&
                   Id == grupAuto.Id &&
                   PrecoGasolina == grupAuto.PrecoGasolina &&
                   PrecoGas == grupAuto.PrecoGas &&
                   PrecoDiesel == grupAuto.PrecoDiesel &&
                   PrecoEtanol == grupAuto.PrecoEtanol;
        }

        public override void Atualizar(Combustivel registro)
        {
            this.PrecoGasolina = registro.PrecoGasolina;
            this.PrecoGas = registro.PrecoGas;
            this.PrecoDiesel = registro.PrecoDiesel;
            this.PrecoEtanol = registro.PrecoEtanol;
        }
    }
}
