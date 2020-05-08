using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class GenreViewModel
    {
        public IEnumerable<Comic> Comics { get; set; }
        public IEnumerable<Comic> Genres { get; set; }
        public string CurrentGenre { get; set; }
    }
}
