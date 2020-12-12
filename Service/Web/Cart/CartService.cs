using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.Service.Web.Cart
{
    public class CartService : WebSerice, ICart
    {
        public CartService(dbContext _dbContext) : base(_dbContext)
        {
        }

        public async Task<List<CartItem>> GetCart(long idCustomer)
        {

            var result = _dbContext.Carts.Where(x => x.IdCustomer == idCustomer).Join(
                _dbContext.Products,
                ca => ca.IdProduct,
                p => p.Id,
                (ca, p) => new { ca, p }
                ).Select(cp => new Models.CartItem()
                {
                    IdCart = cp.ca.Id,
                    IdCustomer = cp.ca.IdCustomer,
                    Name = cp.p.Name,
                    Amount = cp.ca.Amount,
                    Id = cp.p.Id,
                    Image = cp.p.Image,
                    Price = cp.p.Price * cp.ca.Amount,
                    IdCatalog = cp.p.IdCatalog
                }).ToList();
            /*return carts;
            var result = _dbContext.Carts.Where(c => c.IdCustomer == idCustomer).Select(c => new Models.CartItem()
            {
                IdCart = c.Id
            }).ToList();*/
            return result;
        }

        public async Task<bool> AddToCart(Models.Cart cart)
        {

            var cart_item = _dbContext.Carts.AsEnumerable<Models.Cart>();
            var _cart = cart_item.Where(x => x.IdProduct == cart.IdProduct).FirstOrDefault();
            if(_cart == null)
            {
                _dbContext.Add(cart);
            }
            else
            {
                _cart.Amount += cart.Amount;
            }
            //
            return await _dbContext.SaveChangesAsync() != 0;
            //return true;
        }

        public async Task<bool> Delete(long idCart)
        {
            var cart_item = await _dbContext.Carts.FindAsync(idCart);
            _dbContext.Carts.Remove(cart_item);
            return await _dbContext.SaveChangesAsync() != 0;
        }

        

        public async Task<bool> Update(long idCart, Models.Cart cart)
        {
            var cart_item = _dbContext.Carts.Where(x => x.Id == idCart).FirstOrDefault();
            cart_item.Amount = cart.Amount;
            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
