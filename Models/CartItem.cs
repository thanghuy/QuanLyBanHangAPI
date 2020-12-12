using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Models
{
    public class CartItem: Product
    {
        public long IdCustomer{ get; set; }
        public long Amount{ get; set; }
        public long IdCart{ get; set; }
    }
}
