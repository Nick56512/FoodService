using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using FoodService.APIConfig;
using FoodService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FoodServiceContext>((options) => 
{
    string connectionString = builder.Configuration.GetConnectionString("CafeConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddDbContext<AspNetIdentityContext>((options) => 
{
    string connectionString = builder.Configuration.GetConnectionString("IdentityConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityContext>();
//builder.Services.AddScoped<RoleManager<User>>();



builder.Services.AddScoped<FoodManager>();
builder.Services.AddScoped<IRepository<Food>,FoodRepository>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<SubcategoryService>();
builder.Services.AddScoped<IRepository<Subcategory>, SubcategoryRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<OrderItemService>();
builder.Services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();

builder.Services.AddScoped<DbContext, FoodServiceContext>();

builder.Services.Configure<IdentityOptions>((options) =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymetricKey(),
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddCors();

builder.Services.AddMvcCore(options => options.EnableEndpointRouting = false)
    .AddRazorViewEngine();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors((opt) =>
{
    opt.AllowAnyOrigin();
    opt.AllowAnyMethod();
    opt.AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
