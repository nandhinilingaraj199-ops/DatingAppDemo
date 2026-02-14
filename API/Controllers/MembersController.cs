using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController(AppDbContext appDbContext) : ControllerBase
{
    [HttpGet]

    public async Task<ActionResult<IReadOnlyList<AppUser>>>  GetUsers()
    {
        var users = await appDbContext.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(string id)
    {
        var user =  await appDbContext.Users.FindAsync(id);
        if(user == null)
             return NotFound();
        return user;
    }
    
    
}