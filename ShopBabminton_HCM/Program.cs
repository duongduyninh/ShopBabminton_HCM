using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Repositories;
using ShopBabminton_HCM.Services.AuthenticationService;
using ShopBabminton_HCM.Services.CartService;
using ShopBabminton_HCM.Services.CategoryService;
using ShopBabminton_HCM.Services.OrderService;
using ShopBabminton_HCM.Services.ProductService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
        options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DbContextStoreBabmintion>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();    
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>(); 

builder.Services.AddScoped<IProductRepository , ProductRepository>(); 
builder.Services.AddScoped<IProductService , ProductService>();

builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ICategoryService , CategoryService>();

builder.Services.AddScoped<ICartRepository , CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService , OrderService>(); 


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new
      TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
        (builder.Configuration["JWT:Secret"]))

    };
});

builder.Services.AddDbContext<DbContextStoreBabmintion>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ShopBabminton_HCM");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
