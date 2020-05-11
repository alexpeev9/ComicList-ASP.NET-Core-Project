using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class ComicListViewModel
    {
        public IEnumerable<Comic> Comics { get; set; }
        public string CurrentComic { get; set; }
    }
}
