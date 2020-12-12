using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Storage
    {
        public long IdProduct { get; set; }
        public long? Amount { get; set; }
        public string ImportDate { get; set; }
        public string ExportDate { get; set; }
    }
}
