using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PlannerAPI2.Models;

namespace PlannerAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly TodoDbContext _context;

        public UsersController(TodoDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            string usernameString = Request.Query.FirstOrDefault(p => p.Key == "username").Value;
            if (usernameString != null && usernameString.Length > 0)
            {
                return await _context.Users.Where(item => item.Username.Contains(usernameString)).ToListAsync();
            }
            else
            {
                return await _context.Users.ToListAsync();
            }
        }
    }
}
