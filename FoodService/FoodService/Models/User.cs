using Microsoft.AspNetCore.Identity;

namespace FoodService.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
