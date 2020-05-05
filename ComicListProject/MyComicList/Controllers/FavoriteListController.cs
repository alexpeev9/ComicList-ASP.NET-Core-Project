
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System.Linq;

namespace MyComicList.Controllers
{
    public class FavoriteListController : Controller
    {
        private readonly IComicRepository _comicRepository;
        private readonly FavoriteService _favoriteService;

        public FavoriteListController(IComicRepository comicRepository, FavoriteService favoriteService)
        {
            _comicRepository = comicRepository;
            _favoriteService = favoriteService;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _favoriteService.GetFavoriteListItems();
            _favoriteService.FavoriteListItems = items;

            var favoriteListViewModel = new FavoriteListViewModel
            {
                FavoriteService = _favoriteService,
            };
            return View(favoriteListViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToFavoriteList(int comicId)
        {
            var selectedComic = _comicRepository.Comics.FirstOrDefault(p => p.ComicId == comicId);
            if (selectedComic != null)
            {
                _favoriteService.AddToList(selectedComic, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromFavoriteList(int comicId)
        {
            var selectedComic = _comicRepository.Comics.FirstOrDefault(p => p.ComicId == comicId);
            if (selectedComic != null)
            {
                _favoriteService.RemoveFromList(selectedComic);
            }
            return RedirectToAction("Index");
        }
    }
}
