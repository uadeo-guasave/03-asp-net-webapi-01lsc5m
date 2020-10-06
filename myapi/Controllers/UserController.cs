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

    public bool UserExists(int id) =>
      _db.Users.Any(u => u.Id == id);

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

    [HttpPost]
    public async Task<ActionResult<User>> CreateNew(User newUser)
    {
      _db.Users.Add(newUser);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> SaveChanges(int id, User modifiedUser)
    {
      if (id != modifiedUser.Id)
      {
        return BadRequest();
      }

      _db.Entry(modifiedUser).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> Delete(int id)
    {
      var user = await _db.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _db.Users.Remove(user);
      await _db.SaveChangesAsync();

      return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Login(User user, string token)
    {
      // TODO: Definir la consulta a la tabla users para validar el login
    }
  }
}