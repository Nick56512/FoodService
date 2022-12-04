using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? NumberPhone { get; set; }
        public double TotalPrice { get; set; }
        public string? Address { get; set; }
        public string? Comment { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }

    }
}
