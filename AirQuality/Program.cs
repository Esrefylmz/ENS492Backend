using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MySqlConnector;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//**************************************************************************
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEntityFrameworkMySQL().AddDbContext<AirQuality.Entities.Ens4912AirqualityContext>(options =>
    {
        options.UseMySQL(connectionString);
    });

//**************************************************************************




builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7264", "http://localhost:5063")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});






builder.Services.AddControllers();
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

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.Run();


