using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using ApiCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCoreDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private TokenManager _tokenManager;
        public TokenController()
        {
            _tokenManager = new TokenManager();
        }
        //紀錄 Refresh Token，需紀錄在資料庫
        private static Dictionary<string, User> refreshTokens = new Dictionary<string, User>();
        //NameValueCollection myKey = ConfigurationManager.AppSettings;
        public static IConfigurationRoot Configuration;

        //[Route("TokenSignIn")]
        [HttpPost]
        public Token SignIn(User user)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var appId = Configuration["ConnectionStrings:appId"];
            var appSecret = Configuration["ConnectionStrings:appSecret"];
            //產生 Token
            Token token = null;
            if (user.appId.Equals(appId.ToString()) == true && user.appSecret.Equals(appSecret.ToString()) == true)
            {
                token = _tokenManager.Create(user);
                //需存入資料庫
                refreshTokens.Add(token.refresh_token, user);
            }
            else
            {
                token = new Token();
                token.access_token = "驗證錯誤";
                token.refresh_token = null;
                token.expires_in = 0;
            }


            return token;
        }
    }
}
