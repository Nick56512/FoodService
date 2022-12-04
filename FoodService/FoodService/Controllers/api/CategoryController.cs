using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        CategoryService categoryService;
        public CategoryController(CategoryService service)
        {
            categoryService = service;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return await categoryService.GetAllAsync();
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes =
                JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CategoryDTO>> AddCategory(CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            await categoryService.AddAsync(category);
            return Ok(category);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes =
                JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            await categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
