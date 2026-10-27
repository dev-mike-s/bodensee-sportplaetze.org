using image_api.Data;
using image_api.Services;
using image_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InMemoryDb>(opt => opt.UseInMemoryDatabase("InMemoDb"));
//builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IImageDisplayService, ImageDisplayService>();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();
builder.Services.AddScoped<IImageValidationService, ImageValidationService>();
