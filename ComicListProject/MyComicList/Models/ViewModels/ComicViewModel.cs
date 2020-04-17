using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class ComicViewModel : ViewModel
    {
        [Required]
        public string Title { get; set; }

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


        // MARK: - 1-to-1 Relationships

        public int OriginID { get; set; }
        public OriginViewModel Origin { get; set; }

        // MARK: 1-to-Mnay Relationships

        public List<int> GenreIDs { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }

        // MARK: - Many-to-Many Relationships

        public List<int> StudiosIDs { get; set; }
        public ICollection<StudioViewModel> Studios { get; set; }

        public ComicViewModel() : base() { }

        public ComicViewModel(Comic comic) : base(comic)
        {
            Title = comic.Title;
            Info = comic.Info;
            Volumes = comic.Volumes;
            ImageUrl = comic.ImageUrl;
            ImageThumbnailUrl = comic.ImageThumbnailUrl;
            IsPopularComic = comic.IsPopularComic;
            IsCompletedComic = comic.IsCompletedComic;


            if (comic.Origin != null)
            {
                OriginID = comic.Origin.ID;
                Origin = new OriginViewModel(comic.Origin);
            }
            if (comic.Studios != null)
            {
                StudiosIDs = new List<int>();
                foreach (Studio studio in comic.Studios)
                {
                    StudiosIDs.Add(studio.ID);
                }

                Studios = StudioViewModel.ToList(comic.Studios.ToList());
            }
            if (comic.Genres != null)
            {
                GenreIDs = new List<int>();
                foreach (Genre genre in comic.Genres)
                {
                    GenreIDs.Add(genre.ID);
                }

                Genres = GenreViewModel.ToList(comic.Genres.ToList());
            }
        }

        public static List<ComicViewModel> ToList(ICollection<Comic> comics)
        {
            List<ComicViewModel> comicViewModels = new List<ComicViewModel>();
            foreach (Comic comic in comics)
            {
                ComicViewModel comicViewModel = new ComicViewModel(comic);
                comicViewModels.Add(comicViewModel);
            }
            return comicViewModels;
        }
    }
}