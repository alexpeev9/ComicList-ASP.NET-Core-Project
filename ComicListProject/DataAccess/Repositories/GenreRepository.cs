namespace DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using DataStructure;
    class GenreRepository : GenericRepository<Genre>
    {
        public GenreRepository() : base(new ComicDbContext())
        {
        }
        public List<Comic> GetComicsForStudioByID(int id)
        {
            return this.GetByID(id).Comics.ToList();
        }
       public List<Genre> GetComicsByGenreType(string type)
        {
            return this.context.Genres.Where(Drama => Drama.Type == type).ToList();
        }
    }
}

