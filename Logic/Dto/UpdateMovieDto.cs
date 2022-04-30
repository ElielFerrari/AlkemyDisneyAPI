using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class UpdateMovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public DateTime Release { get; set; }
        [Range (0 , 5)]
        public int Rate { get; set; }
    }
}
