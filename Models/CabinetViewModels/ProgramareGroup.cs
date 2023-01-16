using System;
using System.ComponentModel.DataAnnotations;

namespace Balanovici_Cristina_PrMPA.Models.CabinetViewModels
{
    public class ProgramareGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DataProgramare { get; set; }
        public int NrProgramari { get; set; }
    }
}
