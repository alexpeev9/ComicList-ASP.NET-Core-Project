namespace DataAccess
{
    using DataStructure;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public partial class ComicDbContext : DbContext
    {
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public ComicDbContext()
            : base("MyConnectionString")
        {
        }

    }
}