using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.Interfaces;
using SampleCleanArchProject.Application.IOEntities;

namespace SampleCleanArchProject.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this._service = productService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> Create(ProductRequest product)
        {
            await _service.Add(_mapper.Map<ProductDto>(product));

            return Ok(new { messge = "Inserido com sucesso" });
        }

        [HttpPost]
        [Route("update-product")]
        public async Task<IActionResult> Update(ProductRequest product)
        {
            await _service.Update(_mapper.Map<ProductDto>(product));

            return Ok(new { mesage = "Atualizado com sucesso" });
        }

        [HttpGet]
        [Route("get-all-products")]
        public async Task<IEnumerable<ProductResponse>> Get()
        {
            var response = await _service.GetProducts();

            return _mapper.Map<IEnumerable<ProductResponse>>(response);
        }

        [HttpGet]
        [Route("get-products-by-id")]
        public async Task<ProductResponse> Get([FromQuery] int id)
        {
            var response = await _service.GetById(id);

            return _mapper.Map<ProductResponse>(response);
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