namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Studio : Model
    {
        // MARK: - Class Properties
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Location { get; set; }

        public ICollection<Comic> Comics { get; set; } // Many-to-Many Relationships
    }
}
