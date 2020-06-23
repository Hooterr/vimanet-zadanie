using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    /// <summary>
    /// Basic implementation of the <see cref="IRepository{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        #region Protected

        /// <summary>
        /// Application db context
        /// </summary>
        protected readonly AppDataContext Db;

        /// <summary>
        /// DbSet this repository operates on
        /// </summary>
        protected abstract DbSet<TEntity> DbSet { get; }

        #endregion

        #region Constructor

        public BaseRepository(AppDataContext dbContext)
        {
            Db = dbContext;
        }

        #endregion

        #region Implementation

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            // Create a dummy entity
            var entity = new TEntity
            {
                Id = id
            };

            // Set ChangeTracking state to 
            Db.Entry(entity).State = EntityState.Deleted;
        }


        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            // TODO error handling
            Db.SaveChanges();
        } 

        #endregion
    }
}
