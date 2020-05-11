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
    public class GenreController : Controller
    {
        private readonly IComicRepository _comicRepository;

        public GenreController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }
        public ViewResult ListGenre(string genre)
        {
            string _genre = genre;
            IEnumerable<Comic> comics;
            string currentGenre = string.Empty;

            if (string.IsNullOrEmpty(genre))
            {
                comics = _comicRepository.Comics;
                currentGenre = "All Comics";
            }
            else
            {
                if (string.Equals("Action", _genre, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Genre.Name.Equals("Action"));
                else if (string.Equals("Drama", _genre, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Genre.Name.Equals("Drama"));
                else if (string.Equals("Comedy", _genre, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Genre.Name.Equals("Comedy"));
                else if (string.Equals("Horror", _genre, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(s => s.Genre.Name.Equals("Horror"));
                else comics = _comicRepository.Comics.Where(s => s.Genre.Name.Equals("Romance"));

                currentGenre = _genre;
            }

            return View("~/Views/Comic/ListGenre.cshtml", new GenreViewModel
            {
                Genres = comics,
                CurrentGenre = currentGenre
            });
        }
    }
}