namespace DataAccess.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public List<Movie>? Movies { get; set; }
    }
   
}