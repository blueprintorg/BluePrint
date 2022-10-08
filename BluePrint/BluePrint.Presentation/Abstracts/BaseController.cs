using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace BluePrint.Presentation.Abstracts
{
    public abstract class BaseController : ControllerBase
    {

        protected IComponentContext ComponentContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected BaseController(IComponentContext componentContext)
        {
            this.ComponentContext = componentContext;
        }
    }
}
