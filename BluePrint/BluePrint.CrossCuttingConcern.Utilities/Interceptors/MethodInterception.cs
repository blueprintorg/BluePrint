namespace BluePrint.CrossCuttingConcern.Utilities.Interceptors
{
    using Castle.DynamicProxy;
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BluePrint.CrossCuttingConcern.Utilities.Interceptors.MethodInterceptionBaseAttribute" />
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        /// <summary>
        /// Called when [before].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected virtual void OnBefore(IInvocation invocation) { }

        /// <summary>
        /// Called when [after].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected virtual void OnAfter(IInvocation invocation) { }

        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="e">The e.</param>
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }

        /// <summary>
        /// Called when [success].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected virtual void OnSuccess(IInvocation invocation) { }

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
