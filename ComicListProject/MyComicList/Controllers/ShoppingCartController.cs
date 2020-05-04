
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System.Linq;

namespace MyComicList.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IComicRepository _comicRepository;
        private readonly ShoppingRepository _shoppingCartRepository;

        public ShoppingCartController(IComicRepository comicRepository, ShoppingRepository shoppingCartRepository)
        {
            _comicRepository = comicRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCartRepository.GetShoppingCartItems();
            _shoppingCartRepository.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingRepository = _shoppingCartRepository,
                ShoppingCartTotal = _shoppingCartRepository.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int comicId)
        {
            var selectedComic = _comicRepository.Comics.FirstOrDefault(p => p.ComicId == comicId);
            if (selectedComic != null)
            {
                _shoppingCartRepository.AddToCart(selectedComic, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int comicId)
        {
            var selectedComic = _comicRepository.Comics.FirstOrDefault(p => p.ComicId == comicId);
            if (selectedComic != null)
            {
                _shoppingCartRepository.RemoveFromCart(selectedComic);
            }
            return RedirectToAction("Index");
        }

    }
}
