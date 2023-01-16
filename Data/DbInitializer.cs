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
                        LastName = "Mihnea",
                        DataAngajare = DateTime.Parse("2021-09-08")
                    },
                    new Veterinar
                    {
                        FirstName = "Ioana",
                        LastName = "Dumitrescu",
                        DataAngajare = DateTime.Parse("2013-12-05")
                    },
                    new Veterinar
                    {
                        FirstName = "Alexandra",
                        LastName = "Potop",
                        DataAngajare = DateTime.Parse("2012-02-15")
                    },
                    new Veterinar
                    {
                        FirstName = "Vlad",
                        LastName = "Popescu",
                        DataAngajare= DateTime.Parse("2022-01-10")
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
                var animale = new Animal[]
                {
                    new Animal
                    {
                        Nume = "Freya",
                        Rasa = "pisica",
                        Gen = "F",
                        DataNasterii = DateTime.Parse("2021-03-21")
                    },
                    new Animal
                    {
                        Nume = "Bella",
                        Rasa = "caine",
                        Gen = "F",
                        DataNasterii = DateTime.Parse("2012-12-04")
                    },
                    new Animal
                    {
                        Nume = "Coco",
                        Rasa = "papagal",
                        Gen="M",
                        DataNasterii=DateTime.Parse("2020-03-12")
                    },
                    new Animal
                    {
                        Nume = "Riri",
                        Rasa = "papagal",
                        Gen="F",
                        DataNasterii=DateTime.Parse("2020-05-30")
                    },
                    new Animal
                    {
                        Nume = "Snow",
                        Rasa = "pisica",
                        Gen="M",
                        DataNasterii=DateTime.Parse("2018-09-21")
                    }
                };
                foreach (Animal a in animale )
                {
                    context.Animale.Add(a);
                }
                context.SaveChanges();

                var clienti = context.Clienti;

                var animaleinrg = new AnimalInregistrat[]
                {
                    new AnimalInregistrat
                    {
                        AnimalID = animale.Single(a=>a.Nume=="Riri").ID,
                        ClientID = clienti.Single(c=>c.LastName=="Zamfir").ID
                    },
                    new AnimalInregistrat
                    {
                        AnimalID = animale.Single(a=>a.Nume=="Coco").ID,
                        ClientID=clienti.Single(c=>c.LastName=="Zamfir").ID
                    },
                    new AnimalInregistrat
                    {
                        AnimalID = animale.Single(a=>a.Nume=="Freya").ID,
                        ClientID=clienti.Single(c=>c.LastName=="Enea").ID
                    }
                };
                foreach (AnimalInregistrat ai in animaleinrg)
                {
                    context.AnimaleInregistrate.Add(ai);
                }
                context.SaveChanges();
            }
        }
    }
}
