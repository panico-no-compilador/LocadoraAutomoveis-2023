using LocadoraAutomoveis.Dominio.ModuloAutomoveis;

namespace LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis
{
    public class MapeadorAutomovelOrm : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> materiaBuilder)
        {
            materiaBuilder.ToTable("TBAutomovel");
            materiaBuilder.Property(a => a.Id).IsRequired(true).ValueGeneratedNever();
            materiaBuilder.Property(a => a.Combustivel).IsRequired();
            materiaBuilder.Property(a => a.Cor).HasColumnType("varchar(30)").IsRequired();
            materiaBuilder.Property(a => a.Placa).HasColumnType("varchar(8)").IsRequired();
            materiaBuilder.Property(a => a.QntdCombustivel).HasConversion<int>().IsRequired();
            materiaBuilder.Property(a => a.Quilometragem).HasConversion<int>().IsRequired();
            materiaBuilder.Property(a => a.Marca).HasColumnType("varchar(25)").IsRequired();
            materiaBuilder.Property(a => a.Modelo).HasColumnType("varchar(45)").IsRequired();
            materiaBuilder.Property(a => a.Imagem).HasColumnType("varbinary(MAX)").IsRequired();
            materiaBuilder.Property(a => a.Ano).HasColumnType("int").IsRequired();
            materiaBuilder.Property(a => a.Alugado).HasColumnType("bit").IsRequired();
            materiaBuilder.HasOne(a => a.Categoria)
                  .WithMany()
                  .IsRequired()
                  .HasConstraintName("FK_Automovel_GrupoAutomoveis")
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
