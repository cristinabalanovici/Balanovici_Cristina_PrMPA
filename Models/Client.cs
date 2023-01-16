using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Balanovici_Cristina_PrMPA.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Programare> Programari { get; set; }
        public ICollection<AnimalInregistrat> AnimaleIntregistrate { get; set; }    
    }
}
