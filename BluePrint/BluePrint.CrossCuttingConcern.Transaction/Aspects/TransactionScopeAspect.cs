using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using Castle.DynamicProxy;
using System.Transactions;

namespace BluePrint.CrossCuttingConcern.Transaction.Aspects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BluePrint.CrossCuttingConcern.Utilities.Interceptors.MethodInterception" />
    public class TransactionScopeAspect : MethodInterception
    {
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}