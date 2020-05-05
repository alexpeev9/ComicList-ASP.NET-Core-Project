namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comic
    {
        [Required]
        public int ComicId { get; set; }
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
        public bool InStock { get; set; }

        public int OriginID { get; set; }
        public virtual Origin Origin { get; set; }
    }
}
