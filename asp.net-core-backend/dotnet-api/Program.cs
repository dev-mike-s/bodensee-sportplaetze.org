
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();
if (app.Environment.IsDevelopment()) { app.MapOpenApi(); }
app.UseAuthorization();
app.Use(async (context, next) =>
{
    await next.Invoke();
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});
app.MapControllers();
app.MapGet("/api/upload-image", () => "Hello .NET API world! I'm back FAHHH <3");
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
