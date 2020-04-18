namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Genre : Model
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Info { get; set; }
        public ICollection<Comic> Comics { get; set; }  // one to many
    }
}
