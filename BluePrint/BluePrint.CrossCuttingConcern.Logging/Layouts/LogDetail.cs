namespace BluePrint.CrossCuttingConcern.Logging.Layouts
{
     
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class LogDetail
    {
        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public IEnumerable<LogParameter> Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogDetail"/> class.
        /// </summary>
        public LogDetail()
        {
            this.Parameters = new List<LogParameter>();
        }
    }
}
