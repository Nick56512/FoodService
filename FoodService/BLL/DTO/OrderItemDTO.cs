using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 0;
        public int? FoodId { get; set; }
        public int? OrderId { get; set; }
       
    }
}
