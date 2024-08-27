using Microsoft.EntityFrameworkCore;

namespace MessengerServer.Extensions;

public static class MigrationExtensions {

  public static void ApplyMigrations (this IApplicationBuilder app) {
    using var scope = app.ApplicationServices.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<MessengerContext>();

    context.Database.Migrate();
  }

}
