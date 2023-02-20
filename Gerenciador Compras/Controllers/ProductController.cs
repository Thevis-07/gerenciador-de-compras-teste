using Gerenciador_Compras.Models;
using Gerenciador_Compras.Repositories;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Net.Http.Headers;

namespace Gerenciador_Compras.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository repository)
        {
            _productRepository= repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _productRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts([FromBody] Product product)
        {
            var newProduct = await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productRepository.Get(id);
           
            if (productToDelete! == null)
                return NotFound();

                await _productRepository.Delete(productToDelete.Id);

            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> PutProducts(int id,[FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();
                await _productRepository.Update(product);

                return NoContent();
        }
    }
}
