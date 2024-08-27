namespace MessengerServer.Models.Database;

public class Invite {
  public int Id { get; set; }
  public User Sender { get; set; } = default!;
  public User Receiver { get; set; } = default!;
  public Chat Chat { get; set; } = default!;
}
