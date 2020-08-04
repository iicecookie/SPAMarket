using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPAMarket.Domain.Contracts;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Web.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create(CustomerModel customer)
        {
            var result = await _customerService.Create(customer);

            if (result == Guid.Empty)
            {
                return BadRequest("Customer's Guid is empty");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderModel> Get(Guid id)
        {
            var order = _customerService.Get(id);

            if (order == null)
            {
                return BadRequest("Customer was not found");
            }

            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CustomerModel model)
        {
            var result = await _customerService.Update(model);

            if (result == Guid.Empty)
            {
                return BadRequest("Customer not updated");
            }

            return Ok(result);
        }
    }
}