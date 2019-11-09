﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoosterPlanner.Models
{
    public class Category : Entity
    {
        [Column(Order = 1)]
        [Required, MaxLength(10)]
        public string Code { get; set; }

        [Column(Order = 2)]
        [Required, MaxLength(32)]
        public string Name { get; set; }

        //Constructor
        public Category() : this(Guid.Empty)
        {
        }

        //Constructor
        public Category(Guid id) : base(id)
        {
        }
    }
}
