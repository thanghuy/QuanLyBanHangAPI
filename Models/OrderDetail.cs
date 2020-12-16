using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class OrderDetail
    {
        public long Idd { get; set; }
        public long? IdOrder { get; set; }
        public long? IdProduct { get; set; }
        public long? Amount { get; set; }
        public double? Price { get; set; }
    }
}
