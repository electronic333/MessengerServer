using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessengerServer.Controllers;

[Route("/[controller]")]
[ApiController]
public class ChatController: ControllerBase {
  private readonly DatabaseContext _db;

  public ChatController (DatabaseContext db) {
    _db = db;
  }

  public IActionResult Show (int id) {
    return Content($"<html><body><h1>Id: {
      id}</h1><br><h2>Records count: {
      _db.Messages.Count()}</h2></body></html>");
  }
}
