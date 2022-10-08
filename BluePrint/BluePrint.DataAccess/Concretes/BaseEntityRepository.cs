namespace BluePrint.DataAccess.Concretes
{
    using BluePrint.DataAccess.Behaviors;
    using BluePrint.Model.Entities.Behaviors;
    using BluePrint.Model.Entities.Concretes;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="BluePrint.DataAccess.Interface.IEntityRepository{TEntity}" />
    public class BaseEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly TContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntityRepositoryEFCore{TEntity, TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseEntityRepository(TContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
            return entity;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => this.Context.Set<TEntity>().Where(predicate);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TEntity GetById(int id) => this.Context.Set<TEntity>().Find(id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IPagingEntity<TEntity> GetAll()
        {
            var result  = this.Context.Set<TEntity>();
            var rowcount = result.Count();
            return new PagingEntity<TEntity> { Entities = result, TotalEntityCount = rowcount };
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => this.Context.Set<TEntity>().SingleOrDefault(predicate);

        /// <summary>
        /// Pagings the specified page number.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public IPagingEntity<TEntity> Paging(int pageNumber, int pageSize)
        {
            var rowcount = this.Context.Set<TEntity>().Count();

            if (pageNumber == 1)
            {
                var result = this.Context.Set<TEntity>()
                             .Take(pageSize)
                             .ToList();
                return new PagingEntity<TEntity> { Entities = result, TotalEntityCount = rowcount };

            }
            else
            {
                var result = this.Context.Set<TEntity>()
                             .Skip(pageNumber * pageSize)
                             .Take(pageSize)
                             .ToList();
                return new PagingEntity<TEntity> { Entities = result, TotalEntityCount = rowcount };
            }
        }
    }
}
