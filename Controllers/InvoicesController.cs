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
    public class InvoicesController : ControllerBase
    {
        private readonly dbContext _context;

        public InvoicesController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet("all/{idCustomer}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(long idCustomer)
        {
            return await _context.Invoices.Where(x => x.IdCustomer == idCustomer).ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(long id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(long id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostInvoice([FromBody] DTOs.Order invoice)
        {
            //_context.Invoices.Add(invoice);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
            // Console.WriteLine("demo" + invoice.Email + invoice.order_item);
            var ins = new Invoice();
            ins.Name = invoice.Name;
            ins.IdCustomer = invoice.IdCustomer;
            ins.TotalMoney = invoice.TotalMoney;
            ins.CreateAt = invoice.CreateAt;
            ins.CustomerAddress = invoice.CustomerAddress;
            ins.Phone = invoice.Phone;
            ins.Email = invoice.Email;
            _context.Invoices.Add(ins);
            var result = await _context.SaveChangesAsync();
            long id = ins.Id;
            foreach (var item in invoice.order_item)
            {
                var insd = new InvoiceDetail();
                
                insd.IdInvoice = id;
                insd.IdProduct = (long)item.IdProduct;
                insd.Amount = (long)item.Amount;
                insd.Price = (double)item.Price;
                _context.InvoiceDetails.Add(insd);
                await _context.SaveChangesAsync();
            }
            return Ok(new { status = true , data = ins });
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(long id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        private bool InvoiceExists(long id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
