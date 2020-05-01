namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Origin
    {
        [Required]
        public int OriginID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FlagUrl { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Comic> Comics { get; set; }
    }
}