using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AzureActiveDirectory
{
    public class InviteUser
    {
       
        public async Task AuthenticateAsync()
        {

            try
            {

                //var confidentialClientApplication = ConfidentialClientApplicationBuilder
                //.Create("0f6aa14c-adad-4d5a-bdaa-70d308a3b43f")
                //.WithTenantId("28cd8f80-3c44-4b27-81a0-cd2b03a31b8d")
                //.WithClientSecret("xV~IS4D-_6.3kg45B3Hn2rqMEmC2fm9DkN")
                //.Build();

                //personal portal
                var confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create("81a142be-f13d-4937-8467-dc15736c0431")
                .WithTenantId("bdbae73e-e4b6-404e-8ee1-16ec5b0cbc50")
                .WithClientSecret("2tACENH_Kv_dpVEUwlp5Bub25Gr_lq401.")
                .Build();

                var authProvider = new ClientCredentialProvider(confidentialClientApplication);
                var graphClient = new GraphServiceClient(authProvider);

                var invitation = new Invitation
                {
                    InvitedUserDisplayName = "Karthikpp",
                    InvitedUserEmailAddress = "karthikp2323@gmail.com",
                    InviteRedirectUrl = "https://myapp.com",
                    SendInvitationMessage = true,
                    InvitedUserMessageInfo = new InvitedUserMessageInfo { 
                    CustomizedMessageBody = "Hello, " +
                    "This email invitation is to access the COVID19 Portal hosted by FL Department of Health. " +
                    "Please click Accept Invitation button and enter your email and password associated with your email to complete the registration process." +
                    "Thanks, COVID19 Antibody Portal Team"
                    }

                };

                var x = await graphClient.Invitations.Request().AddAsync(invitation);
              
                Console.WriteLine("Id: "+x.Id);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
