using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
      var users = await _db.Users.Take(20).ToArrayAsync();
      return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
      var user = await _db.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      return user;
    }
  }
}