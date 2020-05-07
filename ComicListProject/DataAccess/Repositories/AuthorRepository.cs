using DataAccess.Interfaces;
using DataStructure;
using MyComicList.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public AuthorRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Author> Authors => _appDbContext.Authors;
    }
}
