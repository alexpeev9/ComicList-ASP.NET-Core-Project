namespace DataAccess
{
    using DataStructure;
    using System.Data.Entity;

    public partial class ComicDbContext : DbContext
    {
        // MARK: - Class Properties

        /// <summary>
        /// Connection to "Movie" table
        /// </summary>
        public DbSet<Comic> Comics { get; set; }

        /// <summary>
        /// Connection to "Actor" table
        /// </summary>
        public DbSet<Studio> Studios { get; set; }

        /// <summary>
        /// Connection to "Director" table
        /// </summary>
        public DbSet<Origin> Origins { get; set; }

        /// <summary>
        /// Connection to "Genre" table
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        // MARK: - Constructors

        public ComicDbContext()
            : base("name=ComicDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}