// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Viagem.Data;

namespace Viagem.Migrations
{
    [DbContext(typeof(ViagemContext))]
    partial class ViagemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Viagem.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pagar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("Viagem.Models.Passageiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passageiros");
                });

            modelBuilder.Entity("Viagem.Models.Viajar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("PagamentoId_pagamento")
                        .HasColumnType("int");

                    b.Property<string>("Partida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PassageiroId")
                        .HasColumnType("int");

                    b.Property<int>("PassageiroId_passageiro")
                        .HasColumnType("int");

                    b.Property<int>("dataIda")
                        .HasColumnType("int");

                    b.Property<int>("dataVolta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("PassageiroId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("Viagem.Models.Viajar", b =>
                {
                    b.HasOne("Viagem.Models.Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId");

                    b.HasOne("Viagem.Models.Passageiro", "Passageiro")
                        .WithMany()
                        .HasForeignKey("PassageiroId");

                    b.Navigation("Pagamento");

                    b.Navigation("Passageiro");
                });
#pragma warning restore 612, 618
        }
    }
}
