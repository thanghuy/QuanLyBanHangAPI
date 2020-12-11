using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHangAPI.Models;

namespace QuanLyBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly dbContext _context;

        public ProductDetailsController(dbContext context)
        {
            _context = context;
        }

        // GET: api/ProductDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetails()
        {
            return Ok(new{ status=true,data = await _context.ProductDetails.ToListAsync() });
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(long id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return Ok(new {status=true,data = productDetail});
        }

        // PUT: api/ProductDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(long id, [FromForm]ProductDetail productDetail)
        {
            if (id != productDetail.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(productDetail).State = EntityState.Modified;

            try
            {
                return Ok(new { status = await _context.SaveChangesAsync()!=0, data = "Thành công" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { status = false, data = "Có lỗi xảy ra" });
                }
            }
        }

        // POST: api/ProductDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductDetail>> PostProductDetail([FromForm]ProductDetail productDetail)
        {
            _context.ProductDetails.Add(productDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductDetailExists(productDetail.IdProduct))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { status = true, data = productDetail });
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDetail>> DeleteProductDetail(long id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            _context.ProductDetails.Remove(productDetail);
            await _context.SaveChangesAsync();

            return productDetail;
        }

        private bool ProductDetailExists(long id)
        {
            return _context.ProductDetails.Any(e => e.IdProduct == id);
        }
    }
}
