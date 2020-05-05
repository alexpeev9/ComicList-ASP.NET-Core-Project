using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructure
{
    public class FavoriteListItem
    {
        public int FavoriteListItemId { get; set; }
        public Comic Comic { get; set; }
        public int Amount { get; set; }
        public string FavoriteListId { get; set; }
    }
}
