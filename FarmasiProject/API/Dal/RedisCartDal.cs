using API.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Dal
{
    public class RedisCartDal : ICartDal
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisCartDal(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void AddToCart(string productId, int quantity)
        {
            var newCart = new Cart()
            {
                ProductId = productId,
                Quantity = quantity
            };

            var db = _redis.GetDatabase();
            var serialCart = JsonSerializer.Serialize(newCart);

            db.HashSet("hashcart", new HashEntry[] { new HashEntry(newCart.Id, serialCart) });
        }

        public void DeleteCart(string CartId)
        {
            var db = _redis.GetDatabase();
            db.HashDelete("hashcart", CartId);
        }

        public List<Cart> GetAll()
        {
            var db = _redis.GetDatabase();
            var completeSet = db.HashGetAll("hashcart");

            if (completeSet.Length > 0)
            {
                var obj = Array.ConvertAll(completeSet, val => JsonSerializer.Deserialize<Cart>(val.Value)).ToList();
                return obj;
            }

            return null;
        }

        public void UpdateQuantity(string cartId, int quantity)
        {
            var cart = GetCart(cartId);
            if (cart == null) return;

            cart.Quantity = quantity;

            var db = _redis.GetDatabase();
            var serialCart = JsonSerializer.Serialize(cart);
            db.HashSet("hashcart", new HashEntry[] { new HashEntry(cart.Id, serialCart) });
        }

        private Cart GetCart(string CartId)
        {
            var db = _redis.GetDatabase();
            var cart = db.HashGet("hashcart", CartId);

            if (!string.IsNullOrEmpty(cart))
            {
                return JsonSerializer.Deserialize<Cart>(cart);
            }

            return null;
        }
    }
}
