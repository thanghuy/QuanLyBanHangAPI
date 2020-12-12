using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangAPI.Models;
namespace QuanLyBanHangAPI.Service.Web.Products
{
    public interface IProduct
    {
        Task<Object> GetProduct(DTOs.Fillter fillter);
        Task<ActionResult<Product>> GetId(long id);

    }
}
