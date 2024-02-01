using AllModels;
using AllModels.Interfaces;
using FileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace AllService;
public class IdentityService : Iidentity
{
private IWorker _workerService;
public IdentityService(IWorker workerService)
{
  _workerService=workerService; 
}

      private static SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
        private static string issuer = "http://pizza.com";
        public  SecurityToken GetToken(List<Claim> claims) =>
            new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
    public static TokenValidationParameters GetTokenValidationParameters() =>
        new TokenValidationParameters
        {
            ValidIssuer = issuer,
            ValidAudience = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ")),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };

    public SecurityToken Login(User user)
        {
            var workers = _workerService.GetWorkers();
            var existWorker = workers.FirstOrDefault(Worker => ((Worker.first_name.Equals(user.first_name))&&(Worker.Password).Equals(user.Password)));
            if (existWorker == null)
                return null;

            List<Claim> Claims = new List<Claim>
            {
                new Claim("UserType" ,existWorker.Role.ToString()),
                new Claim("userId", existWorker.id.ToString())
            };
            var token = this.GetToken(Claims);
            return token;
        }
        // public static string WriteToken(SecurityToken token) =>
        //     new JwtSecurityTokenHandler().WriteToken(token);
}