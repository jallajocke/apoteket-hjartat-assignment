using Api.ErrorHandling;
using Application.ExternalInterfaces;
using Application.Handlers;
using Infrastructure.OrderPersistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IGetAllOrdersHandler, GetAllOrdersHandler>();
builder.Services.AddTransient<IGetOrderHandler, GetOrderHandler>();
builder.Services.AddTransient<ICreateOrderHandler, CreateOrderHandler>();
builder.Services.AddTransient<IUpdateOrderHandler, UpdateOrderHandler>();
builder.Services.AddTransient<IDeleteOrderHandler, DeleteOrderHandler>();

builder.Services.AddSingleton<IOrderRepository, OrderRepositoryScaffold>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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
