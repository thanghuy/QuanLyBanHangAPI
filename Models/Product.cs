using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? IdCatalog { get; set; }
        public long? Amount { get; set; }
        public double? Price { get; set; }
    }
}
