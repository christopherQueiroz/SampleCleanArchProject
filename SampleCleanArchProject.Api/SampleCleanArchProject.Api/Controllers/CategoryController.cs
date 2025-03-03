using Microsoft.AspNetCore.Mvc;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.Interfaces;

namespace SampleCleanArchProject.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService category)
        {
            this._service = category;
        }

        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            await _service.Add(category);

            return Ok(new { messge = "Inserido com sucesso" });
        }

        [HttpPost]
        [Route("update-category")]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            await _service.Update(category);

            return Ok(new { mesage = "Atualizado com sucesso" });
        }

        [HttpGet]
        [Route("get-all-categories")]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            var response = await _service.GetCategories();

            return response;
        }

        [HttpGet]
        [Route("get-category-by-id")]
        public async Task<CategoryDto> Get([FromQuery]int id)
        {
            var response = await _service.GetById(id);

            return response;
        }

        [HttpDelete]
        [Route("remove-category-by-id")]
        public async Task<IActionResult> Remove([FromQuery]int id)
        {
            await _service.Remove(id);

            return Ok(new {message="Removido com sucesso"});
        }
    }
}