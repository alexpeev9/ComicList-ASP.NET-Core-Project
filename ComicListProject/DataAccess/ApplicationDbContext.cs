using System;
using System.Collections.Generic;
using System.Text;
using DataStructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyComicList.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FavoriteListItem> FavoriteListItems { get; set; }
        public DbSet<FavoriteService> FavoriteLists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() }, 
                new IdentityRole { Name = "Administrator", NormalizedName = "Administrator".ToUpper() });
        }
    }
}
