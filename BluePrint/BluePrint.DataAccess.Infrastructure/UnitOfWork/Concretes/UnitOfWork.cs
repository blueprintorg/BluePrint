namespace BluePrint.DataAccess.Infrastructure.UnitOfWork.Concretes
{
    using BluePrint.DataAccess.Infrastructure.UnitOfWork.Behaviors;
    using Microsoft.EntityFrameworkCore;
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="BluePrint.DataAccess.Infrastructure.UnitOfWork.Behaviors.IUnitOfWork{TContext}" />
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
         where TContext : DbContext, IDisposable
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public TContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Commits changes on object set to database with transaction.
        /// </summary>
        public void Commit()
        {
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }

    }
}
