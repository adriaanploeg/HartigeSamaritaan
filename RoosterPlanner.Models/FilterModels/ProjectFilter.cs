﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RoosterPlanner.Models.FilterModels
{
    public class ProjectFilter : EntityFilterBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the StartDate.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the locatie.
        /// </summary>
        public bool? Closed { get; set; }

        /// <summary>
        /// Get or sets the offset for retrieving records.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Get or sets the amount of records to retrieve.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Get or sets the total count of records that apply the filter.
        /// </summary>
        public int TotalItemCount { get; set; }
        #endregion

        //Constructor
        public ProjectFilter() : base()
        {
            this.Sort = new string[] { "Name", "ASC" };
            this.Offset = 0;
            this.PageSize = 0;
        }

        //Constructor - Overload
        public ProjectFilter(int offset, int pageSize) : base()
        {
            this.Sort = new string[] { "Name", "ASC" };
            this.Offset = offset;
            this.PageSize = 20;
            if (pageSize > 0 && pageSize < 1000)
                this.PageSize = pageSize;
        }
    }
}
