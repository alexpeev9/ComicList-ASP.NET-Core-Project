using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;

namespace MyComicList.Controllers
{
    public class OriginController : Controller
    {
        private readonly IComicRepository _comicRepository;
        public OriginController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;

        }

        public ViewResult ListOrigin(string origin)
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

            return View("~/Views/Comic/ListOrigin.cshtml", new OriginViewModel
            {
                Origins = comics,
                CurrentOrigin = currentOrigin
            });
        }
    }
}