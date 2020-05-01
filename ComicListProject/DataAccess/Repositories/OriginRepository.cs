using DataAccess.Interfaces;
using DataStructure;
using MyComicList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Repositories
{
    public class OriginRepository : IOriginRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public OriginRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Origin> Origins => _appDbContext.Origins;
    }
}
