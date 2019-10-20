using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoosterPlanner.Models;

namespace RoosterPlanner.Data.Common
{
    public interface IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>, new()
    {
        /// <summary>
        /// Get the entity with the provided id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The entity that matched the id or <c>null</c> if no match has been found.</returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Get the entity with the provided id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The entity that matched the id or <c>null</c> if no match has been found.</returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Lookup the entity with the provided id's from cache, if not found then retrieve from datastore.
        /// </summary>
        /// <param name="ids">The id's of the entity that are the primary key.</param>
        /// <returns>The entity that matched the id's.</returns>
        TEntity Find(params TKey[] ids);

        /// <summary>
        /// Lookup the entity with the provided id's from cache, if not found then retrieve from datastore.
        /// </summary>
        /// <param name="ids">The id's of the entity that are the primary key.</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(params TKey[] ids);

        /// <summary>
        /// Adds or update the specified entity. This will update the whole object graph.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added or modified entity.</returns>
        /// <exception cref="System.ArgumentNullException">entity</exception>
        //TEntity AddOrUpdate(TEntity entity);
    }
}
