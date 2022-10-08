namespace BluePrint.CrossCuttingConcern.Logging.Aspects
{
    using BluePrint.CrossCuttingConcern.Logging.Helpers;
    using BluePrint.CrossCuttingConcern.Logging.Layouts;
    using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
    using BluePrint.CrossCuttingConcern.Utilities.Messages;
    using Castle.DynamicProxy;
    using Newtonsoft.Json;
    using NLog;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BluePrint.CrossCuttingConcern.Utilities.Interceptors.MethodInterception" />
    public class LogAspect : MethodInterception
    {
        /// <summary>
        /// The logger type
        /// </summary>
        private readonly Type loggerType;

        /// <summary>
        /// The logger service
        /// </summary>
        private LoggerService loggerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogAspect" /> class.
        /// </summary>
        /// <param name="loggerType">Type of the logger.</param>
        /// <exception cref="System.Exception"></exception>
        public LogAspect(Type loggerType)
        {
            if (loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }

            this.loggerType = loggerType;
            this.loggerService = (LoggerService)Activator.CreateInstance(this.loggerType);
        }

        /// <summary>
        /// Called when [before].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected override void OnBefore(IInvocation invocation)
        {
            loggerService.Info(GetLogDetail(invocation));
        }

        /// <summary>
        /// Called when [after].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected override void OnAfter(IInvocation invocation)
        {
            loggerService.Info(GetLogDetail(invocation));
        }

        /// <summary>
        /// Gets the log detail.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns></returns>
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type = invocation.Arguments[i].GetType().Name,
                    Value = invocation.Arguments[i],
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                Parameters = logParameters,
            };

            MappedDiagnosticsContext.Set("MethodName", logDetail.MethodName);
            MappedDiagnosticsContext.Set("Parameters", JsonConvert.SerializeObject(logParameters).ToString());

            return logDetail;
        }
    }
}
