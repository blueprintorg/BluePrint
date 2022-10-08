namespace BluePrint.CrossCuttingConcern.Logging.Helpers
{
    using NLog;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BluePrint.CrossCuttingConcern.Logging.Helpers.LoggerService" />
    public class DatabaseLogger : LoggerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseLogger" /> class.
        /// </summary>
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
