namespace BluePrint.CrossCuttingConcern.Logging.Helpers
{
    using BluePrint.CrossCuttingConcern.Logging.Layouts;
    using Newtonsoft.Json;
    using NLog;

    /// <summary>
    /// 
    /// </summary>
    public class LoggerService
    {
        /// <summary>
        /// Gets a value indicating whether this instance is information enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is information enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled => this.logger.IsInfoEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugEnabled => this.logger.IsDebugEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarnEnabled => this.logger.IsWarnEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatalEnabled => this.logger.IsFatalEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled => this.logger.IsErrorEnabled;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LoggerService(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Informations the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void Info(LogDetail logMessage)
        {
            if (IsInfoEnabled)
            {
                this.logger.Info("MethodName: {MethodName}, Parameters: {Parameters}", logMessage.MethodName, JsonConvert.SerializeObject(logMessage.Parameters).ToString());
            }
        }

        /// <summary>
        /// Debugs the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                this.logger.Debug(logMessage.ToString());
            }
        }

        /// <summary>
        /// Warns the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                this.logger.Warn(logMessage.ToString());
            }
        }

        /// <summary>
        /// Fatals the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                this.logger.Fatal(logMessage.ToString());
            }
        }

        /// <summary>
        /// Errors the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                this.logger.Error(JsonConvert.SerializeObject(logMessage));
            }
        }
    }
}
