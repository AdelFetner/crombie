using unidad_4_webapi.Data;
using unidad_4_webapi.Logging.DbLoggerObjects;
using unidad_4_webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services
    .AddScoped<LibroService>()
    .AddScoped<UsuarioService>();
builder.Logging.AddDbLogger(options =>
{
    builder.Configuration
        .GetSection("Logging")
        .GetSection("Database")
        .GetSection("Options")
        .Bind(options);
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
