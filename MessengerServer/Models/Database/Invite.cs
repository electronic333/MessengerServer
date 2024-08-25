namespace MessengerServer.Models.Database;

public class Invite {
  public int Id { get; set; }
  public User User { get; set; } = default!;
  public Chat Chat { get; set; } = default!;
}
