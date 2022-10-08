using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using BluePrint.CrossCuttingConcern.Utilities.Messages;
using BluePrint.CrossCuttingConcern.Validation.Helpers;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Linq;

namespace BluePrint.CrossCuttingConcern.Validation.Aspects
{
    public class ValidationAspect : MethodInterception
    {
        /// <summary>
        /// The validator type
        /// </summary>
        private readonly Type validatorType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationAspect" /> class.
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        /// <exception cref="System.Exception"></exception>
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            this.validatorType = validatorType;
        }

        /// <summary>
        /// Called when [before].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(this.validatorType);
            var entityType = this.validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationHelper.Validate(validator, entity);
            }
        }
    }
}
