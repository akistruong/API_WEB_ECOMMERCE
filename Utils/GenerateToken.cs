using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_DSCS2_WEBBANGIAY.Utils
{
    public static class JWTHandler
    {
        
        public static string Generate( DateTime expires)
        {
            string JWTKey = Startup.Configuration.GetSection("Jwt:Key").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
           {
                new Claim(ClaimTypes.NameIdentifier,"abc"),
            };

            var token = new JwtSecurityToken(JWTKey,
              JWTKey,
              claims:claims,
              expires: expires,
              signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static bool VerifyToken(string token)
        { 
                   var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            if(jwtSecurityToken is null)
            {
                return false;
            }
            return true;
        }
    }
}
