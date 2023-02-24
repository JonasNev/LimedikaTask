using LimedikaTask;
using LimedikaTask.Data;
using LimedikaTask.PostitAPI;
using LimedikaTask.Repository;
using LimedikaTask.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(d => d.UseSqlServer(builder.Configuration.GetSection(Constants.Clients.ConnectionStringSecterName).Value), ServiceLifetime.Transient);
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IJsonReader, JsonReader>();
builder.Services.AddTransient<ILogRepository, LogRepository>();
builder.Services.AddTransient<IApiService, ApiService>();
builder.Services.AddTransient<IStringFormatting, StringFormatting>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
