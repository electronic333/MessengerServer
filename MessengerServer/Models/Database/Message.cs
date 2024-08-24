namespace MessengerServer.Models.Database;

public class Message {
  public int Id { get; set; }
  public Chat Chat { get; set; } = default!;
  public User Sender { get; set; } = default!;
  public DateTime CreationTime { get; set; }
  public string Text { get; set; } = default!;
}
