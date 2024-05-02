namespace MessengerServer.Models.Database;

public abstract class AbstractMessage {
  public int Id { get; set; }
  public User Sender { get; set; } = default!;
  public Chat Receiver { get; set; } = default!;
}
