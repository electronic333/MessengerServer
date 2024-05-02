namespace MessengerServer.Models.Database;

public class Chat {
  public int Id { get; set; }
  public List<User> Users { get; set; } = default!;
}
