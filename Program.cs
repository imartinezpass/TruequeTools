using TruequeTools.Components;
using TruequeTools.Data;
using TruequeTools.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

//**********NACHEX CODE BEGINS********** AUTH - NO TOCAR
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "truequetools_auth_token";
		options.LoginPath = "/identificarse";
		options.AccessDeniedPath = "/acceso-denegado";
		options.Cookie.MaxAge = TimeSpan.FromMinutes(10);
	});
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
//**********NACHEX CODE ENDS********** AUTH - NO TOCAR

//**********NACHEX CODE BEGINS********** CRUD - AGREGAR SOLO SERVICIOS
builder.Services.AddDbContext<TruequeToolsDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TruequeToolsDbConnection")));
builder.Services.AddScoped<InterfazServiciosSucursal, ServiciosSucursal>();
builder.Services.AddScoped<InterfazServiciosUsuario, ServiciosUsuario>();
//**********NACHEX CODE ENDS********** CRUD - AGREGAR SOLO SERVICIOS

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//**********NACHEX CODE BEGINS********** AUTH - NO TOCAR
app.UseAuthentication();
app.UseAuthorization();
//**********NACHEX CODE ENDS********** AUTH - NO TOCAR

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
