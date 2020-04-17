

namespace DataAccess.Repositories
{
    using DataStructure;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class ComicRepository : GenericRepository<Comic>
    {
        public ComicRepository(ComicDbContext context) : base(context) { }
        public override void CreateOrUpdate(Comic entity)
        {
            DateTime currentDateTime = DateTime.Now;

            // Creating new instance, ID's initial value is 0
            // The ID generate it's value after commiting to database
            if (entity.ID == 0)
            {
                // Set value only before first commit
                entity.CreatedAt = currentDateTime;
                List<int> studioIDs = new List<int>();
                foreach (Studio studio in entity.Studios)
                    studioIDs.Add(studio.ID);
                entity.Studios.Clear();
                foreach (int ID in studioIDs)
                    entity.Studios.Add(context.Studios.Find(ID));
            }
            else
            {
                Comic row = GetByID(entity.ID);
                entity.CreatedAt = row.CreatedAt;
                if (row.Origin != entity.Origin)
                    row.Origin = entity.Origin;
                //if (row.Genre != entity.Genre)
                //    row.Genre = entity.Genre;
                row.Studios.Clear();
                foreach (Studio studio in entity.Studios)
                    row.Studios.Add(context.Studios.Find(studio.ID));
            }
            // Set value for each commit
            entity.UpdatedAt = currentDateTime;

            // Add new record in table or update if exists
            context.Comics.AddOrUpdate(entity);
            context.SaveChanges();
        }
        public List<Comic> GetComisByPopularity(byte volume)
        {
            return this.context.Comics.Where(x => x.Volumes > volume).ToList();
        }
        public List<Comic> SearchBy(string queryString)
        {
            return this.context.Comics.Where(comic => comic.Title.Contains(queryString)).ToList();
        }
    }
}