using Microsoft.AspNetCore.Identity;

namespace MessengerServer.Models.Database;

public class User : IdentityUser {
  public ICollection<Chat> ChatsOwn { get; set; } = default!;
  public ICollection<Chat> ChatsMember { get; set; } = default!;
  public ICollection<Message> Messages { get; set; } = default!;
  public ICollection<Invite> IncomingInvites { get; set; } = default!;
  public ICollection<Invite> OutgoingInvites { get; set; } = default!;
}
