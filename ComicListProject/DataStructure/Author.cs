using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataStructure
{
     public class Author
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }        
        [Required]
        public string LastName { get; set; }   
        [Required]
        public List<Comic> Comics { get; set; }
    }
}
