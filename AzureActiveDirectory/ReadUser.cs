using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureActiveDirectory
{
    public class ReadUser
    {
        public async Task<string> GetToken()
        {
            //  Constants
            var tenant = "tenent id"; // from azure portal
            var clientID = "client id"; // from azure portal
            var resource = "https://graph.microsoft.com/";
            var secret = "your secret key"; // from azure portal
            var token = string.Empty;
            var userObjectId = "user guid id";
            using (var webClient = new WebClient())
            {
                var requestParameters = new NameValueCollection();

                requestParameters.Add("resource", resource);
                requestParameters.Add("client_id", clientID);
                requestParameters.Add("grant_type", "client_credentials");
                requestParameters.Add("client_secret", secret);

                var url = $"https://login.microsoftonline.com/{tenant}/oauth2/token";
                var responsebytes = await webClient.UploadValuesTaskAsync(url, "POST", requestParameters);
                var responsebody = Encoding.UTF8.GetString(responsebytes);
                var obj = JsonConvert.DeserializeObject<JObject>(responsebody);
                token = obj["access_token"].Value<string>();

            }

            string userStatus = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //https://graph.microsoft.com/v1.0/users/useremailid
                userStatus = await client.GetStringAsync($"https://graph.microsoft.com/v1.0/users/userObjectId/externalUserState");
            }

            string[] azureUserStatus = userStatus.Split(new char[] { '{', '"', ',', ':', '}' }, StringSplitOptions.RemoveEmptyEntries);
            return await Task.FromResult(azureUserStatus[azureUserStatus.Length - 1].ToString()); 

        }

    }
}
