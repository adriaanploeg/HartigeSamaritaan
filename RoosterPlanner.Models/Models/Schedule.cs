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
        public int Day { get; set; }

        //Constructor
        public Schedule()
        {
        }
    }
}
