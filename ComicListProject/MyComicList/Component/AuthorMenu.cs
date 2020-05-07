using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Component
{
    public class AuthorMenu : ViewComponent
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorMenu(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IViewComponentResult Invoke()
        {
            var authors = _authorRepository.Authors.OrderBy(s => s.LastName);
            return View(authors);
        }
    }
}
