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
        public long? TotalMoney { get; set; }
        public string CreateAt { get; set; }
        public string CustomerAddress { get; set; }
        public string? ShipDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
