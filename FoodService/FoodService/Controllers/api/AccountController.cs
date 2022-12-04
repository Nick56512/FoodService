using FoodService.APIConfig;
using FoodService.Models;
using FoodService.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace FoodService.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,RoleManager<IdentityRole>roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        private ActionResult GetToken(User user)
        {
            var timeNow = DateTime.Now;
            var token = new JwtSecurityToken
            (
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: timeNow,
                claims: User.Claims,
                expires: timeNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymetricKey(), SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
            var roles = userManager.GetRolesAsync(user);
            var response = new
            {
                access_token = encodedJwt,
                Email = user.Email,
                Name = user.FirstName,
                Lastname = user.LastName,
                NumberPhone = user.PhoneNumber,
                Role = roles.Result
            };
            return Json(response);
        }
        [HttpPost]
        [Route("confirmCode/")]
        public async Task<ActionResult> GenerateCode(RegistrationViewModel model)
        {   
            if (ModelState.IsValid)
            {
                ConfirmRegistrationModel.NewUser = new User
                {
                    UserName=model.Email,
                    Email = model.Email,
                    PhoneNumber = model.NumberPhone,
                    FirstName = model.Name,
                    LastName = model.Lastname
                };
                ConfirmRegistrationModel.Password=model.Password;
                var res = await userManager.UserValidators[0].ValidateAsync(userManager,
                    ConfirmRegistrationModel.NewUser);      //Validate email
                if (res.Succeeded)
                {
                    res = await userManager.PasswordValidators[0].ValidateAsync(userManager,    
                    ConfirmRegistrationModel.NewUser,       //Validate password
                    model.Password);
                    if (res.Succeeded)
                    {
                        try
                        {
                            var code = await EmailManager.SendConfirmCodeAsync("AdolfHitler", "papych1905@gmail.com", model.Email);
                            ConfirmRegistrationModel.ConfirmCode = code;
                            return Ok();
                        }
                        catch
                        {
                            return NotFound();
                        }
                    }
                }
                return BadRequest(res.Errors);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("registration/")]
        public async Task<ActionResult> Registration(int confirmCode)
        {
            if (confirmCode != ConfirmRegistrationModel.ConfirmCode)
            {
                return NotFound(null);
            }
            var createRes=await userManager.CreateAsync(ConfirmRegistrationModel.NewUser,
                                                        ConfirmRegistrationModel.Password);
            if (createRes.Succeeded)
            {
                await userManager.AddToRoleAsync(ConfirmRegistrationModel.NewUser, "User");
                var res = await signInManager.PasswordSignInAsync(ConfirmRegistrationModel.NewUser, 
                    ConfirmRegistrationModel.Password, false, false);
                if (res.Succeeded)
                {
                    return GetToken(ConfirmRegistrationModel.NewUser);
                }
                return BadRequest(res);
            }
            else return BadRequest(createRes);  
        }
        [HttpPost]
        [Route("login/")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            User?user = await userManager
                .Users
                .FirstOrDefaultAsync(x => x.Email == model.Email);
            var res = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (res.Succeeded)
            {
                return GetToken(user);
            }
            return BadRequest(res); 
        }
    }
}
