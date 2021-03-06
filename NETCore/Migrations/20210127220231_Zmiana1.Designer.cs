﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETCore.Models;

namespace NETCore.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210127220231_Zmiana1")]
    partial class Zmiana1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NETCore.Models.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Imie")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("NETCore.Models.Obuwie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Cena")
                        .HasColumnType("double");

                    b.Property<string>("ManorWomen")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nazwa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Rodzaj")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Rozmiar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Obuwie");
                });

            modelBuilder.Entity("NETCore.Models.Zamowienie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.Property<int>("ObuwieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlientId");

                    b.HasIndex("ObuwieId");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("NETCore.Models.Zamowienie", b =>
                {
                    b.HasOne("NETCore.Models.Klient", "Klient")
                        .WithMany("Zamowienie")
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETCore.Models.Obuwie", "Obuwie")
                        .WithMany("Zamowienie")
                        .HasForeignKey("ObuwieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
