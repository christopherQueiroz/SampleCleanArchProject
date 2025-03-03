using Microsoft.AspNetCore.Mvc;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.Interfaces;

namespace SampleCleanArchProject.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            this._service = productService;
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> Create(ProductDto product)
        {
            await _service.Add(product);

            return Ok(new { messge = "Inserido com sucesso" });
        }

        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> Update(ProductDto product)
        {
            await _service.Update(product);

            return Ok(new { mesage = "Atualizado com sucesso" });
        }

        [HttpGet]
        [Route("get-all-products")]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var response = await _service.GetProducts();

            return response;
        }

        [HttpGet]
        [Route("get-products-by-id")]
        public async Task<ProductDto> Get([FromQuery] int id)
        {
            var response = await _service.GetById(id);

            return response;
        }

        [HttpDelete]
        [Route("remove-products-by-id")]
        public async Task<IActionResult> Remove([FromQuery] int id)
        {
            await _service.Remove(id);

            return Ok(new { message = "Removido com sucesso" });
        }
    }
}