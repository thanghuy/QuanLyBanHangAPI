using QuanLyBanHangAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.DTOs
{
    public class Order : Invoice
    {
        public List<OrderDetail> order_item { get; set; }
    }
}
