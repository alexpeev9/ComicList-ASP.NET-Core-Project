using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataStructure
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        public List<Comic> Comics { get; set; }
    }
}
