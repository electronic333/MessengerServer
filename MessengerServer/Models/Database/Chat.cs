namespace MessengerServer.Models.Database;

public class Chat {
  public string Id { get; set; } = default!;
  public string Name { get; set; } = default!;
  public User Creator { get; set; } = default!;
  public ICollection<User> Users { get; set; } = default!;
  public ICollection<Message> Messages { get; set; } = default!;
  public ICollection<Invite> Invites { get; set; } = default!;
}
