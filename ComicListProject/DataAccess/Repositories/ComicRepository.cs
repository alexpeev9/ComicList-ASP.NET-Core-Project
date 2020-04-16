

namespace DataAccess.Repositories
{
    using DataStructure;
    using System.Collections.Generic;
    using System.Linq;

    class ComicRepository : GenericRepository<Comic>
    {
        public ComicRepository(ComicDbContext context) : base(context) { }
        public List<Comic> GetComisByPopularity(byte volume)
        {
            return this.context.Comics.Where(x => x.Volumes > volume).ToList();
        }
    }
}
