using CarSale.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarSale.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());

                if(user is null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    response.Success = false;
                    response.Message = "Wrong user/password!";
                } 
                else
                {
                    response.Data = CreateToken(user);
                    response.Success = true;
                } 
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        private string CreateToken(User user)
        {

            SymmetricSecurityKey ssk = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes
                (_configuration.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials cred = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha512Signature);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = cred,
                Expires = DateTime.Now.AddDays(1)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityToken token = handler.CreateToken(descriptor);


            return handler.WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt )
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
