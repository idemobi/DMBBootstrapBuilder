#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBBootstrapBuilderLabs.Controllers;
using DMBBootstrapBuilderWebsite;
using DMBBootstrapLiveConfigurator.Configuration;
using DMBBootstrapLiveConfigurator;
using DMBComponentBuilder;
using DMBEffectBuilder;
using DMBPageBuilder;
using DMBServerHelper;
using DMBServerWebHelper;

#endregion

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ServerHelperConfiguration.LoadCommonConfig(builder);
ServerHelperConfiguration.Config.CookiePrefix = "DBB";
ServerWebHelperConfiguration.LoadCommonConfig(builder);
PageBuilderConfiguration.LoadCommonConfig(builder);
BootstrapBuilderConfiguration.LoadCommonConfig(builder);
ComponentBuilderConfiguration.LoadCommonConfig(builder);
EffectBuilderConfiguration.LoadCommonConfig(builder);
DMBBootstrapLiveConfiguratorConfiguration.LoadCommonConfig(builder);

var mvcBuilder = builder.Services.AddControllersWithViews();
mvcBuilder.AddApplicationPart(typeof(BootstrapBuilderController).Assembly);
mvcBuilder.AddApplicationPart(typeof(BootstrapLiveConfiguratorController).Assembly);
mvcBuilder.AddMvcOptions(options => options.Filters.Add(new DMBBootstrapBuilderWebsiteSidebarActionFilter()));

builder.Services.AddTransient<IMenuBarSectionProvider, DMBBootstrapBuilderWebsiteMenuBarSectionProvider>();
builder.Services.AddTransient<IProfileBarSectionProvider, ThemeBarSectionProvider>();
builder.Services.AddTransient<IProfileBarSectionProvider, DebugBarSectionProvider>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

ServerWebHelperConfiguration.UseApp(app);

app.MapGet("/", context =>
{
    context.Response.Redirect("/BootstrapBuilder/Introduction");
    return Task.CompletedTask;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BootstrapBuilder}/{action=Introduction}/{id?}");

app.Run();
