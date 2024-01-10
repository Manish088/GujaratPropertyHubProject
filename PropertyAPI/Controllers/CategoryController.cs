using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI.IService;
using PropertyAPI.Service;
using PropertyEntity;
using PropertyEntity.DTO;
using System.Diagnostics.Metrics;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _Mapper;
        public CategoryController(ICategoryService _categoryService, IMapper _Mapper)
        {
            this._categoryService = _categoryService;
            this._Mapper = _Mapper;
        }
        [HttpGet("getAllCategoryDetails")]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var categories = await _categoryService.GetAllCategory();
                var CategoryDTOs=_Mapper.Map<List<CategoryDTO>>(categories);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost("insertCategory")]
        public async Task<IActionResult> InsertCategory([FromBody] CategoryDTO category)
        {
            try
            {
                var categoryDto = _Mapper.Map<Category>(category);
                await _categoryService.InsertCategory(categoryDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("deleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId);
                
                    return NotFound();
                

              
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getCategoryById/{categoryId}")]
        public async Task<ActionResult<Category>> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId);
                var categoryDto=_Mapper.Map<CategoryDTO>(category);
                if(categoryDto == null)
                {
                    return NotFound();
                }
                return Ok(categoryDto);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory( CategoryDTO updateCategory)
        {
            try
            {

                var CategoryUpdateDto = _Mapper.Map<Category>(updateCategory);
                await _categoryService.UpdateCategory(CategoryUpdateDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
