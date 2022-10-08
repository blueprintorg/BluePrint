namespace BluePrint.Model.Entities.Behaviors
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagingEntity<T> where T : IEntity
    {
        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        IEnumerable<T> Entities { get; set; }

        /// <summary>
        /// Gets or sets the total entity count.
        /// </summary>
        /// <value>
        /// The total entity count.
        /// </value>
        int TotalEntityCount { get; set; }

    }
}
