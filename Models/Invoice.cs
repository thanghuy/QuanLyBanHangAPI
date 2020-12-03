using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Invoice
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? IdCustomer { get; set; }
        public long? IdShipper { get; set; }
        public double? TotalMoney { get; set; }
        public byte[] CreateAt { get; set; }
        public string CustomerAddress { get; set; }
        public byte[] ShipDate { get; set; }
    }
}
