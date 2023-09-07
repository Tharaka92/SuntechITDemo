using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Projects.Commands.Create;

namespace SuntechIT.Demo.Presentation.Controllers.Projects
{
    [Route("api/v1/projects")]
    public class ProjectsController : ApiController
    {
        public ProjectsController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [TranslateResultToActionResult]
        public async Task<Result> CreateProject([FromBody] CreateProjectRequest model, CancellationToken cancellationToken) 
        {
            var command = new CreateProjectCommand(model.Name, model.CustomerId);
            return await _sender.Send(command, cancellationToken);
        }
    }
}
