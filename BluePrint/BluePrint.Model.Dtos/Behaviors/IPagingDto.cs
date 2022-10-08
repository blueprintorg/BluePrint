namespace BluePrint.Model.Dtos.Behaviors
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public interface IPagingDto<Q> where Q : IDto
    {
        /// <summary>
        /// Gets or sets the total entity count.
        /// </summary>
        /// <value>
        /// The total entity count.
        /// </value>
        int TotalEntityCount { get; set; }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        IEnumerable<Q> Entities { get; set; }
    }
}
