using DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IComicRepository
    {
        IEnumerable<Comic> Comics { get; }
        IEnumerable<Comic> PreferredComics { get; }
    }
}
