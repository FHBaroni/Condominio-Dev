﻿// <auto-generated />
using System;
using CondominioDev.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CondominioDev.Api.Data.Migrations
{
    [DbContext(typeof(ProjetoDbContext))]
    [Migration("20220919024208_migrations")]
    partial class migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CondominioDev.Api.Models.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("GastoTotal")
                        .HasColumnType("float");

                    b.Property<decimal>("Orcamento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Condominio", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GastoTotal = 700.0,
                            Orcamento = 1200m
                        });
                });

            modelBuilder.Entity("CondominioDev.Api.Models.Habitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<int?>("CondominioId1")
                        .HasColumnType("int");

                    b.Property<double>("CustoCondominio")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<double>("Renda")
                        .HasColumnType("float");

                    b.Property<string>("Sobrenome")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.HasIndex("CondominioId1")
                        .IsUnique()
                        .HasFilter("[CondominioId1] IS NOT NULL");

                    b.ToTable("Habitantes", (string)null);
                });

            modelBuilder.Entity("CondominioDev.Api.Models.Habitante", b =>
                {
                    b.HasOne("CondominioDev.Api.Models.Condominio", "Condominio")
                        .WithMany("Habitante")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CondominioDev.Api.Models.Condominio", null)
                        .WithOne("MaiorCusto")
                        .HasForeignKey("CondominioDev.Api.Models.Habitante", "CondominioId1");

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("CondominioDev.Api.Models.Condominio", b =>
                {
                    b.Navigation("Habitante");

                    b.Navigation("MaiorCusto");
                });
#pragma warning restore 612, 618
        }
    }
}
