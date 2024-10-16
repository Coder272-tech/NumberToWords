using NLog;
using NLog.Web;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Use NLog as the logging provider via DI
    builder.Logging.ClearProviders();
    //builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Error);
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}

catch (Exception ex)
{
    logger.Error(ex, "Application stopped due to an exception.");
    throw;
}

finally
{
    LogManager.Shutdown();
}


