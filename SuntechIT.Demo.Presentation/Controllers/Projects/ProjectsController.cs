﻿using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Projects.Commands.Assign;
using SuntechIT.Demo.Application.Projects.Commands.Create;
using SuntechIT.Demo.Application.Projects.Queries.GetProjects;
using SuntechIT.Demo.Shared.Extensions;
using SuntechIT.Demo.Application.Projects.Queries;
using SuntechIT.Demo.Application.Projects.Queries.GetProjectById;
using SuntechIT.Demo.Application.Projects.Commands.Update;

namespace SuntechIT.Demo.Presentation.Controllers.Projects
{
    [Route("api/v1/project")]
    public class ProjectsController : ApiController
    {
        public ProjectsController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [TranslateResultToActionResult]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Result<List<ProjectResponse>>> GetProjects(long? customerId, string? userId, CancellationToken cancellationToken)
        {
            var query = new GetProjectsQuery(customerId, userId, User.GetCurrentUser());
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        [TranslateResultToActionResult]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Result<ProjectResponse>> GetProjectById(long id, CancellationToken cancellationToken)
        {
            var query = new GetProjectByIdQuery(id, User.GetCurrentUser());
            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [TranslateResultToActionResult]
        public async Task<Result> CreateProject([FromBody] CreateProjectRequest model, CancellationToken cancellationToken) 
        {
            var command = new CreateProjectCommand(model.Name, model.CustomerId);
            return await _sender.Send(command, cancellationToken);
        }

        [HttpPost("user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TranslateResultToActionResult]
        public async Task<Result> AssignProject([FromBody] AssignProjectRequest model, CancellationToken cancellationToken)
        {
            var command = new AssignProjectCommand(model.ProjectId, model.UserId, User.GetCurrentUser());
            return await _sender.Send(command, cancellationToken);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [TranslateResultToActionResult]
        public async Task<Result> UpdateProject(long id, [FromBody] UpdateProjectRequest model, CancellationToken cancellationToken)
        {
            var command = new UpdateProjectCommand(id, model.Name, User.GetCurrentUser());
            return await _sender.Send(command, cancellationToken);
        }
    }
}
