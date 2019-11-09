﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RoosterPlanner.Api.Models
{
    public class ProjectDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PictureUri { get; set; }
        public string WebsiteUrl { get; set; }
        public bool Closed { get; set; }
        public List<RoosterPlanner.Models.Task> Tasks { get; set; }

        //Constructor
        public ProjectDetailsViewModel()
        {
            this.Tasks = new List<RoosterPlanner.Models.Task>();
        }
    }
}
