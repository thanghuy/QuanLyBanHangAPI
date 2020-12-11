using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.DTOs
{
    public class Pagination
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 16;
    }
}
