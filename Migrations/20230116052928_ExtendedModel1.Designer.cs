﻿// <auto-generated />
using System;
using Balanovici_Cristina_PrMPA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Balanovici_Cristina_PrMPA.Migrations
{
    [DbContext(typeof(VeterinarContext))]
    [Migration("20230116052928_ExtendedModel1")]
    partial class ExtendedModel1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataNasterii")
                        .HasMaxLength(1)
                        .HasColumnType("datetime2");

                    b.Property<string>("Gen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.AnimalInregistrat", b =>
                {
                    b.Property<int>("AnimalID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.HasKey("AnimalID", "ClientID");

                    b.HasIndex("ClientID");

                    b.ToTable("AnimalInregistrat", (string)null);
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Programare", b =>
                {
                    b.Property<int>("ProgramareID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramareID"), 1L, 1);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("VeterinarID")
                        .HasColumnType("int");

                    b.HasKey("ProgramareID");

                    b.HasIndex("ClientID");

                    b.HasIndex("VeterinarID");

                    b.ToTable("Programare", (string)null);
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Veterinar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataAngajare")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Veterinar", (string)null);
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.AnimalInregistrat", b =>
                {
                    b.HasOne("Balanovici_Cristina_PrMPA.Models.Animal", "Animal")
                        .WithMany("AnimalInregistrate")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Balanovici_Cristina_PrMPA.Models.Client", "Client")
                        .WithMany("AnimaleIntregistrate")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Programare", b =>
                {
                    b.HasOne("Balanovici_Cristina_PrMPA.Models.Client", "Client")
                        .WithMany("Programari")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Balanovici_Cristina_PrMPA.Models.Veterinar", "Veterinar")
                        .WithMany("Programari")
                        .HasForeignKey("VeterinarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Veterinar");
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Animal", b =>
                {
                    b.Navigation("AnimalInregistrate");
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Client", b =>
                {
                    b.Navigation("AnimaleIntregistrate");

                    b.Navigation("Programari");
                });

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Veterinar", b =>
                {
                    b.Navigation("Programari");
                });
#pragma warning restore 612, 618
        }
    }
}
