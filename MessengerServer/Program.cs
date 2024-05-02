using MessengerServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

ConfigureApplicationBuilder(builder);

var app = builder.Build();

ConfigureApplication(app);

app.Run();

static void ConfigureApplicationBuilder (WebApplicationBuilder builder) {
  builder.Logging.ClearProviders();

  builder.Host.UseSerilog((context, configuration) => 
      configuration.ReadFrom.Configuration(context.Configuration));

  builder.Services.AddControllersWithViews();
  builder.Services.AddSingleton<DatabaseContext>();
  builder.Services.AddSingleton(ConfigureOptions);
}

static DbContextOptions<DatabaseContext> ConfigureOptions (IServiceProvider provider) {
  var configuration = provider.GetRequiredService<IConfiguration>();
  var connection = configuration.GetConnectionString("Messenger");
  return new DbContextOptionsBuilder<DatabaseContext>()
    .UseSqlite(connection)
    .Options;
}

static void ConfigureApplication (WebApplication app) {
  if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
  }

  app.UseHttpsRedirection();
  app.UseStaticFiles();
  app.UseSerilogRequestLogging();
  app.UseRouting();
  app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
}
