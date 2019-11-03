using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoosterPlanner.Models
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the LastEditBy.
        /// </summary>
        [Display(Name = "Laatst gewijzigd door")]
        [MaxLength(128)]
        [Column(Order = 97)]
        public string LastEditBy { get; set; }

        /// <summary>
        /// Gets or sets the LastEditDate.
        /// </summary>
        [Display(Name = "Laatst gewijzigd op")]
        [Column(TypeName = "datetime2", Order = 98)]
        public DateTime LastEditDate { get; set; }

        /// <summary>
        /// Gets or sets the Rowversion.
        /// </summary>
        [Timestamp]
        [Column(Order = 99)]
        public byte[] RowVersion { get; set; }

        //Constructor
        public Entity()
        {
            this.Id = default(TKey);
        }

        public abstract TKey SetNewKey();
    }
}
