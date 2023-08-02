using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
namespace LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros
{
    internal class MapeadorParceirosEmOrm : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("TBParceiros");
            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(d => d.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.HasMany(x => x.Cupoms).WithOne(c => c.parceiro);
        }
    }
}
