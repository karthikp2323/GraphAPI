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
            var tenant = "28cd8f80-3c44-4b27-81a0-cd2b03a31b8d";
            var clientID = "f70d1b8f-ef59-4daa-8eb4-5672b40016cf";
            var resource = "https://graph.microsoft.com/";
            var secret = "0u0ayUdN_Y--7MEFP54scx~W3lU~-yBGrj";
            var token = string.Empty;
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
                //https://graph.microsoft.com/v1.0/users/karthik.polina@flhealth.gov
                userStatus = await client.GetStringAsync($"https://graph.microsoft.com/v1.0/users/86962aac-298a-4a0b-8f98-f8e6c341e593/externalUserState");
            }

            string[] azureUserStatus = userStatus.Split(new char[] { '{', '"', ',', ':', '}' }, StringSplitOptions.RemoveEmptyEntries);
            return await Task.FromResult(azureUserStatus[azureUserStatus.Length - 1].ToString()); 

           


        }

    }
}
