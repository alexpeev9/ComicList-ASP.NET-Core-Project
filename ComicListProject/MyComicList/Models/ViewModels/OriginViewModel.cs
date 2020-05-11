using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class OriginViewModel
    {
        public IEnumerable<Comic> Comics { get; set; }
        public IEnumerable<Comic> Origins { get; set; }
        public string CurrentOrigin { get; set; }
    }
}
