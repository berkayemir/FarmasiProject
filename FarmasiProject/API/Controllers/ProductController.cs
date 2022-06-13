using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var product = await _productService.GetAsync();

            return product;
        }

        [HttpGet("{id:length(24)}", Name = "GetById")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            var product = await _productService.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            var product = new Product() { Name = productDto.Name };
            await _productService.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, productDto);
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, UpdateProductDto updatedProduct)
        {
            var product = await _productService.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;

            await _productService.UpdateAsync(id, product);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _productService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _productService.RemoveAsync(id);

            return NoContent();
        }
    }
}

