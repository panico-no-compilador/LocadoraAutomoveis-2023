using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros
{
    public class MapeadorCupomOrm : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> cupomBuilder)
        {
            cupomBuilder.ToTable("TBCupom");
            cupomBuilder.Property(c => c.Id).IsRequired(true).ValueGeneratedNever();
            cupomBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            cupomBuilder.Property(c => c.Valor).HasColumnType("decimal(20,2)").IsRequired();
            cupomBuilder.Property(c => c.DataValidade).HasColumnType("date").IsRequired();

            cupomBuilder.HasOne(c => c.Parceiro)
                .WithMany(p => p.Cupoms)
                .IsRequired()
                .HasConstraintName("FK_TBCupom_TBParceiro")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
