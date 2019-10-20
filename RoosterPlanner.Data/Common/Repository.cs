using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoosterPlanner.Models;

namespace RoosterPlanner.Data.Common
{
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>, new()
    {
        protected virtual DbContext DataContext { get; private set; }
        protected virtual DbSet<TEntity> EntitySet { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="useStateTracking">if set to <c>true</c> the repository will use state tracking.</param>
        public Repository(DbContext dataContext)
        {
            this.DataContext = dataContext ?? throw new ArgumentNullException("dataContext");

            this.EntitySet = DataContext.Set<TEntity>();
            if (EntitySet == null)
                throw new InvalidOperationException($"No entity set found in the context for the type {typeof(TEntity).Name}");
        }

        /// <summary>
        /// Get the entity with the provided id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The entity that matched the id or <c>null</c> if no match has been found.</returns>
        public virtual TEntity Get(TKey id)
        {
            return this.EntitySet.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// Get the entity with the provided id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The entity that matched the id or <c>null</c> if no match has been found.</returns>
        public virtual Task<TEntity> GetAsync(TKey id)
        {
            return this.EntitySet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the entity  by the specified id and returns an anonymous.
        /// </summary>
        /// <param name="ids">The primary keys of the entity.</param>
        /// <returns>The entity that matched the id's.</returns>
        public virtual TEntity Find(params TKey[] ids)
        {
            return this.EntitySet.Find(ids);
        }

        /// <summary>
        /// Lookup the entity with the provided id's from cache, if not found then retrieve from datastore.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>The list of records that matched one of the id's.</returns>
        public virtual async Task<TEntity> FindAsync(params TKey[] ids)
        {
            return await this.EntitySet.FindAsync(ids);
        }
    }
}
