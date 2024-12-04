using Infrastructure.DependencyInjection;
using Application.DependencyInjection;
using WebUI.Components;
using WebUI.Components.Layout.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using WebUI.States;
using WebUI.States.Administration;
using WebUI.Hubs;
using Syncfusion.Blazor;
using NetcodeHub.Packages.Components.DataGrid;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthStateProvider>();
builder.Services.AddSingleton<ChangePasswordState>();
builder.Services.AddScoped<UserActiveOrderCountState>();
builder.Services.AddScoped<AdminActiveOrderCountState>();
builder.Services.AddScoped<GenericHomeHeaderState>();
builder.Services.AddScoped<NetcodeHubConnectionService>();
builder.Services.AddScoped<ICustomAuthorizationService,CustomAuthorizationService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddVirtualizationService();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH1ecXRXQmJcUUVzV0Y=");
builder.Services.AddMudServices();
builder.Services.AddSignalR();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
app.MapSignOutEndpoint();
app.MapHub<CommunicationHub>("/communicationhub");
app.Run();
