using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WalletWise.Models.Services.Application;
using WalletWise.Models.Services.Infrastructure;

#region  SERVICES CONFIGURATION
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

//SERVICES CONFIGURATION
services.AddMvc();
services.AddTransient<IExpenseService, EfExpenseService>();
services.AddDbContextPool<DbContextWalletWise>(x =>
{
    //  string connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
     string connectionString = configuration.GetConnectionString("DefaultConnection");
     x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

#endregion

#region MIDDLEWARES CONFIGURATION
/*
MIDDLEWARES CONFIGURATION
 Configure the HTTP request pipeline.
 */
WebApplication app = builder.Build();
if (!app.Environment.IsDevelopment())
{
     app.UseExceptionHandler("/Home/Error");
     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
     app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseResponseCaching();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion
app.Run();


