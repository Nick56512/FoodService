using BLL.DTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderItemService : GenericService<OrderItem, OrderItemDTO>
    {
        public OrderItemService(IRepository<OrderItem> repository) : base(repository)
        {
        }
       
    }
}
