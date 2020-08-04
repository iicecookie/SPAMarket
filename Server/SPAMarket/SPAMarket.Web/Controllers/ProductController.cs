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
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create(ProductModel customer)
        {
            var result = await _productService.Create(customer);

            if (result == Guid.Empty)
            {
                return BadRequest("Product's Guid is empty");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(Guid id)
        {
            var order = _productService.Get(id);
    
            if (order == null)
            {
                return BadRequest("Product was not found");
            }
    
            return Ok(order);
        }
    
        [HttpGet]
        public ActionResult<List<ProductModel>> GetAll()
        {
            var collection = _productService.GetAll();
    
            if (collection == null)
            {
                return BadRequest("Products not found");
            }
    
            return Ok(collection);
        }
    
        [HttpPut]
        public async Task<ActionResult> Update(ProductModel model)
        {
            var result = await _productService.Update(model);
    
            if (result == Guid.Empty)
            {
                return BadRequest("Product not updated");
            }
    
            return Ok(result);
        }
    
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);
    
            return Ok();
        }
    }
}