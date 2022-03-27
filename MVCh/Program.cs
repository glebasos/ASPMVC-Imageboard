using Microsoft.EntityFrameworkCore;
using MVCh.Data;
using MVCh.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ChanDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("HerokuPostgres")));

builder.Services.AddRazorPages();
builder.Services.Add(new ServiceDescriptor(typeof(ITerminator), new ThreadTerminator()));
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
