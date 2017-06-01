using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DataAccess
{
    /// <summary>
    ///  This is an Abstract Class for the Basic Database requests.
    /// </summary>
    public abstract class AbstractRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// The context
        /// </summary>
        protected readonly TrainContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected AbstractRepository(TrainContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }

        /// <summary>
        /// Gets an entity by its id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Lists all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> All()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }

}
