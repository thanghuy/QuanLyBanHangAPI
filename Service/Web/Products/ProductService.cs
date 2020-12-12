using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangAPI.DTOs;
using QuanLyBanHangAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Service.Web.Products
{
    public class ProductService : WebSerice, IProduct
    {
        public ProductService(dbContext _dbContext) : base(_dbContext)
        {
        }

        public async Task<Object> GetProduct(Fillter fillter)
        {
   
            var product = _dbContext.Products.AsEnumerable<Product>();
            
            if(fillter.IdCatalog != -1)
            {
                product = product.Where(p => p.IdCatalog == fillter.IdCatalog);
            }
            if(fillter.key != "")
            {
                product = product.Where(p => p.Name.ToLower().Contains(fillter.key));
            }
            return PaginatedList<Product>.Create(product, fillter.page, 8);
        }

        public async Task<ActionResult<Product>> GetId(long id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            return product;
        }
    }
}
