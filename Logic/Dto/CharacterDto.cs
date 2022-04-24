using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class CharacterDto
    {
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string? Story { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
