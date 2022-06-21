using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories is null) return NotFound("Categories not found");

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto is null) return NotFound("Category not found");

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto is null) return BadRequest("Invalid Data");

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();
            if (categoryDto is null) return NotFound("Category not found");

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto is null) return NotFound("Category not found");

            await _categoryService.Remove(id);

            return Ok(categoryDto);
        }
    }
}
