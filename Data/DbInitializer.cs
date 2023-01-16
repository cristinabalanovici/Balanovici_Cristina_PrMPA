using Microsoft.EntityFrameworkCore;
using Balanovici_Cristina_PrMPA.Models;

namespace Balanovici_Cristina_PrMPA.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VeterinarContext(serviceProvider.GetRequiredService<DbContextOptions<VeterinarContext>>()))
            {
                if (context.Veterinari.Any())
                {
                    return;
                }

                context.Veterinari.AddRange(
                    new Veterinar
                    {
                        FirstName = "George",
                        LastName = "Mihnea"
                    },
                    new Veterinar
                    {
                        FirstName = "Ioana",
                        LastName = "Dumitrescu"
                    },
                    new Veterinar
                    {
                        FirstName = "Alexandra",
                        LastName = "Potop"
                    },
                    new Veterinar
                    {
                        FirstName = "Vlad",
                        LastName = "Popescu"
                    }
                );
                context.Clienti.AddRange(
                    new Client
                    {
                        FirstName = "Rodica",
                        LastName = "Grigorescu",
                        Email = "rodicageorgescu@gmail.com"
                    },
                    new Client
                    {
                        FirstName = "Calin",
                        LastName = "Enea",
                        Email = "calinenea@gmail.com"
                    },
                    new Client
                    {
                        FirstName = "Andreea",
                        LastName = "Zamfir",
                        Email = "andreeazamfir@gmail.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
