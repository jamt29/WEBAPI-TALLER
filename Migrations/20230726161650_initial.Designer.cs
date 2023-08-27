﻿// <auto-generated />
using System;
using Ejercicio_26_07.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ejercicio_26_07.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230726161650_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TallerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TallerId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TallerId1");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Taller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Talleres");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Auto", b =>
                {
                    b.HasOne("Ejercicio_26_07.Entidades.Taller", null)
                        .WithMany("Autos")
                        .HasForeignKey("TallerId1");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Taller", b =>
                {
                    b.Navigation("Autos");
                });
#pragma warning restore 612, 618
        }
    }
}