using AllModels;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace AllModels.Interfaces;
 public interface Iidentity 
    {

        public  SecurityToken GetToken(List<Claim> claims);
        public SecurityToken Login(User user);
    }