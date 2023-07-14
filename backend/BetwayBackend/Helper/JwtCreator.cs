//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using BackendSolution.Models;

//namespace BetwayBackend.Helper
//{
//    public class JwtCreator
//    {
//        private readonly IConfiguration _configuration;

//        public JwtCreator(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        private string GenerateJwtToken(Person person)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
//                    new Claim(ClaimTypes.Name, person.Username)
//                }),
//                Expires = DateTime.UtcNow.AddDays(7),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }

//        private Guid GetCurrentPersonId(ClaimsIdentity claimsIdentity)
//        {
//            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
//            return Guid.Parse(claim.Value);
//        }
//    }
//}
