using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using BookingSystem.API.Middleware;
using BookingSystem.Application.Services;
using BookingSystem.Application.Validation;
using BookingSystem.Domain.Interfaces;
using BookingSystem.Infrastructure;
using BookingSystem.Infrastructure.Repositories;
using FluentValidation;

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

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<ResourceValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BookingValidator>();

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
