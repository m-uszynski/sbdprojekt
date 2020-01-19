﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SbdProjekto.Models;

namespace SbdProjekto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200119201651_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SbdProjekto.Models.Kurier", b =>
                {
                    b.Property<int>("KurierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RejonId")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KurierId");

                    b.HasIndex("RejonId");

                    b.ToTable("Kurierzy");
                });

            modelBuilder.Entity("SbdProjekto.Models.Magazyn", b =>
                {
                    b.Property<int>("MagazynId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KodPocztowy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MagazynId");

                    b.ToTable("Magazyny");
                });

            modelBuilder.Entity("SbdProjekto.Models.Nadawca", b =>
                {
                    b.Property<int>("NadawcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPocztowy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NadawcaId");

                    b.ToTable("Nadawcy");
                });

            modelBuilder.Entity("SbdProjekto.Models.Odbiorca", b =>
                {
                    b.Property<int>("OdbiorcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPocztowy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OdbiorcaId");

                    b.ToTable("Odbiorcy");
                });

            modelBuilder.Entity("SbdProjekto.Models.Przesylka", b =>
                {
                    b.Property<int>("PrzesylkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Dlugosc")
                        .HasColumnType("float");

                    b.Property<int>("MagazynId")
                        .HasColumnType("int");

                    b.Property<int>("RodzajPrzesylkiId")
                        .HasColumnType("int");

                    b.Property<double>("Szerokosc")
                        .HasColumnType("float");

                    b.Property<double>("Waga")
                        .HasColumnType("float");

                    b.Property<double>("Wysokosc")
                        .HasColumnType("float");

                    b.Property<int>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("PrzesylkaId");

                    b.HasIndex("MagazynId");

                    b.HasIndex("RodzajPrzesylkiId");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("Przesylki");
                });

            modelBuilder.Entity("SbdProjekto.Models.Rejon", b =>
                {
                    b.Property<int>("RejonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wojewodztwo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RejonId");

                    b.ToTable("Rejony");
                });

            modelBuilder.Entity("SbdProjekto.Models.RodzajPrzesylki", b =>
                {
                    b.Property<int>("RodzajPrzesylkiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RodzajPrzesylkiId");

                    b.ToTable("RodzajePrzesylek");
                });

            modelBuilder.Entity("SbdProjekto.Models.Zamowienie", b =>
                {
                    b.Property<int>("ZamowienieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNadania")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOdbioru")
                        .HasColumnType("datetime2");

                    b.Property<int>("KurierId")
                        .HasColumnType("int");

                    b.Property<int>("NadawcaId")
                        .HasColumnType("int");

                    b.Property<int>("OdbiorcaId")
                        .HasColumnType("int");

                    b.HasKey("ZamowienieId");

                    b.HasIndex("KurierId");

                    b.HasIndex("NadawcaId");

                    b.HasIndex("OdbiorcaId");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("SbdProjekto.Models.Kurier", b =>
                {
                    b.HasOne("SbdProjekto.Models.Rejon", "Rejon")
                        .WithMany("Kurierzy")
                        .HasForeignKey("RejonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SbdProjekto.Models.Przesylka", b =>
                {
                    b.HasOne("SbdProjekto.Models.Magazyn", "Magazyn")
                        .WithMany("Przesylki")
                        .HasForeignKey("MagazynId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SbdProjekto.Models.RodzajPrzesylki", "RodzajPrzesylki")
                        .WithMany("Przesylki")
                        .HasForeignKey("RodzajPrzesylkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SbdProjekto.Models.Zamowienie", "Zamowienie")
                        .WithMany("Przesylki")
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SbdProjekto.Models.Zamowienie", b =>
                {
                    b.HasOne("SbdProjekto.Models.Kurier", "Kurier")
                        .WithMany("Zamowienia")
                        .HasForeignKey("KurierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SbdProjekto.Models.Nadawca", "Nadawca")
                        .WithMany("Zamowienia")
                        .HasForeignKey("NadawcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SbdProjekto.Models.Odbiorca", "Odbiorca")
                        .WithMany("Zamowienia")
                        .HasForeignKey("OdbiorcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
