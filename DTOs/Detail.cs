using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.DTOs
{
    public class Detail : Models.InvoiceDetail
    {
        public string imageProduct { get; set; }
        public string nameProduct { get; set; }
    }
}
