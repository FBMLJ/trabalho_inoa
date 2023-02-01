﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace projetoinoa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230201160343_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("MvcMoeda.Models.Moeda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Moeda");
                });

            modelBuilder.Entity("MvcMonitoramento.Models.Monitoramento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoedaAlvoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoedaOrigemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorDeCompra")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorDeVenda")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Monitoramento");
                });
#pragma warning restore 612, 618
        }
    }
}