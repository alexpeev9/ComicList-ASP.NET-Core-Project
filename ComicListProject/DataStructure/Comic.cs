namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Comic : Model
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public byte Volumes { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string ImageThumbnailUrl { get; set; }
        [Required]
        public bool IsPopularComic { get; set; }
        [Required]
        public bool IsCompletedComic { get; set; }

        public Origin Origin { get; set; } // 1 to 1 Relationships
        public virtual ICollection<Genre> Genres { get; set; } // One-to-Many Relationships
        public virtual ICollection<Studio> Studios { get; set; } // Many-to-Many Relationships
    }
}
