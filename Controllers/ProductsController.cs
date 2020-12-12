using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHangAPI.DTOs;
using QuanLyBanHangAPI.Models;
using QuanLyBanHangAPI.Service.Web.Products;

namespace QuanLyBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductsController(IProduct product)
        {
            this._productService = product;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] Fillter fillterProduct)
        {
            var result = await _productService.GetProduct(fillterProduct);
            return Ok(result);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _productService.GetId(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       /* private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }*/
    }
}
