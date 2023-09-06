using Microsoft.AspNetCore.Mvc;
using TMPS_Labs.Models;
using TMPS_Labs.Services;

namespace TMPS_Labs.Controllers;

[ApiController]
public class UserController : Controller {
  private readonly IApiService<User>                    _userService;
  private readonly IApiService<IEnumerable<Repository>> _reposService;

  public UserController(
    IApiService<User>                    userService,
    IApiService<IEnumerable<Repository>> reposService
  ) =>
    (_userService, _reposService) = (userService, reposService);

  [HttpGet, Route("/user/{username}")]
  public Task<User> GetUser(string username) {
    return _userService.Get(username);
  }

  [HttpGet, Route("/user/{username}/repos")]
  public Task<IEnumerable<Repository>> GetRepos(string username) {
    return _reposService.Get(username);
  }
}
