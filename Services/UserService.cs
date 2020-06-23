using BSSLNCSApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DcNCSApiContext = BSSLNCSApi.Models.DcNCSApiContext;

namespace BSSLNCSApi.Services
{
    public interface IUserService
    {
        AppUser Authenticate(string username, string password);
       
    }
    public class UserService : IUserService
    {
        public readonly DcNCSApiContext context;
        public IConfiguration Configuration { get; }
        public UserService(DcNCSApiContext _context, IConfiguration configuration)
        {
            context = _context;
            Configuration = configuration;
        }
        public AppUser Authenticate(string compCode, string password)
        {
            var user = context.APIUsers.SingleOrDefault(x => x.CompanyCode == compCode && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            //get api setting
            var apiSettings = Configuration.GetSection("APISettings");
            var apiSecretKey = Encoding.ASCII.GetBytes(apiSettings.GetValue<string>("Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(apiSecretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            
            return user.WithoutPassword();
        }
    }
}
