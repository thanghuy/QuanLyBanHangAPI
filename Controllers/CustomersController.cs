using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHangAPI.Models;
using QuanLyBanHangAPI.Service.Web.User;

namespace QuanLyBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUser userService;

        public CustomersController(dbContext context,IUser user)
        {
            userService = user;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Customer>> Login(Customer customer)
        {
            var user = await userService.Login(customer.Username, customer.Password);
            if (user == null)
            {
                return Ok(new { status = false });
            }
            return Ok(new { status = true, data = user });
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Customer>> Register(Customer customer)
        {
            var user = await userService.Register(customer);
            if (user == null)
            {
                return Ok(new { status = false });
            }
            return Ok(new { status = true, data = user });
        }

    }
}
