namespace BusinessLogic.Dto
{
    public class GenreDto
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public List<MovieDto> Movies { get; set; }
    }
}
