using System.Configuration;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LunchFinder.Server.Data;
using LunchFinder.Server.Controllers;
using LunchFinder.Shared;
using LunchFinder.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<LunchFinderServerContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("LunchFinderServerContext") ??
        throw new InvalidOperationException("Connection string 'LunchFinderServerContext' not found."),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("LunchFinderServerContext"))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapTagEndpoints();


app.Run();