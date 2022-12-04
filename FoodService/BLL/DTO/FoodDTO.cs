using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class FoodDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Composition { get; set; }
        public string? PhotoName { get; set; }
        public string? PhotoBase64 { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
    }
}
