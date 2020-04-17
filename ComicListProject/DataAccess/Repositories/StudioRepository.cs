namespace DataAccess.Repositories
{
    using DataStructure;
    using System.Collections.Generic;
    using System.Linq;
    public class StudioRepository : GenericRepository<Studio>
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
        public List<Studio> SearchBy(string queryString)
        {
            return context.Studios.Where(actor => actor.Name.Contains(queryString)).ToList();
        }
        public List<Studio> GetByIDs(List<int> IDs)
        {
            List<Studio> studios = new List<Studio>();
            foreach (int ID in IDs)
            {
                studios.Add(GetByID(ID));
            }
            return studios;
        }
    }
}

