namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {
        public string Tipo { get; set; }

        public override void Atualizar(GrupoAutomovel registro)
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
            return obj is GrupoAutomovel grupAuto &&
                   Id == grupAuto.Id &&
                   Tipo == grupAuto.Tipo;
        }
    }
}
