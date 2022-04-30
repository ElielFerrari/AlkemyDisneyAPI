using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dto
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public DateTime Release { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
        public List<CharacterDto> Characters { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
