namespace MessengerServer.Models.Database;

public class User {
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public string Email { get; set; } = "";
  public IEnumerable<Chat> Chats { get; set; } = default!;
  public IEnumerable<Message> Messages { get; set; } = default!;
}
