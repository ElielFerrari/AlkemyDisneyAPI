using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class MovieDto
    {
        public string? Title { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? Release { get; set; }
        public int Rate { get; set; }
        public List<Character>? Characters { get; set; }
    }
}
