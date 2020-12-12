using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangAPI.Service.Web.Catalog;
namespace QuanLyBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalog _catalogService;
        
        public CatalogsController(ICatalog catalog) {
            this._catalogService = catalog;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _catalogService.GetAll();
            return Ok(new { status = true , data = result });
        }
    }
}
