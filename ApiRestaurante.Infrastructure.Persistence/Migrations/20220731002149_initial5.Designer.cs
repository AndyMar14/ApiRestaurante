﻿// <auto-generated />
using System;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220731002149_initial5")]
    partial class initial5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.DetalleOrden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.Property<int>("IdPlato")
                        .HasColumnType("int");

                    b.Property<int?>("PlatosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrden");

                    b.HasIndex("PlatosId");

                    b.ToTable("detalleOrden");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.DetallePlatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdIngrediente")
                        .HasColumnType("int");

                    b.Property<int>("IdPlato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdIngrediente");

                    b.ToTable("DetallePlatos");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Ingredientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ingredientes");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Mesas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CantidadPersonas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdMesa")
                        .HasColumnType("int");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("orden");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Platos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("platos");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.DetalleOrden", b =>
                {
                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Orden", "Orden")
                        .WithMany("Platos")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Platos", "Platos")
                        .WithMany()
                        .HasForeignKey("PlatosId");

                    b.Navigation("Orden");

                    b.Navigation("Platos");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.DetallePlatos", b =>
                {
                    b.HasOne("ApiRestaurante.Core.Domain.Entities.Ingredientes", "Ingrediente")
                        .WithMany("DetallePLatos")
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Ingredientes", b =>
                {
                    b.Navigation("DetallePLatos");
                });

            modelBuilder.Entity("ApiRestaurante.Core.Domain.Entities.Orden", b =>
                {
                    b.Navigation("Platos");
                });
#pragma warning restore 612, 618
        }
    }
}
