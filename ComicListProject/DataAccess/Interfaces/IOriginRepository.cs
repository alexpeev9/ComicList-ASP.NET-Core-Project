using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOriginRepository
    {
       IEnumerable<Origin> Origins { get;}
    }
}
