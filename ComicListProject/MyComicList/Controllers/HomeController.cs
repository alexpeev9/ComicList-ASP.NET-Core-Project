using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyComicList.Models;
using MyComicList.Models.ViewModels;

namespace MyComicList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComicRepository _comicRepository;
        public HomeController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferedComics = _comicRepository.PreferredComics
            };
            return View(homeViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
