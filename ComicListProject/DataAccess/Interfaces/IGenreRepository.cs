﻿using DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
    }
}
