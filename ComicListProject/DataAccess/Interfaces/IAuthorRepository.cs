using DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }
    }
}
