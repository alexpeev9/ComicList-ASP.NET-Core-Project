using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class ComicViewModel
    {
        public int ComicId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
