using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<List<CartDto>> GetAll()
        {
            var list = _cartService.GetAll();
            if (list != null)
            {
                return list;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddToCart(CreateCartDto cartDto)
        {
            _cartService.AddToCart(cartDto.ProductId, cartDto.Quantity);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateQuantity(UpdateCartDto updateCartDto)
        {
            _cartService.UpdateQuantity(updateCartDto.CartId, updateCartDto.Quantity);

            return Ok();
        }

        [HttpDelete("{cartId}")]
        public ActionResult<List<CartDto>> DeleteCart(string cartId)
        {
            _cartService.DeleteCart(cartId);

            return Ok();
        }
    }
}
