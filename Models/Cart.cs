using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Cart
    {
        public long IdCustomer { get; set; }
        public long IdProduct { get; set; }
        public long Amount { get; set; }
        public long Id { get; set; }
    }
}
