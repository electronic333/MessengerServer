using MessengerServer;
using MessengerServer.Extensions;
using MessengerServer.Models.Database;
using Microsoft.AspNetCore.Identity;
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
  builder.Services.AddDbContext<MessengerContext>(ConfigureDbContext);

  builder.Services.AddAuthorization();
  builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

  builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<MessengerContext>().AddApiEndpoints();

  builder.Services.AddSwaggerGen();
}

static void ConfigureDbContext (IServiceProvider provider, DbContextOptionsBuilder builder) {
  string? connection = provider.GetRequiredService<IConfiguration>().GetConnectionString("Messenger");
  builder.UseSqlite(connection);
}

static void ConfigureApplication (WebApplication app) {
  if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
  }
  else {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
  }

  app.MapIdentityApi<User>();

  app.UseHttpsRedirection();
  app.UseStaticFiles();
  app.UseSerilogRequestLogging();
  app.UseRouting();

  app.UseAuthentication();
  app.UseAuthorization();

  app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
}
