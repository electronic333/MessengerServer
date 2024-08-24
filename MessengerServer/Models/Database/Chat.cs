using System.Text.Json.Serialization;

namespace MessengerServer.Models.Database;

public class Chat {
  public int Id { get; set; }

  [JsonIgnore]
  public IEnumerable<User> Users { get; set; } = default!;

  [JsonIgnore]
  public IEnumerable<Message> Messages { get; set; } = default!;
}
