using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using rest.Infra;
using rest.Model;
using rest.Repository.Interface;

namespace rest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller, IHttpActionResult
    {
        private readonly IAuthRepository _AuthRepository;

        public AuthController(IAuthRepository AuthRepository)
        {
            _AuthRepository = AuthRepository;
        }

        // POST api/Auth
        [HttpPost]
        public async Task<User> Create([FromBody]User user)
        {
            User usr = await _AuthRepository.GetUser(user.username, user.password);

            if (usr != null) {

                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
                                    .AddSubject(usr.username)
                                    .AddIssuer("issuerTest")
                                    .AddAudience("bearerTest")
                                    .AddClaim("MembershipId", "111")
                                    .AddExpiry(20)   // token will expire in 20 minute
                                    .Build();
                usr.token = token.Value;
                usr.password = "";                
                return usr;

            } else
                return null;
        }
    }
}
