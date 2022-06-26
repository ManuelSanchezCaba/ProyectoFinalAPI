using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Common;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class AuthRepo : IAuth
    {
        private readonly AppDBContext _db;
        private readonly IConfiguration Configuration;

        public AuthRepo(AppDBContext db, IConfiguration configuration)
        {
            _db = db;
            Configuration = configuration;
        }

        public async Task<object> getToken(string username, string password)
        {
            try
            {
                var user = await _db.User
                    .Where(x => x.Username == username)
                    .FirstOrDefaultAsync();

                if (user == null || CommonMethods.DecryptPassword(user.Password) != password)
                {
                    return new { msg = "Incorrect User or Password" };
                }

                var roleUser = await _db.UserRole.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
                var role = roleUser == null ? "Sin Role" : await _db.Role.Where(x => x.Id == roleUser.RoleId).Select(x => x.Name).FirstOrDefaultAsync();

                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = Encoding.UTF8.GetBytes(Configuration.GetSection("SECRET").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, role)
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials =
                    new SigningCredentials(
                            new SymmetricSecurityKey(secret),
                            SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new { token = tokenHandler.WriteToken(token) };
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
