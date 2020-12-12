using QuanLyBanHangAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Service.Web
{
    public class WebSerice
    {
        public readonly dbContext _dbContext;
        public WebSerice(dbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
    }
}
