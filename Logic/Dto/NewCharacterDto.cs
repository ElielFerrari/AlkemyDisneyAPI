using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dto
{
    public class NewCharacterDto
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        public List<int> MovieId { get; set; }
    }
}
