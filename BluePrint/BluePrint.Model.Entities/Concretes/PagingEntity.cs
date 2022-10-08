namespace BluePrint.Model.Entities.Concretes
{
    using System.Collections.Generic;
    using Entities.Behaviors;

    public class PagingEntity<T> : IPagingEntity<T> where T : IEntity
    {
        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        public IEnumerable<T> Entities { get; set; }

        /// <summary>
        /// Gets or sets the total entity count.
        /// </summary>
        /// <value>
        /// The total entity count.
        /// </value>
        public int TotalEntityCount { get; set; }
    }
}

