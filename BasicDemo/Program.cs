using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BasicDemo.Data;
using BasicDemo.Options;
using BasicDemo;


var builder = WebApplication.CreateBuilder(args);

Dictionary<string, string> memCollection =new() {{"MainSetting:SubSetting", "sub setting from dictionary"}};


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.Configure<EmailSettingsOptions>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<MainSettingOptions>(builder.Configuration.GetSection("MainSetting"));

builder.Configuration.AddJsonFile("custom.json", true, true);
builder.Configuration.AddXmlFile("custom.xml", true, true);
builder.Configuration.AddIniFile("custom.ini", true, true);
builder.Configuration.AddInMemoryCollection(memCollection! );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
