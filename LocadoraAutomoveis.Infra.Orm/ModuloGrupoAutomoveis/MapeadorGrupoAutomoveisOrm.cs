using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis
{
    internal class MapeadorGrupoAutomoveisOrm : IEntityTypeConfiguration<GrupoAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomoveis> grupoAutomoveisBuilder)
        {
            grupoAutomoveisBuilder.ToTable("TBGrupoAutomoveis");

            grupoAutomoveisBuilder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

            grupoAutomoveisBuilder.Property(x => x.Tipo).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
