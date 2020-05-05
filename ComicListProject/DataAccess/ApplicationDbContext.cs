using System;
using System.Collections.Generic;
using System.Text;
using DataStructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyComicList.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<FavoriteListItem> FavoriteListItems { get; set; }
        public DbSet<FavoriteService> FavoriteLists { get; set; }

    }
}
