namespace BluePrint.CrossCuttingConcern.Logging.Helpers
{
    using NLog;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BluePrint.CrossCuttingConcern.Logging.Helpers.LoggerService" />
    public class FileLogger : LoggerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        public FileLogger() : base(LogManager.GetLogger("FileLogger"))
        {

        }
    }
}
