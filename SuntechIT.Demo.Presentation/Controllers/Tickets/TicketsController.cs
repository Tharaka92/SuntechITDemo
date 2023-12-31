﻿using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Tickets.Commands.Create;
using SuntechIT.Demo.Shared.Extensions;

namespace SuntechIT.Demo.Presentation.Controllers.Tickets
{
    [Route("api/v1/ticket")]
    public class TicketsController : ApiController
    {
        public TicketsController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [TranslateResultToActionResult]
        public async Task<Result> CreateTicket([FromBody] CreateTicketRequest model, CancellationToken cancellationToken) 
        {
            var command = new CreateTicketCommand(model.Name, model.Description, model.ProjectId, model.UserId, User.GetCurrentUser());
            return await _sender.Send(command, cancellationToken);
        }
    }
}
