
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.DTO;
using System.Linq;
using FoodService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FoodService.Models.ViewModels;

namespace FoodService.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        FoodManager foodService;
        public FoodController(FoodManager foodService)
        {
            this.foodService = foodService;
        }
        [HttpGet("foodCount/{CategoryId}")]
        public async Task<int> GetFoodCountInCategory(int CategoryId)
        {
            int count = (await foodService.GetAllAsync())
                .Where(x => x.CategoryId == CategoryId)
                .Count();
            return count;
        }
        [HttpGet("{CategoryId}/{PageSize}/{PageNumber}")]
        public async Task<IEnumerable<FoodDTO>> GetFoodByCategory(int CategoryId,int PageSize,int PageNumber)
        {
            IEnumerable<FoodDTO> foods = (await foodService.GetAllAsync())
                .Where(x => x.CategoryId == CategoryId)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .Reverse();
            return foods;
        }
        [HttpGet("{SubcategoryId}")]
        public async Task<IEnumerable<FoodDTO>> GetFoodBySubcategory(int SubcategoryId)
        {
            IEnumerable<FoodDTO> foods = (await foodService.GetAllAsync())
                .Where(x => x.SubcategoryId == SubcategoryId);
            return foods;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes =
            JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<FoodDTO>> AddFood(FoodDTO newFood)
        {                          
            if (newFood == null)
            {
                return BadRequest();
            }
           
            await foodService.AddAsync(newFood);
            return Ok(newFood);
        }
        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes =
                JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteFood(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            await foodService.DeleteAsync(Id);
            return Ok();
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes =
                JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
        public async Task<ActionResult> UpdateFood(FoodDTO food)
        {   //???????
            if (food == null)
            {
                return BadRequest();
            }
            await foodService.UpdateAsync(food);
            return Ok();
        }
        [HttpGet("details/{id}")]
        public async Task<ActionResult> GetFood(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return Json(await foodService.GetAsync(id));
        }
    }
}
