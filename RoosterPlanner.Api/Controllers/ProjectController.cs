using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoosterPlanner.Api.Models;
using RoosterPlanner.Common;
using RoosterPlanner.Models;
using RoosterPlanner.Models.FilterModels;
using RoosterPlanner.Service;
using RoosterPlanner.Service.DataModels;

namespace RoosterPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMapper mapper = null;
        private readonly IProjectService projectService = null;
        private readonly ILogger logger = null;

        //Constructor
        public ProjectController(IMapper mapper, IProjectService projectService, ILogger logger)
        {
            this.mapper = mapper;
            this.projectService = projectService;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            ProjectDetailsViewModel projectDetailsVm = new ProjectDetailsViewModel();

            try
            {
                TaskResult<Project> result = await this.projectService.GetProjectDetails(id);
                if (result.Succeeded)
                {
                    projectDetailsVm = this.mapper.Map<ProjectDetailsViewModel>(result.Data);
                }
                return Ok(projectDetailsVm);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ProjectController: Error occured.");
                this.Response.Headers.Add("message", ex.Message);
            }
            return NoContent();
        }

        [HttpGet()]
        public async Task<ActionResult<List<ProjectViewModel>>> Search(string name,
            string city,
            DateTime? startDateFrom = null,
            bool? closed = null,
            int offset = 0,
            int pageSize = 20)
        {
            ProjectFilter filter = new ProjectFilter(offset, pageSize);
            filter.Name = name;
            filter.City = city;
            filter.StartDate = startDateFrom;
            filter.Closed = closed;

            List<ProjectViewModel> projectVmList = new List<ProjectViewModel>();

            try
            {
                TaskListResult<Project> result = await this.projectService.SearchProjectsAsync(filter);
                if (result.Succeeded)
                {
                    Request.HttpContext.Response.Headers.Add("totalCount", filter.TotalItemCount.ToString());
                    projectVmList = result.Data.Select(x => this.mapper.Map<ProjectViewModel>(x)).ToList();
                    return Ok(projectVmList);
                }
                else
                {
                    return UnprocessableEntity(result.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ProjectController: Error occured.");
                this.Response.Headers.Add("message", ex.Message);
            }
            return NoContent();
        }
    }
}