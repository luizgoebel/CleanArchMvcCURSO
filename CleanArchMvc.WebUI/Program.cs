using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add services to the container.
//IServiceCollection serviceCollection = builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration);

var serviceProvider = builder.Services.BuildServiceProvider();
var seedUserRoleInitial = serviceProvider.GetService<ISeedUserRoleInitial>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



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

seedUserRoleInitial.SeedRoles();
seedUserRoleInitial.SeedUsers();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
