﻿// <auto-generated />
using System;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraAutomoveisDbContext))]
    [Migration("20230805015848_TaxasServicos")]
    partial class TaxasServicos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomovel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomoveis", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloPlanosCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaGrupAutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KmDisponiveis")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoDiaria")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoKm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaGrupAutoId");

                    b.ToTable("TBPlanoCobranca", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloTaxasServicos.TaxasServicos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PlanoCalculo")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxasServicos", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloPlanosCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis.GrupoAutomovel", "CategoriaGrupAuto")
                        .WithMany()
                        .HasForeignKey("CategoriaGrupAutoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_PlanoCobranca_GrupoAutomoveis");

                    b.Navigation("CategoriaGrupAuto");
                });
#pragma warning restore 612, 618
        }
    }
}
