using PantherPetManagement_TrongLHQE180185.Repositories;
using PantherPetManagement_TrongLHQE180185.Repositories.Repos;
using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using PantherPetManagement_TrongLHQE180185.Services;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_TrongLHQE180185.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Entity Framework
builder.Services.AddDbContext<SU25PantherDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Authentication
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// Register repositories
builder.Services.AddScoped<PantherAccountRepo>();
builder.Services.AddScoped<PantherProfileRepo>();
builder.Services.AddScoped<PantherTypeRepo>();

// Register services
builder.Services.AddScoped<IPantherAccountService, PantherAccountService>();
builder.Services.AddScoped<IPantherProfileService, PantherProfileService>();
builder.Services.AddScoped<IPantherTypeService, PantherTypeService>();

// Add SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapHub<PantherPetManagementHubs>("/PantherPetManagementHubs");

app.Run();
