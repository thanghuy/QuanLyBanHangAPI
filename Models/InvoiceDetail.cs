using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class InvoiceDetail
    {
        public long IdInvoice { get; set; }
        public long IdProduct { get; set; }
        public long Amount { get; set; }
        public double Price { get; set; }
        public long Idd { get; set; }
    }
}
