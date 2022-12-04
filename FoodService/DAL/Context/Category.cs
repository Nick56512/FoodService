using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Subcategory>? Subcategories { get; set; }
    }
}
