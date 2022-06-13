using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICartService
    {
        void AddToCart(string productId, int quantity);
        void UpdateQuantity(string cartId, int quantity);
        void DeleteCart(string cartId);
        List<CartDto> GetAll();
    }
}