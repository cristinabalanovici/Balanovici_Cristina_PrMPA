// <auto-generated />
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
    [Migration("20230116021928_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Veterinar", (string)null);
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

            modelBuilder.Entity("Balanovici_Cristina_PrMPA.Models.Client", b =>
                {
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
