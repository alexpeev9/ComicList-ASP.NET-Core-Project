
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace MyComicList.Controllers
{
    public class ComicController : Controller
    {
        private readonly IComicRepository _comicRepository;

        public ComicController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
 
        }
        //public ViewResult ListAll(string allcomic)
        //{
        //    string _allcomic = allcomic;
        //    IEnumerable<Comic> comics;
        //    string currentComic = string.Empty;

        //    if (string.IsNullOrEmpty(allcomic))
        //    {
        //        currentComic = "All Comics";
        //    }
        //    else 
        //    {
        //        comics = _comicRepository.Comics.OrderBy(p => p.Title);
        //        currentComic = _allcomic;
        //    }
        //return View("~/Views/Comic/List.cshtml", new ComicListViewModel
        //    {
        //    Comics = comics,
        //    CurrentComic = currentComic
        //    });
        //}

            public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Comic> comics;
            string currentComic = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                comics = _comicRepository.Comics.OrderBy(p => p.ComicId);
            }
            else
            {
                comics = _comicRepository.Comics.Where(p => p.Title.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Comic/List.cshtml", new ComicListViewModel { Comics = comics, CurrentComic = "All comics" });
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
