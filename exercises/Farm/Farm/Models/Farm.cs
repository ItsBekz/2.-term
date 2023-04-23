namespace FarmMVC.Models
{
    public class Farm
    {
        public int id { get; set; }
        public string? name { get; set; }
        public List<Animal>? animalList { get; set; }
    }
}
