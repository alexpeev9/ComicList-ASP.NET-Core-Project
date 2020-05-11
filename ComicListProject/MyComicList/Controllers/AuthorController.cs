using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;

namespace MyComicList.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IComicRepository _comicRepository;
        public AuthorController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }
            public ViewResult ListAuthor(string author)
        {
            string _author = author;
            IEnumerable<Comic> comics;
            string currentAuthor = string.Empty;

            if (string.IsNullOrEmpty(author))
            {
                comics = _comicRepository.Comics;
                currentAuthor = "All Comics";
            }
            else
            {
                if (string.Equals("Kishimoto", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Kishimoto"));
                else if (string.Equals("Isayama", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Isayama"));
                else if (string.Equals("Sui", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Sui"));
                else if (string.Equals("Takahashi", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Takahashi"));
                else if (string.Equals("Kentaro", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Kentaro"));
                else if (string.Equals("Jin-Hwan", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Jin-Hwan"));
                else if (string.Equals("Carnby", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Carnby"));
                else if (string.Equals("Seung-Hee", _author, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Seung-Hee"));
                else comics = _comicRepository.Comics.Where(s => s.Author.LastName.Equals("Hichov"));

                currentAuthor = _author;
            }

            return View("~/Views/Comic/ListAuthor.cshtml", new AuthorViewModel
            {
                Authors = comics,
                CurrentAuthor = currentAuthor
            });
        }
    }
}