using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dal
{
    public interface ICartDal
    {
        void AddToCart(string ProductId, int Quantity);
        void UpdateQuantity(string CartId, int Quantity);
        void DeleteCart(string CartId);
        List<Cart> GetAll();
    }
}