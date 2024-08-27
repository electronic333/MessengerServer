using MessengerServer.Models.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessengerServer;

public class MessengerContext : IdentityDbContext<User> {
  private readonly ILogger _logger;

  public DbSet<Chat> Chats { get; set; } = default!;
  public DbSet<Message> Messages { get; set; } = default!;
  public DbSet<Invite> Invites { get; set; } = default!;

  public MessengerContext (ILogger<MessengerContext> logger, DbContextOptions<MessengerContext> options) 
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
    //modelBuilder.Entity<User>(user => {
    //  user.HasIndex(u => u.UserName).IsUnique();
    //  user.HasIndex(u => u.Email).IsUnique();
    //});

    modelBuilder.Entity<User>().HasMany(u => u.ChatsMember).WithMany(c => c.Users);

    modelBuilder.Entity<Chat>().HasOne(c => c.Creator).WithMany(u => u.ChatsOwn);

    modelBuilder.Entity<Invite>().HasOne(i => i.Sender).WithMany(u => u.OutgoingInvites);
    modelBuilder.Entity<Invite>().HasOne(i => i.Receiver).WithMany(u => u.IncomingInvites);

    base.OnModelCreating(modelBuilder);
  }
}
