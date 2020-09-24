using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using myapi.Models;

namespace myapi.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController : ControllerBase
  {
    private readonly DemoDbContext _db;

    public UserController(DemoDbContext db)
    {
      _db = db;
    }

    // select * from users;
    [HttpGet]
    public IEnumerable<User> GetAll()
    {
      var users = _db.Users.Take(20).ToArray();
      return users;
    }
  }
}