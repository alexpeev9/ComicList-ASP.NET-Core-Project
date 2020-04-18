namespace DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using DataStructure;
    public class GenreRepository : GenericRepository<Genre>
    {
        public GenreRepository() : base(new ComicDbContext())
        {
        }
        public List<Comic> GetComicsForGenreByID(int id)
        {
            return this.GetByID(id).Comics.ToList();
        }
        public List<Genre> SearchBy(string queryString)
        {
            return context.Genres.Where(studio => studio.Type.Contains(queryString)).ToList();
        }
        public List<Genre> GetComicsByGenreType(string type)
        {
            return this.context.Genres.Where(Drama => Drama.Type == type).ToList();
        }
        public List<Genre> GetByIDs(List<int> IDs)
        {
            List<Genre> genres = new List<Genre>();
            foreach (int ID in IDs)
            {
                genres.Add(GetByID(ID));
            }
            return genres;
        }
    }
}


