namespace DataAccess.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }

}