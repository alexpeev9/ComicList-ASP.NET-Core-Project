namespace DataAccess.Repositories
{
    using DataStructure;
    using System.Collections.Generic;
    using System.Linq;
    public class OriginRepository : GenericRepository<Origin>
    {
        public OriginRepository() : base(new ComicDbContext())
        {
        }

        public List<Comic> GetComicsForOriginByID(int id)
        {
            return this.GetByID(id).Comics.ToList();
        }
        public List<Origin> GetOriginByName(string name)
        {
            return this.context.Origins.Where(x => x.Name == name).ToList();
        }
    }
}
