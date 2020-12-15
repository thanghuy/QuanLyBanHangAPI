using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangAPI.Models;
namespace QuanLyBanHangAPI.Service.Web.Order
{
    public interface IOrder
    {
        Task<bool> AddOrder();

    }
}
