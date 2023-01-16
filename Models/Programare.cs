using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Balanovici_Cristina_PrMPA.Models
{
    public class Programare
    {
        public int ProgramareID { get; set; }
        public int ClientID { get; set; }
        public int VeterinarID { get; set; }
        public DateTime Data { get; set; }
        public Client Client { get; set; }
        public Veterinar Veterinar { get; set; }
    }
}
