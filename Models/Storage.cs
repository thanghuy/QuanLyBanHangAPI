using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Storage
    {
        public long? IdProduct { get; set; }
        public long? Amount { get; set; }
        public byte[] ImportDate { get; set; }
        public byte[] ExportDate { get; set; }
    }
}
