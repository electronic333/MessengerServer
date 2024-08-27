namespace MessengerServer.Models.Database;

public class Message {
  public string Id { get; set; } = default!;
  public Chat Chat { get; set; } = default!;
  public User Sender { get; set; } = default!;
  public DateTime CreationTime { get; set; }
  public string Text { get; set; } = default!;
}
