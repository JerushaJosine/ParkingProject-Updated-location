using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace authpark
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;
        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AXqCAkpAAN6ChBkqus8Vv2wf89a80i2onFsXole7H_eHJd_Howa3uYhHRHTbZDSF1-gH5WrSUhPDiVLh";
            clientSecret = "EO21FYo0fsVoc9uMOdaeki95-Fn_9wcv38wjGE3HbYh-7K0_x_WANiYfGnxXTQbo0KWnoRPbV0AhCrEw";
        }

        private static Dictionary<string,string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public  static APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = getconfig();
            return apiContext;
        }
    }
}