using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dto
{
    public class UpdateMovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
    }
}
