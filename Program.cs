#region  SERVICES CONFIGURATION
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//SERVICES CONFIGURATION

// Add services to the container.
builder.Services.AddControllersWithViews();

IConfiguration configuration= builder.Configuration;
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

app.Run();
#endregion