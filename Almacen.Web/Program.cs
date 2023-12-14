using Almacen.Application;
using Almacen.Infrastructure.Authorization;
using Almacen.Infrastructure.Services;
using Almacen.Infrastruture;
using Almacen.Persistence;
using Almacen.Web;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authorization;
using Optivem.Framework.Core.Domain;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddPresentation(builder.Configuration)
    .AddSingleton<EmailService>()
    .AddAuthorization(options =>
    {
        options.AddPolicy(PolicyTypes.Guests.Create, policy =>
        {
            policy.RequireAuthenticatedUser();
        });
        options.AddPolicy(PolicyTypes.Guests.Read, policy =>
        {
            PolicyHandler.Equals(policy, PolicyTypes.Guests.Read);
            policy.RequireAuthenticatedUser();
        });
        options.AddPolicy(PolicyTypes.Guests.Edit, policy =>
        {
            policy.RequireAuthenticatedUser();
        });
        options.AddPolicy(PolicyTypes.Guests.Delete, policy =>
        {
            policy.RequireAuthenticatedUser();
        });

    });
builder.Services.AddScoped<IAuthorizationHandler, PolicyHandler>();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddControllersWithViews();
builder.Services.AddDNTCaptcha(options =>
        options.UseCookieStorageProvider()
            .ShowThousandsSeparators(false).WithEncryptionKey("Test123456789")
    );
//builder.Host.UseSerilog((context, configuration)
//    => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseSerilogRequestLogging();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
