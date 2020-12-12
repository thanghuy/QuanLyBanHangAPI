using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHangAPI.Models;
using QuanLyBanHangAPI.Service.Web.Cart;

namespace QuanLyBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICart _cartService;
        public CartsController(dbContext context,ICart cart)
        {
            _cartService = cart;
        }
        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCart(long id)
        {
            var result = await _cartService.GetCart(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok( new { status = true, data = result });
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(long id, Cart cart)
        {
            bool result = await _cartService.Update(id, cart);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(new { status = true } );
        }

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            var result = await _cartService.AddToCart(cart);

            return Ok(new { status = result });
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DeleteCart(long id)
        {
            var result = await _cartService.Delete(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok( new { status = result } );
        }
    }
}
