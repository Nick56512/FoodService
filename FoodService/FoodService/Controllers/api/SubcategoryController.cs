using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : Controller
    {
        SubcategoryService subcategoryService;
        public SubcategoryController(SubcategoryService service)
        {
            subcategoryService = service;
        }
        [HttpGet]
        public async Task<IEnumerable<SubcategoryDTO>> GetCategories()
        {
            return await subcategoryService.GetAllAsync();
        }
        [HttpGet("{categoryId}")]
        public async Task<IEnumerable<SubcategoryDTO>> GetSubategoriesByCategory(int categoryId)
        {
            return (await subcategoryService.GetAllAsync())
                .Where(x=>x.CategoryId==categoryId);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes =
                JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<SubcategoryDTO>> AddCategory(SubcategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            await subcategoryService.AddAsync(category);
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
            await subcategoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
