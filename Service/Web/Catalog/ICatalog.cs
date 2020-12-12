using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Service.Web.Catalog
{
    public interface ICatalog
    {
        public Task<object> GetAll();
    }
}
