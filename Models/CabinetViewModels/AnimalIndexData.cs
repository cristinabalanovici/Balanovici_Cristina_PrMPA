namespace Balanovici_Cristina_PrMPA.Models.CabinetViewModels
{
    public class AnimalIndexData
    {
        public IEnumerable<Animal> Animale { get; set; }
        public IEnumerable<Client> Clienti { get; set; }
        public IEnumerable<Programare> Programari { get; set; }
    }
}
