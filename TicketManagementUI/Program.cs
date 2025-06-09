using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using TicketManagementUI.Components;
using TicketManagementUI.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication()
	.AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddSignInManager();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/login";
	options.AccessDeniedPath = "/accessdenied";
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICriteriaService, CriteriaService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped(typeof(EncryptionHelper<>));

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
