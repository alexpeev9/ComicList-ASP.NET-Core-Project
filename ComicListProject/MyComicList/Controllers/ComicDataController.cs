
using DataAccess.Interfaces;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Controllers
{
    [Route("api/[controller]")]
    public class ComicDataController : Controller
    {
        private readonly IComicRepository _comicRepository;

        public ComicDataController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }

        [HttpGet]
        public IEnumerable<ComicViewModel> LoadMoreComics()
        {
            IEnumerable<Comic> dbComics = null;

            dbComics = _comicRepository.Comics.OrderBy(p => p.ComicId).Take(10);

            List<ComicViewModel> comics = new List<ComicViewModel>();

            foreach (var dbComic in dbComics)
            {
                comics.Add(MapDbComicToComicViewModel(dbComic));
            }
            return comics;
        }

        private ComicViewModel MapDbComicToComicViewModel(Comic dbComic) => new ComicViewModel()
        {
            ComicId = dbComic.ComicId,
            Name = dbComic.Title,
            ImageUrl = dbComic.ImageUrl
        };

    }
}
