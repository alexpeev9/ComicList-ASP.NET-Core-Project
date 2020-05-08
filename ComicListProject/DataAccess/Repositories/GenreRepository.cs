using DataAccess.Interfaces;
using DataStructure;
using MyComicList.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GenreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Genre> Genres => _appDbContext.Genres;
    }
}
