namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomoveis : EntidadeBase<GrupoAutomoveis>
    {
        public string Tipo { get; set; }
        public override void Atualizar(GrupoAutomoveis registro)
        {
            this.Tipo = registro.Tipo;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Tipo);
        }
        public override string ToString()
        {
            return Tipo;
        }
        public override bool Equals(object obj)
        {
            return obj is GrupoAutomoveis grupAuto &&
                   Id == grupAuto.Id &&
                   Tipo == grupAuto.Tipo;
        }
    }
}
