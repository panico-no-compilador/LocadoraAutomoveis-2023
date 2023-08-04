using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Infra.Orm.ModuloPlanosCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> planoCobrancaBuilder)
        {
            planoCobrancaBuilder.ToTable("TBPlanoCobranca");

            planoCobrancaBuilder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

            planoCobrancaBuilder.Property(x => x.TipoPlano).IsRequired();

            planoCobrancaBuilder.Property(x => x.PrecoDiaria).IsRequired();

            planoCobrancaBuilder.Property(x => x.PrecoKm).IsRequired();

            planoCobrancaBuilder.Property(x => x.KmDisponiveis).IsRequired();

            planoCobrancaBuilder.HasOne(a => a.CategoriaGrupAuto)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_PlanoCobranca_GrupoAutomoveis")
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
