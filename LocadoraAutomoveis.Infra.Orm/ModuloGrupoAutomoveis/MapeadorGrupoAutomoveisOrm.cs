using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis
{
    internal class MapeadorGrupoAutomoveisOrm : IEntityTypeConfiguration<GrupoAutomovel>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomovel> grupoAutomoveisBuilder)
        {
            grupoAutomoveisBuilder.ToTable("TBGrupoAutomoveis");

            grupoAutomoveisBuilder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

            grupoAutomoveisBuilder.Property(x => x.Tipo).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
