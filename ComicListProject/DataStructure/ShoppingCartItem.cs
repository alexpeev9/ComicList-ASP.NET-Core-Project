using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructure
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Comic Comic { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
