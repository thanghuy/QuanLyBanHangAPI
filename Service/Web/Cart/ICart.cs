using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuanLyBanHangAPI.Service.Web.Cart
{
    public interface ICart
    {
        Task<List<Models.CartItem>> GetCart(long idCustomer);
        public Task<bool> AddToCart(Models.Cart cart);
        Task<bool> Delete(long idCart);
        Task<bool> Update(long idCart, Models.Cart cart);
    }
}
