using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoosterPlanner.Models
{
    public class Shift : Entity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public override int Id { get; set; }

        [Column(Order = 1)]
        public TimeSpan StartTime { get; set; }

        [Column(Order = 2)]
        public TimeSpan EndTime { get; set; }

        //Constructor
        public Shift() : base()
        {
        }

        /// <summary>
        /// Generated a new key and sets this as the Id value.
        /// </summary>
        public override int SetNewKey()
        {
            //Database generated.
            return 1;
        }
    }
}
