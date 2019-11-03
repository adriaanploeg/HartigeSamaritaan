using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoosterPlanner.Models
{
    [Serializable]
    public class Project : Entity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public override Guid Id { get; set; }

        [Column(Order = 1)]
        [Required, MaxLength(64)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Closed { get; set; }

        public List<Task> Tasks { get; set; }

        //Constructor
        public Project() : base()
        {
            this.Tasks = new List<Task>();
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
