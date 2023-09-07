﻿using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuntechIT.Demo.Application.Customers.Create;
using SuntechIT.Demo.Presentation.Models;

namespace SuntechIT.Demo.Presentation.Controllers.Customers
{
    [Route("api/v1/customers")]
    public class CustomersController : ApiController
    {
        public CustomersController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        [TranslateResultToActionResult]
        public async Task<Result> CreateCustomer([FromBody] CreateCustomerVM model) 
        {
            var command = new CreateCustomerCommand(model.Name);
            return await _sender.Send(command);
        }
    }
}
