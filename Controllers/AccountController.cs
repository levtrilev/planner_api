using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PlannerAPI2.Models; // класс User
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PlannerAPI2.Controllers
{

    public class AccountController : Controller
    {
        private readonly TodoDbContext _context;
        public AccountController(TodoDbContext context)
        {
            _context = context;
        }

        private async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // тестовые данные вместо использования базы данных
        

        //int x = await Task.Run(() => Factorial(n));

        //private List<User> people = new List<User>
        //{
        //    new User {Email="admin@gmail.com", Password="12345", Role = "admin" },
        //    new User { Email="qwerty@gmail.com", Password="55555", Role = "user" }
        //};

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        //public String Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
                //return "Invalid username or password.";
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
            //return JsonConvert.SerializeObject(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            List<User> people = GetUsers().GetAwaiter().GetResult();
            User user = people.FirstOrDefault(x => x.Email == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace JWT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//    }
//}
