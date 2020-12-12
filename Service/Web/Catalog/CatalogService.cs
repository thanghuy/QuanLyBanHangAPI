using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Service.Web.Catalog
{
    public class CatalogService : WebSerice, ICatalog
    {
        public CatalogService(dbContext _dbContext) : base(_dbContext)
        {
        }

        public async Task<Object> GetAll()
        {
            var catalog = _dbContext.Catalogs.AsEnumerable<Models.Catalog>();
            return catalog;
        }
    }
}
