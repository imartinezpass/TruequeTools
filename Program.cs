using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Components;
using TruequeTools.Data;
using TruequeTools.Services;

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
        options.Cookie.MaxAge = TimeSpan.FromMinutes(15);
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
//**********NACHEX CODE ENDS********** AUTH - NO TOCAR

//**********NACHEX CODE BEGINS********** CRUD - AGREGAR SOLO SERVICIOS
builder.Services.AddDbContext<TruequeToolsDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TruequeToolsDbConnection")));
builder.Services.AddScoped<IServiciosCategoria, ServiciosCategoria>();
builder.Services.AddScoped<IServiciosPublicacion, ServiciosPublicacion>();
builder.Services.AddScoped<IServiciosSucursal, ServiciosSucursal>();
builder.Services.AddScoped<IServiciosUsuario, ServiciosUsuario>();
builder.Services.AddScoped<IServiciosPregunta, ServiciosPregunta>();
builder.Services.AddScoped<IServiciosOferta, ServiciosOferta>();
//**********NACHEX CODE ENDS********** CRUD - AGREGAR SOLO SERVICIOS

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

//**********NACHEX CODE BEGINS********** AUTH - NO TOCAR
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
//**********NACHEX CODE ENDS********** AUTH - NO TOCAR

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();