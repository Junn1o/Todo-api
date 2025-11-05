using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Todo_api.Data;
using Todo_api.Repositories;
using Todo_api.Repositories.Funtion;
using Todo_api.Repositories.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add connection string
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, options => { 
        options.EnableRetryOnFailure(
            maxRetryCount: 5, 
            maxRetryDelay: TimeSpan.FromSeconds(10), 
            errorNumbersToAdd: null); 
    }));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<Functions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
option.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = Environment.GetEnvironmentVariable("Issuer"),
    ValidAudience = Environment.GetEnvironmentVariable("Audience"),
    ClockSkew = TimeSpan.Zero,
    IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Key")))
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
