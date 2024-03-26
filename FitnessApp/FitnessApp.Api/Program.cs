using FitnessApp.Application.Services;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Contracts.Interfaces.Services;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure;
using FitnessApp.Infrastructure.Persistence.Repositories;
using FitnessApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<ExceptionMiddleware>;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//repos
builder.Services.AddScoped<IUserRepository, UserRepository>();
//services
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

