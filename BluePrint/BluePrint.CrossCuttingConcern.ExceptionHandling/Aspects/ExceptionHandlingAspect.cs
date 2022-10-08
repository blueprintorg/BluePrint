using BluePrint.CrossCuttingConcern.Logging.Helpers;
using BluePrint.CrossCuttingConcern.Logging.Layouts;
using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using BluePrint.CrossCuttingConcern.Utilities.Messages;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;

namespace BluePrint.CrossCuttingConcern.ExceptionHandling.Aspects
{
    public class ExceptionHandlingAspect : MethodInterception
    {
        /// <summary>
        /// The logger type
        /// </summary>
        private readonly Type loggerType;

        /// <summary>
        /// The logger service
        /// </summary>
        private readonly LoggerService loggerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingAspect"/> class.
        /// </summary>
        /// <param name="loggerType">Type of the logger.</param>
        /// <exception cref="Exception"></exception>
        public ExceptionHandlingAspect(Type loggerType)
        {
            if (loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }

            this.loggerType = loggerType;
            this.loggerService = (LoggerService)Activator.CreateInstance(this.loggerType);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            loggerService.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                Parameters = logParameters
            };

            return logDetailWithException;
        }
    }
}
