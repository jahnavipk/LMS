using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using AdminService.DAO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AdminService.Authentication
{
    public class JwtAuthenticationManager:IJwtAuthenticationManager
    {
        private readonly string _key;
        private IConfiguration Configuration;

        public JwtAuthenticationManager(string key, IConfiguration _configuration)
        {
            this._key = key;
            this.Configuration = _configuration;
        }

        public string Authenticate(string userName, string password)
        {

            if (FindUser(userName, password) == true)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userName)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else
            { return null; }
        }
        public bool FindUser(string email, string password)
        {
            try
            {
                MongoClient client = new MongoClient((Configuration.GetValue<string>("LMSDBSettings")));
                MongoServer server = client.GetServer();
                MongoDatabase database = server.GetDatabase("LMSData");
                MongoCollection usercollection = database.GetCollection<PortalDAO>("UserDetails");
                PortalDAO user = usercollection.AsQueryable<PortalDAO>().Where<PortalDAO>(sb => sb.Email == email && sb.Password == password).SingleOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
