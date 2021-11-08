using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCoreDemo.Models
{
    public class TokenManager
    {
        NameValueCollection myKey = ConfigurationManager.AppSettings;
        public static IConfigurationRoot Configuration;
        private string key;
        public TokenManager()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            key = Configuration["ConnectionStrings:TokenKey"];
        }

        //金鑰，從設定檔或資料庫取得
        //public string key = "AAAAAAAAAA-BBBBBBBBBB-CCCCCCCCCC-DDDDDDDDDD-EEEEEEEEEE-FFFFFFFFFF-GGGGGGGGGG";
        //產生 Token
        public Token Create(User user)
        {

            var exp = 180;   //過期時間(秒)

            //稍微修改 Payload 將使用者資訊和過期時間分開
            var payload = new Payload
            {
                info = user,
                //Unix 時間戳
                //exp = 60
                exp = Convert.ToInt32((DateTime.Now.AddSeconds(exp) - new DateTime(1970, 1, 1)).TotalSeconds)
            };
            //序列化成json
            var json = JsonConvert.SerializeObject(payload);
            //序列化成byte
            //byte型態才能轉Base64
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));  //payload
            //Guid.NewGuid()唯一的亂數
            var iv = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
            //使用 AES 加密 Payload
            var encrypt = TokenCrypto.AESEncrypt(base64, key.Substring(0, 16), iv);

            //取得簽章
            var signature = TokenCrypto.ComputeHMACSHA256(iv + "." + encrypt, key.Substring(0, 64));

            return new Token
            {
                //Token 為 iv + encrypt + signature，並用 . 串聯
                access_token = iv + "." + encrypt + "." + signature,
                //Refresh Token 使用 Guid 產生
                refresh_token = Guid.NewGuid().ToString().Replace("-", ""),
                expires_in = payload.exp,
            };
        }

        //取得使用者資訊
        public User GetUser(string Authorization)
        {
            var token = Authorization;
            //var token = HttpContext.Current.Request.Headers["Authoriaztion"];

            var split = token.Split('.');
            var iv = split[0];
            var encrypt = split[1];
            var signature = split[2];

            //檢查簽章是否正確
            if (signature != TokenCrypto.ComputeHMACSHA256(iv + "." + encrypt, key.Substring(0, 64)))
            {
                return null;
            }

            //使用 AES 解密 Payload
            var base64 = TokenCrypto.AESDecrypt(encrypt, key.Substring(0, 16), iv);
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            var payload = JsonConvert.DeserializeObject<Payload>(json);

            //檢查是否過期
            if (payload.exp < Convert.ToInt32((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds))
            {
                return null;
            }

            return payload.info;
        }


    }
}
