using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
