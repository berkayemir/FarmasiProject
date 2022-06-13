using API.Dal;
using API.Models;
using System.Collections.Generic;

namespace API.Services
{
    public class CartService : ICartService
    {
        private readonly ICartDal _cartDal;
        private IProductDal _productDal;

        public CartService(ICartDal cartDal, IProductDal productDal)
        {
            _cartDal = cartDal;
            _productDal = productDal;
        }

        public void AddToCart(string productId, int quantity)
        {
            _cartDal.AddToCart(productId, quantity);
        }

        public void DeleteCart(string cartId)
        {
            _cartDal.DeleteCart(cartId);
        }

        public List<CartDto> GetAll()
        {
            var retVal = new List<CartDto>();

            var carts = _cartDal.GetAll();
            foreach (var cart in carts)
            {
                var dto = new CartDto()
                {
                    Id = cart.Id,
                    ProductId = cart.ProductId,
                    Quantity = cart.Quantity
                };

                dto.ProductName = _productDal.GetAsync(cart.ProductId).GetAwaiter().GetResult().Name;

                retVal.Add(dto);
            }

            return retVal;
        }

        public void UpdateQuantity(string cartId, int quantity)
        {
            _cartDal.UpdateQuantity(cartId, quantity);
        }
    }
}
