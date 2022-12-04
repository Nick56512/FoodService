using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SubcategoryDTO
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
