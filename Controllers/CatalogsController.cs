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
    public class CatalogsController : ControllerBase
    {
        private readonly dbContext _context;

        public CatalogsController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Catalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog>>> GetCatalogs()
        {
            return Ok(new { status = true, data = await _context.Catalogs.ToListAsync() });
        }

        // GET: api/Catalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalog>> GetCatalog(long id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);

            if (catalog == null)
            {
                return NotFound();
            }

            return catalog;
        }

        // PUT: api/Catalogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalog(long id, [FromForm] Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Catalogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Catalog>> PostCatalog([FromForm] Catalog catalog)
        {
            _context.Catalogs.Add(catalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog", new { id = catalog.Id }, catalog);
        }

        // DELETE: api/Catalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Catalog>> DeleteCatalog(long id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();

            return catalog;
        }

        private bool CatalogExists(long id)
        {
            return _context.Catalogs.Any(e => e.Id == id);
        }
    }
}
