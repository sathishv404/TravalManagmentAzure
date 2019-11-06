using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.API.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GetJWTToken(string userId)
        {

            //Claims Unique name based on userid
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Defining security
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("s2-cloud-native-onlinetravelmanagement"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //defining the JWT token with expiration time
            var token = new JwtSecurityToken(
                issuer: "AuthServer",
                audience: "online-travel-management",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );
            //define the response of the token 
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            //Serialize the responset to Json
            return JsonConvert.SerializeObject(response);
        }
    }
}
