using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Interface for building a repository
    /// </summary>
    /// <typeparam name="TEntity">Type of entity this repository operates on</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Adds a new entity to the repository
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        void Add(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository
        /// </summary>
        /// <param name="entity">The entity to be deleted</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository by id
        /// </summary>
        /// <param name="id">Id of the entity to be deleted</param>
        void Delete(int id);

        /// <summary>
        /// Gets an entity by it's id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>The entity</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Gets all entities from the repository
        /// </summary>
        /// <returns>All entities in the repository</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Saves changes to the database
        /// </summary>
        void SaveChanges();

    }
}
