using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Balanovici_Cristina_PrMPA.Models
{
    public class AnimalInregistrat
    {
        public int AnimalID { get; set; }
        public int ClientID { get; set; }
        public Animal Animal { get; set; }
        public Client Client { get; set; }
    }
}
