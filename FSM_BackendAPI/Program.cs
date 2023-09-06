using System.Text;
using FSM_Application;
using FSM_Application.Catalog.BrandCatalog;
using FSM_Application.Catalog.CategoryCatalog;
using FSM_Application.Catalog.OrderCatalog;
using FSM_Application.Catalog.ProductCatalog;
using FSM_Application.Identity.Implement;
using FSM_Application.Identity.Interface;
using FSM_Application.Repository;
using FSM_Data;
using FSM_Data.EF;
using FSM_Data.Entities.Authen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<FSMDbContext>(otp =>
//        otp.UseSqlServer(builder.Configuration.GetConnectionString("FanSaleManagement")));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//	.AddEntityFrameworkStores<FSMDbContext>()
//	.AddDefaultTokenProviders();

builder.Services.AddApplicationService();
builder.Services.AddDataService(builder.Configuration);

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IBrandServices, BrandServices>();
builder.Services.AddScoped<IAuthService, AuthService>();

//add Authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        //khi token hết hạm mặc định netcore sẽ cho thêm 5p dùng cái này để loại bỏ
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});

//add Authen Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TangWeb_Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Bearer and then token in the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();