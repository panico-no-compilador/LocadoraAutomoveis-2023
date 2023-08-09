using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxasServicos
{
    public class MapeadorTaxasServicos : IEntityTypeConfiguration<TaxasServicos>
    {
        public void Configure(EntityTypeBuilder<TaxasServicos> builder)
        {
            builder.ToTable("TBTaxasServicos");

            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();

            builder.Property(x => x.Preco).IsRequired();

            builder.Property(x => x.PlanoCalculo).IsRequired();
        }
    }
}
