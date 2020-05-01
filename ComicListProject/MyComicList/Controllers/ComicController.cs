
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
    public class ComicController : Controller
    {
        private readonly IComicRepository _comicRepository;
        private readonly IOriginRepository _originRepository;

        public ComicController(IComicRepository comicRepository, IOriginRepository originRepository)
        {
            _comicRepository = comicRepository;
            _originRepository = originRepository;
        }

        public ViewResult List(string origin)
        {
            string _origin = origin;
            IEnumerable<Comic> comics;
            string currentOrigin = string.Empty;

            if (string.IsNullOrEmpty(origin))
            {
                comics = _comicRepository.Comics.OrderBy(p => p.ComicId);
                currentOrigin = "All Comics";
            }
            else
            {
                if (string.Equals("Japanese", _origin, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(p => p.Origin.Name.Equals("Japanese")).OrderBy(p => p.Title);
                else
                    comics = _comicRepository.Comics.Where(p => p.Origin.Name.Equals("Korean")).OrderBy(p => p.Title);

                currentOrigin = _origin;
            }

            return View(new ComicListViewModel
            {
                Comics = comics,
                CurrentOrigin = currentOrigin
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Comic> comics;
            string currentOrigin = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                comics = _comicRepository.Comics.OrderBy(p => p.ComicId);
            }
            else
            {
                comics = _comicRepository.Comics.Where(p=> p.Title.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Comic/List.cshtml", new ComicListViewModel{Comics = comics, CurrentOrigin = "All comics" });
        }

        public ViewResult Details(int comicId)
        {
            var comic = _comicRepository.Comics.FirstOrDefault(d => d.ComicId == comicId);
            if (comic == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(comic);
        }
    }
}
