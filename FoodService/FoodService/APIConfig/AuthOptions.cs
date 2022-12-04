using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FoodService.APIConfig
{
    public class AuthOptions
    {
        public const string ISSUER = "CafeManager";
        public const string AUDIENCE = "CafeAngular";
        const string KEY = "APISECRETSECURITYKEY";
        public const int LIFETIME = 20;
        public static SymmetricSecurityKey GetSymetricKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
