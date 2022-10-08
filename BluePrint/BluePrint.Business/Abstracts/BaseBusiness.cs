namespace BluePrint.Business.Abstracts
{
    using Autofac;
    using AutoMapper;
    using BluePrint.DataAccess.Infrastructure.UnitOfWork.Behaviors;
    using BluePrint.Model.Dtos.Behaviors;
    using BluePrint.Model.Entities.Behaviors;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseBusiness<Q, T,O> where Q : IDto where T : IEntity where O : DbContext
    {
        /// <summary>
        /// Gets the component context.
        /// </summary>
        /// <value>
        /// The component context.
        /// </value>
        protected IComponentContext ComponentContext { get; private set; }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        protected IMapper Mapper { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBusiness{Q, T}"/> class.
        /// </summary>
        /// <param name="componentContext">The component context.</param>
        protected BaseBusiness(IComponentContext componentContext)
        {
            this.ComponentContext = componentContext;
            this.UnitOfWork = this.ComponentContext.Resolve<IUnitOfWork<O>>();
            this.Mapper = this.ComponentContext.Resolve<IMapper>();
        }

    }
}
