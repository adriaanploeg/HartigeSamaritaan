using System;

namespace RoosterPlanner.Models
{
    public interface IEntity<TKey> where TKey : struct
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

        /// <summary>
        /// Generates or set a new key for this entity.
        /// </summary>
        /// <returns></returns>
        TKey SetNewKey();
    }
}
