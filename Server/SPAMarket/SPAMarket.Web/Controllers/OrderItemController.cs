using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPAMarket.Domain.Contracts;
using SPAMarket.Domain.Contracts.Models;

namespace SPAMarket.Web.Controllers
{
    [ApiController]
    [Route("orderitem")]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create(OrderItemModel orderitem)
        {
            var result = await _orderItemService.Create(orderitem);

            if (result == Guid.Empty)
            {
                return BadRequest("OrderItem's Guid is empty");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItemModel> Get(Guid id)
        {
            var order = _orderItemService.Get(id);

            if (order == null)
            {
                return BadRequest("OrderItem was not found");
            }

            return Ok(order);
        }

        [HttpGet("orderitems/{id}")]
        public ActionResult<List<OrderItemModel>> GetAll(Guid id)
        {
            var collection = _orderItemService.GetAll(id);
       
            if (collection == null)
            {
                return BadRequest("OrderItems not found");
            }
       
            return Ok(collection);
        }
       
        [HttpPost("additem")]
        public async Task<ActionResult<Guid>> AddItem(OrderItemModel orderitem)
        {
            var result = await _orderItemService.AddItem(orderitem.Id);
       
            if (result == Guid.Empty)
            {
                return BadRequest("OrderItem's Guid is empty");
            }
       
            return Ok(result);
        }

        [HttpPost("removeitem")]
        public async Task<ActionResult<Guid>> RemoveItem(OrderItemModel orderitem)
        {
            var result = await _orderItemService.RemoveItem(orderitem.Id);
       
            if (result == Guid.Empty)
            {
                return BadRequest("OrderItem's Guid is empty");
            }
       
            return Ok(result);
        }
       
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _orderItemService.Delete(id);
       
            return Ok();
        }
    }
}