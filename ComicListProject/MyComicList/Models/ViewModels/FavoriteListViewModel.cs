using DataAccess.Repositories;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class FavoriteListViewModel
    {
        public FavoriteService FavoriteService { get; set; }
        //public decimal ShoppingCartTotal { get; set; }
    }
}
