using FSM_Application;
using FSM_Application.Catalog.BrandCatalog;
using FSM_Application.Catalog.CategoryCatalog;
using FSM_Application.Catalog.OrderCatalog;
using FSM_Application.Catalog.ProductCatalog;
using FSM_Application.Repository;
using FSM_Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FSMDbContext>(otp =>
        otp.UseSqlServer(builder.Configuration.GetConnectionString("FanSaleManagement")));

builder.Services.AddApplicationService();

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IBrandServices, BrandServices>();


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
