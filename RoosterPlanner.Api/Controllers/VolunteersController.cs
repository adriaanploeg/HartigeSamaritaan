using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoosterPlanner.Api.Models;
using RoosterPlanner.Service;

namespace RoosterPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        protected IMapper Mapper { get; set; }
        public IProjectService ProjectService { get; set; }

        public IParticipationService ParticipationService { get; set; }

        public VolunteersController(IMapper mapper, IProjectService projectService, IParticipationService participationService)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            ProjectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            ParticipationService = participationService ?? throw new ArgumentNullException(nameof(participationService));
        }

        [HttpGet("getprojects")]
        public async Task<ActionResult<IEnumerable<ProjectViewModel>>> Get()
        {
            var projects = await ProjectService.GetActiveProjectsAsync();
            return projects.Data.Select(i => Mapper.Map<ProjectViewModel>(i)).ToList();
        }

        [HttpPost("setparticipation/{oid}/{projectId}")]
        public async Task<ActionResult> SetParticipation(Guid oid, Guid projectId)
        {
            await ParticipationService.AddParticipationAsync(oid, projectId);
            return Ok();
        }
    }
}