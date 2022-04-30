namespace DataAccess.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public DateTime Release { get; set; }
        public int Rate { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }

}