namespace BluePrint.Model.Dtos.Concretes
{
    using BluePrint.Model.Dtos.Behaviors;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    /// <seealso cref="BluePrint.Model.Dtos.Behaviors.IPagingDto{Q}" />
    public class PagingDto<Q> : IPagingDto<Q> where Q : IDto
    {
        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        public IEnumerable<Q> Entities { get; set; }

        /// <summary>
        /// Gets or sets the total entity count.
        /// </summary>
        /// <value>
        /// The total entity count.
        /// </value>
        public int TotalEntityCount { get; set; }
    }
}
