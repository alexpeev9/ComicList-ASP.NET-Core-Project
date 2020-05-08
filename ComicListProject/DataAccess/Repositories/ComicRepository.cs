using DataAccess.Interfaces;
using DataStructure;
using Microsoft.EntityFrameworkCore;
using MyComicList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public ComicRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Comic> Comics => _appDbContext.Comics.Include(c => c.Author).Include(c => c.Origin).Include(c =>c.Genre);

        public IEnumerable<Comic> PreferredComics => _appDbContext.Comics.Where(p => p.IsPopularComic).Include(c => c.Origin);

        public Comic GetComicById(int comicId) => _appDbContext.Comics.FirstOrDefault(p => p.ComicId == comicId);
    }
}