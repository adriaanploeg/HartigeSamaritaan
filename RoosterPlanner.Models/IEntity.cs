using System;

namespace RoosterPlanner.Models
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the LastEditBy.
        /// </summary>
        string LastEditBy { get; set; }

        /// <summary>
        /// Gets or sets the LastEditDate.
        /// </summary>
        DateTime LastEditDate { get; set; }

        /// <summary>
        /// Gets or sets the Rowversion.
        /// </summary>
        byte[] RowVersion { get; set; }
    }
}
