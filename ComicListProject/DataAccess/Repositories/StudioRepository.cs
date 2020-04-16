namespace DataAccess.Repositories
{
    using DataStructure;
    using System.Collections.Generic;
    using System.Linq;
    class StudioRepository : GenericRepository<Studio>
    {
        public StudioRepository() : base(new ComicDbContext())
        {
        }
        public List<Studio> GetStudiosBytName(string Name)
        {
            return this.context.Studios.Where(x => x.Name == Name).ToList();
        }
        public List<Comic> GetComicsForStudioByID(int id)
        {
            return this.GetByID(id).Comics.ToList();
        }
    }
}
