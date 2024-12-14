using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class CartService
    {
        private readonly CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddCart(Cart cart)
        {
            _cartRepository.AddCart(cart);
        }

        public void AddOrUpdateCart(Cart cart)
        {
            _cartRepository.AddOrUpdateCart(cart);
        }


        public List<Cart> GetAllCartItemsByUser(int userId)
        {
            return _cartRepository.GetCartItemsByUser(userId);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        } 
        

        public void DeleteCart(int cartId)
        {
            _cartRepository.DeleteCart(cartId);
        }

        public void DeleteCartByUserId(int userId)
        {
            _cartRepository.DeleteCartByUserId(userId);
        }
    }
}