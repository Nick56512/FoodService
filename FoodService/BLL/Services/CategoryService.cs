using AutoMapper;
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
    public class CategoryService : GenericService<Category, CategoryDTO>
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
