using Final_Project.DATA;
using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering the Connection String
builder.Services.AddDbContext<AppDbContext>
	(
		s => s.UseSqlServer
		(
			builder.Configuration.GetConnectionString("conn")
		)
	);

builder.Services.AddIdentity<Customer, IdentityRole>
	(
		s =>
		{
			s.Password.RequiredUniqueChars = 0;
			s.Password.RequireUppercase = false;
			s.Password.RequiredLength = 9;
			s.Password.RequireNonAlphanumeric = false;
			s.Password.RequireLowercase = false;
		}
	)
	.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

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
	pattern: "{controller=Food}/{action=Index}/{id?}");



app.Run();
