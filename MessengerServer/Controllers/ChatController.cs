using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessengerServer.Controllers;

[Route("/api/chatting")]
[ApiController]
public class ChatController: ControllerBase {
  private readonly DatabaseContext _db;
  private readonly ILogger<ChatController> _logger;

  public ChatController (DatabaseContext db, ILogger<ChatController> logger) {
    _db = db;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult Show () {
    return Content("<html><body><h1>Hello, User!</h1></body></html>", "text/html");
  }
}
