using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Models
{
    public class AspNetIdentityContext:IdentityDbContext<User>
    {
        public AspNetIdentityContext(DbContextOptions<AspNetIdentityContext> opt)
           : base(opt)
        {
            Database.EnsureCreated();
        }
    }
}
