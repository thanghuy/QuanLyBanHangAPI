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
    public class StoragesController : ControllerBase
    {
        private readonly dbContext _context;

        public StoragesController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> GetStorages()
        {
            return Ok(new {status=true,data= await _context.Storages.ToListAsync()});
        }

        // GET: api/Storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetStorage(long id)
        {
            var storage = await _context.Storages.FindAsync(id);

            if (storage == null)
            {
                return NotFound();
            }

            return Ok(new { status = true,data = storage });
        }

        // PUT: api/Storages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage(long id, [FromForm]Storage storage)
        {
            if (id != storage.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(storage).State = EntityState.Modified;

            try
            {
                return Ok(new { status = await _context.SaveChangesAsync() != 0, data = "Cập nhật thành công" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { status = false, data = "Cập nhật thất bại" });
                }
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStorage(long id, [FromForm] Storage storage)
        {
            if (id != storage.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(storage).State = EntityState.Modified;

            try
            {
                return Ok(new { status = await _context.SaveChangesAsync() != 0, data = "Cập nhật thành công" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { status = false, data = "Cập nhật thất bại" });
                }
            }
        }

        // POST: api/Storages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Storage>> PostStorage([FromForm]Storage storage)
        {
            _context.Storages.Add(storage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StorageExists(storage.IdProduct))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {status=true,data = CreatedAtAction("GetStorage", new { id = storage.IdProduct }, storage) });
        }

        // DELETE: api/Storages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Storage>> DeleteStorage(long id)
        {
            var storage = await _context.Storages.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }

            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();

            return storage;
        }

        private bool StorageExists(long id)
        {
            return _context.Storages.Any(e => e.IdProduct == id);
        }
    }
}
