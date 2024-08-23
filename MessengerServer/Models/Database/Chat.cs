namespace MessengerServer.Models.Database;

public class Chat {
  public int Id { get; set; }
  public IEnumerable<User> Users { get; set; } = default!;
  public IEnumerable<Message> Messages { get; set; } = default!;
}
