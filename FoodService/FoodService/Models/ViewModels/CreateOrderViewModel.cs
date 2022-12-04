using BLL.DTO;

namespace FoodService.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        public OrderDTO Order { get; set; }
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
    }
}
