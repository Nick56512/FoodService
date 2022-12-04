using BLL.DTO;
using BLL.Services;
using FoodService.Models;
using FoodService.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:Controller
    {
        OrderService orderService;
        OrderItemService orderItemService;
        FoodManager foodService;
        public OrderController(OrderService orderService,OrderItemService orderItemService,FoodManager foodManager)
        {
            this.orderService = orderService;
            this.orderItemService = orderItemService;
            foodService = foodManager;
        }
        [HttpPost]
        public async Task<ActionResult> AddOrder(CreateOrderViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            await orderService.AddAsync(model.Order);
            model.Order.Id = (await orderService.GetAllAsync())
                .Last().Id;
            
            foreach(var item in model.OrderItems)
            {
                item.OrderId = model.Order.Id;
            }
            await orderItemService.AddRangeAsync(model.OrderItems);

            await EmailManager.SendOrderAsync("AdolfHitler", "papych1905@gmail.com", model,foodService);

            return Ok();
        }

    }
}
