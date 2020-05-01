using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Comic> PreferedComics { get; set; }
    }
}
