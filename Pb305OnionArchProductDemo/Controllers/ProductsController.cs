using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Application.Interfaces;

namespace Pb305OnionArchProductDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto createProductDto)
        {
            var createdProduct = await _productService.AddProductAsync(createProductDto);

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createProductDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpPost("removeTagsFromProduct")]
        public async Task<IActionResult> RemoveTagsFromProduct([FromBody] RemoveTagsFromProductDto removeTagsFromProductDto)
        {
            await _productService.RemoveTagsFromProductAsync(removeTagsFromProductDto);
            return NoContent();
        }
    }
}
