using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Combo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ListProduct { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double? TotalMoney { get; set; }
        public string Discount { get; set; }
        public double? DiscountMoney { get; set; }
    }
}
