using FoodService.Models.ViewModels;

namespace FoodService.Models
{
    public class ConfirmRegistrationModel
    {
        public static int ConfirmCode { get; set; }
        public static User NewUser{get;set;}
        public static string Password { get; set; }
    }
}
