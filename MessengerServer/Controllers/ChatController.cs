using MessengerServer.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MessengerServer.Controllers;

[Route("/api/chatting")]
public class ChatController: ControllerBase {
  private readonly MessengerContext _db;
  private readonly ILogger<ChatController> _logger;

  public ChatController (MessengerContext db, ILogger<ChatController> logger) {
    _db = db;
    _logger = logger;
  }

  [HttpGet, Route("users")]
  public IActionResult AllUsers () {
    return new JsonResult(_db.Users);
  }
}
