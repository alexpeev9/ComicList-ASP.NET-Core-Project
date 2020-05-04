using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingRepository _shoppingCart;
        public ShoppingCartSummary(ShoppingRepository shoppingRepository)
        {
            _shoppingCart = shoppingRepository;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingRepository = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }


    }
}
