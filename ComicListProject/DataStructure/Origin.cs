namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Origin : Model
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string FlagUrl { get; set; }
        public ICollection<Comic> Comics { get; set; }
    }
}