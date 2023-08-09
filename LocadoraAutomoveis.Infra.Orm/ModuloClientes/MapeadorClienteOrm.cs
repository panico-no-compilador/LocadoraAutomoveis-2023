using LocadoraAutomoveis.Dominio.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloClientes
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> clienteBuilder)
        {
            clienteBuilder.ToTable("TBCliente");

            clienteBuilder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            clienteBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Telefone).HasColumnType("varchar(200)");
            clienteBuilder.Property(c => c.Estado).HasColumnType("varchar(200)");
            clienteBuilder.Property(c => c.Cidade).HasColumnType("varchar(100)");
            clienteBuilder.Property(c => c.Bairro).HasColumnType("varchar(200)");
            clienteBuilder.Property(c => c.Rua).HasColumnType("varchar(100)");
            clienteBuilder.Property(c => c.Numero).HasColumnType("varchar(100)");
            clienteBuilder.Property(c => c.CpfOUCnpj).HasColumnType("varchar(200)").IsRequired();
            clienteBuilder.Property(c => c.TipoPessoa).IsRequired();


            clienteBuilder.HasMany(c => c.CuponsUsados)
                .WithOne()
                .HasForeignKey("ClienteId");


        }
    }
}
