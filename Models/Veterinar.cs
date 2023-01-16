using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Balanovici_Cristina_PrMPA.Models
{
    public class Veterinar
    {
        public int ID { get; set; } 
        public string FirstName { get; set; }   
        public string LastName { get; set; }  
        public DateTime DataAngajare { get; set; }
        public ICollection<Programare> Programari { get; set; }
    }
}
