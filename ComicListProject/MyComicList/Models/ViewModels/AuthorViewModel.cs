using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class AuthorViewModel 
    {
        public IEnumerable<Comic> Comics { get; set; }
        public IEnumerable<Comic> Authors { get; set; }
        public string CurrentAuthor { get; set; }
    }
}
