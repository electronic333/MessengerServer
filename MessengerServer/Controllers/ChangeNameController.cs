using MessengerServer.Models.Database;
using MessengerServer.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessengerServer.Controllers;

[ApiController, Authorize, Route("[controller]")]
public class ChangeNameController: ControllerBase {
  private readonly UserManager<User> _userManager;
  private readonly ILogger<ChangeNameController> _logger;

  public ChangeNameController (UserManager<User> userManager, ILogger<ChangeNameController> logger) {
    _userManager = userManager;
    _logger = logger;
  }

  [HttpGet]
  public Task<IActionResult> Get ([FromQuery] NameChanging data) {
    return ChangeName(data);
  }

  [HttpPost]
  public Task<IActionResult> Post ([FromBody] NameChanging data) {
    return ChangeName(data);
  }

  private async Task<IActionResult> ChangeName (NameChanging data) {
    User? user = await _userManager.FindByEmailAsync(data.Email);

    if (user is null) {
      return NotFound(data.Email);
    }

    IdentityResult result = await _userManager.SetUserNameAsync(user, data.NewName);

    if (result.Succeeded) {
      _logger.LogInformation("User {email} renamed {name}.", data.Email, data.NewName);
      return Ok(data);
    }
    else {
      return BadRequest(result);
    }    
  }
}
