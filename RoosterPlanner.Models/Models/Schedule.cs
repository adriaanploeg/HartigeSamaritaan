using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoosterPlanner.Models
{
    public class Schedule : Entity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public override Guid Id { get; set; }

        [Column(Order = 1)]
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Column(Order = 2)]
        public DateTime Date { get; set; }

        //Constructor
        public Schedule() : base()
        {
        }

        /// <summary>
        /// Generated a new key and sets this as the Id value.
        /// </summary>
        /// <returns></returns>
        public override Guid SetNewKey()
        {
            this.Id = Guid.NewGuid();
            return this.Id;
        }
    }
}
