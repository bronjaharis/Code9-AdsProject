using Code9_AdsProject.Contract.Requests.Categories;
using Code9_AdsProject.Interfaces;
using Code9_AdsProject.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code9_AdsProject.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoryService.GetCategoriesAsync();
        }

        [HttpGet("Categories/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("Categories/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequest updateRequest)
        {
            var oldCategory = await _categoryService.GetCategoryAsync(id);

            if (oldCategory == null)
                return NotFound();

            oldCategory.Name = updateRequest.Name;
            oldCategory.Description = updateRequest.Description;

            var updated = await _categoryService.UpdateCategoryAsync(oldCategory);

            if (updated)
                return Ok(updated);

            return BadRequest();
        }

        [HttpPost("Categories")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest createRequest)
        {
            var categoryToBeCreated = new Category
            {
                Name = createRequest.Name,
                Description = createRequest.Description
            };

            var created  = await _categoryService.CreateCategoryAsync(categoryToBeCreated);

            if(created)
                return CreatedAtAction("GetCategory", new { id = categoryToBeCreated.Id }, categoryToBeCreated);

            return BadRequest();

        }

        [HttpDelete("Categories/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(id);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
