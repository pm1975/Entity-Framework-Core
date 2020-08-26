using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication1.Database
{
    public abstract class BaseRepository<Entity> where Entity : class
    {
        protected WebApplication1DbContext mDbContext;
        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(WebApplication1DbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }

        public void SaveChanges()
        {
            mDbContext.SaveChanges();
        }
    }
}
