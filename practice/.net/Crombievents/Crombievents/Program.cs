using Crombievents.Data;
using Crombievents.Interfaces;
using Crombievents.Models;
using Crombievents.Repository;
using Crombievents.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services
    .AddScoped<IRepository<User>, Repository<User>>()
    .AddScoped<IRepository<Event>, Repository<Event>>()
    .AddScoped<IRepository<Employee>, Repository<Employee>>()
    .AddScoped<IRepository<EmployeeType>, Repository<EmployeeType>>()
    .AddScoped<UserService>()
    .AddScoped<EventService>()
    .AddScoped<EmployeeService>()
    .AddScoped<EmployeeTypeService>();

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
