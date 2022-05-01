using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dto
{
    public class NewMovieDto
    {
        public string Title { get; set; }
        public DateTime Release { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
        public List<int> CharacterId { get; set; }
        public List<int> GenreId { get; set; }
    }
}
