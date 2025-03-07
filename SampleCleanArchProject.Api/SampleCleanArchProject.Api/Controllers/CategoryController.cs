using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.Interfaces;
using SampleCleanArchProject.Application.IOEntities;
using System.Collections.Generic;

namespace SampleCleanArchProject.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService category, IMapper mapper)
        {
            this._service = category;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> Create(CategoryRequest category)
        {
            await _service.Add(_mapper.Map<CategoryDto>(category));

            return Ok(new { messge = "Inserido com sucesso" });
        }

        [HttpPost]
        [Route("update-category")]
        public async Task<IActionResult> Update(CategoryRequest category)
        {
            await _service.Update(_mapper.Map<CategoryDto>(category));

            return Ok(new { mesage = "Atualizado com sucesso" });
        }

        [HttpGet]
        [Route("get-all-categories")]
        public async Task<IEnumerable<CategoryResponse>> Get()
        {
            var response = await _service.GetCategories();

            return _mapper.Map<IEnumerable<CategoryResponse>>(response);
        }

        [HttpGet]
        [Route("get-category-by-id")]
        public async Task<CategoryResponse> Get([FromQuery]int id)
        {
            var response = await _service.GetById(id);

            return _mapper.Map<CategoryResponse>(response);
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