﻿using MessengerServer.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace MessengerServer;

public class DatabaseContext : DbContext {
  private readonly ILogger _logger;

  public DbSet<User> Users { get; set; } = default!;
  public DbSet<Chat> Chats { get; set; } = default!;
  public DbSet<AbstractMessage> Messages { get; set; } = default!;

  public DatabaseContext (ILogger<DatabaseContext> logger, DbContextOptions<DatabaseContext> options) 
    : base(options)  
  {
    _logger = logger;

    bool created = Database.EnsureCreated();

    if (created) {
      _logger.LogInformation("Database created.");
    }
    else {
      _logger.LogInformation("Connected to existed database.");
    }
  }

  protected override void OnModelCreating (ModelBuilder modelBuilder) {
    modelBuilder.Entity<TextMessage>();

    base.OnModelCreating(modelBuilder);
  }
}
