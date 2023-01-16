using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Balanovici_Cristina_PrMPA.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Nume { get; set; }    
        [Required]
        public string Rasa { get; set; }
        [Required]
        [StringLength(1)]
        public string Gen { get; set; }
        

        public DateTime DataNasterii { get; set; }
        public ICollection<AnimalInregistrat> AnimaleInregistrate { get; set; }
    }
}
