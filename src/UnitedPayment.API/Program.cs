using Microsoft.EntityFrameworkCore;
using UnitedPayment.API.Filters;
using UnitedPayment.DDD.Contexts;
using UnitedPayment.DTO.Dto.Customer;
using UnitedPayment.Integration.NVI.Extensions;
using UnitedPayment.Integration.Payzee.Extensions;
using UnitedPayment.Repository.Repositories;
using UnitedPayment.Repository.Repositories.Interfaces;
using UnitedPayment.Service.Services;
using UnitedPayment.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddMvcOptions(options =>
{
    options.Filters.Add(typeof(ValidateModelStateAttribute));
})
.AddJsonOptions(o =>
{
    o.JsonSerializerOptions.IgnoreNullValues = true;
})
.ConfigureApiBehaviorOptions(options =>
{
    options.SuppressMapClientErrors = true;
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddDbContext<DbContext, UnitedPaymentDbContext>(options => options.UseInMemoryDatabase("UnitedPaymentDB"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddAutoMapper(typeof(CustomerProfile));

builder.Services.MernisInit();

builder.Services.PayzeeInit(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
