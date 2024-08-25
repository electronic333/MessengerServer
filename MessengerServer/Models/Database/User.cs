using System.Text.Json.Serialization;

namespace MessengerServer.Models.Database;

public class User {
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public string Email { get; set; } = "";

  [JsonIgnore]
  public IEnumerable<Chat> Chats { get; set; } = default!;

  [JsonIgnore]
  public IEnumerable<Message> Messages { get; set; } = default!;

  [JsonIgnore]
  public IEnumerable<Invite> Invites { get; set; } = default!;
}
