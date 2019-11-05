﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoosterPlanner.Models
{
    public class Task : Entity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public override int Id { get; set; }

        [Column(Order = 1)]
        [Required, MaxLength(64)]
        public string Name { get; set; }

        [Column(Order = 2)]
        public DateTime? DeletedDateTime { get; set; }

        public List<ProjectTask> TaskProjects { get; set; }

        //Constructor
        public Task() : base()
        {
            this.TaskProjects = new List<ProjectTask>();
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