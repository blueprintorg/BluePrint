namespace BluePrint.DataAccess.Infrastructure.UnitOfWork.Behaviors
{
    using Microsoft.EntityFrameworkCore;
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits changes on object set to database with transaction.
        /// </summary>
        void Commit();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork<out TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
