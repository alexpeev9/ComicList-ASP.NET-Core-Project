namespace DataAccess.Repositories
{
    using DataStructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : Model
    {
        private bool disposed = false;

        public readonly ComicDbContext context;
        readonly DbSet<T> entities;

        public GenericRepository(ComicDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public void CreateOrUpdate(T entity)
        {
            DateTime currentDateTime = DateTime.Now;

            // Creating new instance, ID's initial value is 0
            // The ID generate it's value after commiting to database
            if (entity.ID == 0)
            {
                // Set value only before first commit
                entity.CreatedAt = currentDateTime;
            }
            // Set value for each commit
            entity.UpdatedAt = currentDateTime;

            // Add new record in table or update if exists
            entities.AddOrUpdate(entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Delete record from database
        /// </summary>
        /// <param name="id">Object's ID</param>
        public void Delete(int id)
        {
            // Find instance of specific database model type with specific ID
            T entity = entities.Find(id);
            if (entity != null)
            {
                // Remove record from database
                entities.Remove(entity);

                context.SaveChanges();
            }
        }

        public T GetByID(int id)
        {
            return entities.Find(id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(obj: this);
        }

    }
}