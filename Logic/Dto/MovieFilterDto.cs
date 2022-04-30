using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class MovieFilterDto
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public DateTime Release{ get; set; }
    }
}
