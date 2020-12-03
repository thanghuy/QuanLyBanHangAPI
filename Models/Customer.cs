using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHangAPI.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Gender { get; set; }
        public byte[] DateOfBirth { get; set; }
        public string Address { get; set; }
        public byte[] JoinDate { get; set; }
        public byte[] IsNew { get; set; }
    }
}
