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
    [Migration("20230728162544_step5")]
    partial class step5
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

                    b.Property<int?>("TallerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TallerId");

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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Talleres");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.TallerAuto", b =>
                {
                    b.Property<int>("TallerId")
                        .HasColumnType("int");

                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.HasKey("TallerId", "AutoId");

                    b.HasIndex("AutoId");

                    b.ToTable("TalleresAutores");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Auto", b =>
                {
                    b.HasOne("Ejercicio_26_07.Entidades.Taller", null)
                        .WithMany("Autos")
                        .HasForeignKey("TallerId");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.TallerAuto", b =>
                {
                    b.HasOne("Ejercicio_26_07.Entidades.Auto", "Auto")
                        .WithMany("TalleresAutos")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ejercicio_26_07.Entidades.Taller", "Taller")
                        .WithMany()
                        .HasForeignKey("TallerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Taller");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Auto", b =>
                {
                    b.Navigation("TalleresAutos");
                });

            modelBuilder.Entity("Ejercicio_26_07.Entidades.Taller", b =>
                {
                    b.Navigation("Autos");
                });
#pragma warning restore 612, 618
        }
    }
}
