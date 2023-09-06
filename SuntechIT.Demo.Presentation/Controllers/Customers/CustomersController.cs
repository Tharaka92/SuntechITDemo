using MediatR;
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
        public async Task<IActionResult> CreateCustomer() 
        {
            var command = new CreateCustomerCommand("Tharaka");
            await _sender.Send(command);

            return Ok();
        }
    }
}
