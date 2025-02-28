using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem.API.Middleware;
using SimpleBookingSystem.Application.Services;
using SimpleBookingSystem.Application.Validation;
using SimpleBookingSystem.Domain.Interfaces;
using SimpleBookingSystem.Infrastructure;
using SimpleBookingSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=booking.db"));

builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ResourceValidator>())
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookingValidator>());

builder.Services.AddCors(options =>
options.AddPolicy("MyPolicy",
    builder =>
    {
        builder
            .WithOrigins(
                "http://localhost:5173"
                )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    }
)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MyPolicy");
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
