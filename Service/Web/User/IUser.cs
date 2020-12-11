
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyBanHangAPI.Models;

namespace QuanLyBanHangAPI.Service.Web.User
{
    public interface IUser
    {
        Task<Customer> Login(string username,string password);
        Task<Customer> Register(Customer customer);
    }
}
