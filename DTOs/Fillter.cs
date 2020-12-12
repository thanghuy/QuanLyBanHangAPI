using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.DTOs
{
    public class Fillter
    {
        public int IdCatalog { get; set; } = -1;
        public int page { get; set; } = 1;
        public string key { get; set; } = "";
    }
}
