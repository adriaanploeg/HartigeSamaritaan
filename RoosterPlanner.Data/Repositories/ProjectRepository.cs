using System;
using System.Collections.Generic;
using RoosterPlanner.Data.Common;
using RoosterPlanner.Data.Context;
using RoosterPlanner.Common;
using RoosterPlanner.Models;

namespace RoosterPlanner.Data.Repositories
{
    public interface IProjectRepository : IRepository<Guid, Project>
    {

    }

    public class ProjectRepository : Repository<Guid, Project>, IProjectRepository
    {
        //Constructor
        public ProjectRepository(RoosterPlannerContext dataContext, ILogger logger) : base(dataContext, logger)
        {
        }
    }
}
