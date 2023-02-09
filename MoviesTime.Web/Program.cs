using Microsoft.EntityFrameworkCore;
using MoviesTime.DataAccess.Database;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddControllersWithViews();

// configure db connection
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// for hot reload after.net6.0
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// middleware
var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

//app.MapGet("/", () => "Hello World!");

app.Run();
