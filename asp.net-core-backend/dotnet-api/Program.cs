// Program.cs - MINIMAL API

using dotnet_api.Data;
using dotnet_api.Services;
using dotnet_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InMemoryDb>(opt => opt.UseInMemoryDatabase("iDb"));
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer(); siehe Zeile 28
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IImageDisplayService, ImageDisplayService>();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();
builder.Services.AddScoped<IImageValidationService, ImageValidationService>();

var app = builder.Build();
if (app.Environment.IsDevelopment()) { 
    app.MapOpenApi(); 
}
app.UseAuthorization();
app.Use(async (context, next) =>
{
    await next.Invoke();
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapConnections("/api/display", (IImageDisplayService imageDisplayService) => imageDisplayService.GetTest());
});
//app.MapGet("/hello", () => "hello .net web api");
//app.MapGet("/api/display",      (IImageDisplayService imageDisplayService)          => imageDisplayService.GetTest());
//app.MapGet("/api/upload",       (IImageUploadService imageUploadService)            => imageUploadService.GetTest());
//app.MapGet("/api/validation",   (IImageValidationService imageValidationService)    => imageValidationService.GetTest());

app.Run();
/*
public class MyDbContext: DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}
    public DbSet<Image> Images { get; set; } = default!;
}
var builder = WebApplication.CreateBuilder(args);
Add services to the container.
builder.Services.AddControllers();
Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UsePostgreSQL(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.MapOpenApi(); }
app.MapStaticAssets();
app.UseFileServer
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRewriter(new RewriteOptions().AddRedirect("/api", "/api/upload-image"));
app.MapGet("/api/image-upload", () => "Hello World!");
app.Run();
*/