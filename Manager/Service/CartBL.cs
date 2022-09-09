using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public CartModel AddCart(CartModel cart, int UserId)
        {
            try
            {
                return this.cartRL.AddCart(cart, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CartModel UpdateCart(int CartId, CartModel cart, int UserId)
        {
            try
            {
                return this.cartRL.UpdateCart(CartId, cart, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string RemoveCart(int CartId)
        {
            try
            {
                return this.cartRL.RemoveCart(CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CartModel> GetAllCart(int UserId)
        {
            try
            {
                return this.cartRL.GetAllCart(UserId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
