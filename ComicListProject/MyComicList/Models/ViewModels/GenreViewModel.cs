namespace MyComicList.Models.ViewModels
{
    using DataStructure;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class GenreViewModel : ViewModel
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Info { get; set; }

        // MARK:- One-to-Many Relationships

        public GenreViewModel() : base() { }

        public GenreViewModel(Genre genre) : base(genre)
        {
            Type = genre.Type;
            Info = genre.Info;
        }

        public static List<GenreViewModel> ToList(List<Genre> genres)
        {
            List<GenreViewModel> genreViewModels = new List<GenreViewModel>();
            foreach (Genre genre in genres)
            {
                GenreViewModel genreViewModel = new GenreViewModel(genre);
                genreViewModels.Add(genreViewModel);
            }
            return genreViewModels;
        }
    }
}