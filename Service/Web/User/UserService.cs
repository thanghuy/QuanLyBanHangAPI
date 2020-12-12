using QuanLyBanHangAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Service.Web.User
{
    public class UserService : WebSerice, IUser
    {
        public UserService(dbContext _dbContext) : base(_dbContext)
        {
        }

        public async Task<Customer> Login(string username, string password)
        {
            var user = _dbContext.Customers.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

            if(user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<Customer> Register(Customer customer)
        {
            var user = _dbContext.Customers.Where(x => x.Username == customer.Username).FirstOrDefault();
            if(user != null)
            {
                return null;
            }
            else
            {
                _dbContext.Add(customer);
            }
            int isUser = await _dbContext.SaveChangesAsync();
            if (isUser == 0)
            {
                return null;
            }
            return customer;
        }
    }
}
