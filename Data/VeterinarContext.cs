using Microsoft.EntityFrameworkCore;
using Balanovici_Cristina_PrMPA.Models;
namespace Balanovici_Cristina_PrMPA.Data
{
    public class VeterinarContext:DbContext
    {
        public VeterinarContext(DbContextOptions<VeterinarContext> options) : base(options)
        {
        }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Programare> Programari { get; set; }
        public DbSet<Veterinar> Veterinari { get; set; }
        public DbSet<Animal> Animale { get; set; }
        public DbSet<AnimalInregistrat> AnimaleInregistrate { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Programare>().ToTable("Programare");
            modelBuilder.Entity<Veterinar>().ToTable("Veterinar");
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<AnimalInregistrat>().ToTable("AnimalInregistrat");
            modelBuilder.Entity<AnimalInregistrat>().HasKey(a => new { a.AnimalID, a.ClientID });
        }

    }
}
