
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace MyComicList.Controllers
{
    public class ComicController : Controller
    {
        private readonly IComicRepository _comicRepository;
        private readonly IOriginRepository _originRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;

        public ComicController(IComicRepository comicRepository, IOriginRepository originRepository, IAuthorRepository authorRepository, IGenreRepository genreRepository)
        {
            _comicRepository = comicRepository;
            _originRepository = originRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
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

            return View("~/Views/Comic/ListAuthor.cshtml",new AuthorViewModel
            {
                Authors = comics,
                CurrentAuthor = currentAuthor
            });
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

            return View("~/Views/Comic/ListGenre.cshtml",new GenreViewModel
            {
                Genres = comics,
                CurrentGenre = currentGenre
            });
        }
        public ViewResult List(string origin)
        {
            string _origin = origin;
            IEnumerable<Comic> comics;
            string currentOrigin = string.Empty;

            if (string.IsNullOrEmpty(origin))
            {
                comics = _comicRepository.Comics.OrderBy(p => p.ComicId);
                currentOrigin = "All Comics";
            }
            else
            {
                if (string.Equals("Japanese", _origin, StringComparison.OrdinalIgnoreCase))
                    comics = _comicRepository.Comics.Where(p => p.Origin.Name.Equals("Japanese")).OrderBy(p => p.Title);
                else
                    comics = _comicRepository.Comics.Where(p => p.Origin.Name.Equals("Korean")).OrderBy(p => p.Title);

                currentOrigin = _origin;
            }

            return View(new ComicListViewModel
            {
                Comics = comics,
                CurrentOrigin = currentOrigin
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Comic> comics;
            string currentOrigin = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                comics = _comicRepository.Comics.OrderBy(p => p.ComicId);
            }
            else
            {
                comics = _comicRepository.Comics.Where(p=> p.Title.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Comic/List.cshtml", new ComicListViewModel{Comics = comics, CurrentOrigin = "All comics" });
        }

        public ViewResult Details(int comicId)
        {
            var comic = _comicRepository.Comics.FirstOrDefault(d => d.ComicId == comicId);
            if (comic == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(comic);
        }
    }
}
