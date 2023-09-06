using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SuntechIT.Demo.Presentation.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender _sender;
        protected ApiController(ISender sender)
        {
            _sender = Guard.Against.Null(sender);
        }
    }
}
