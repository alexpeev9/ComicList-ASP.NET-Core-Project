using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataStructure
{
    class Genre
    {
        [Required]
        public int GenreId { get; set; }
        public List<Comic> Comics { get; set; }
    }
}
