using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca todos os produtos cadastrados.
        /// </summary>
        /// <returns>Lista de produtos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        /// <summary>
        /// Busca um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Produto encontrado ou NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="product">Dados do produto.</param>
        /// <returns>Produto criado.</returns>
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var created = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <param name="product">Novos dados do produto.</param>
        /// <returns>Produto atualizado ou NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
            var updated = await _service.UpdateAsync(id, product);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// Remove um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Mensagem de sucesso ou NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}