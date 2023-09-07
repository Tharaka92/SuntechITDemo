using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Customers.Create;

namespace SuntechIT.Demo.Presentation.Controllers.Customers
{
    [Route("api/v1/customers")]
    public class CustomersController : ApiController
    {
        public CustomersController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [TranslateResultToActionResult]
        public async Task<Result> CreateCustomer([FromBody] CreateCustomerRequest model, CancellationToken cancellationToken) 
        {
            var command = new CreateCustomerCommand(model.Name);
            return await _sender.Send(command, cancellationToken);
        }
    }
}
