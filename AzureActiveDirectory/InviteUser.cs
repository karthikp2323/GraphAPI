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
                // portal details
                var confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create("clientid") // from azure portal
                .WithTenantId("tenantid") // from azure portal
                .WithClientSecret("secretkey") // from azure portal
                .Build();

                var authProvider = new ClientCredentialProvider(confidentialClientApplication);
                var graphClient = new GraphServiceClient(authProvider);

                var invitation = new Invitation
                {
                    InvitedUserDisplayName = "Invitee Name",
                    InvitedUserEmailAddress = "Invitee email",
                    InviteRedirectUrl = "https://myapp.com",
                    SendInvitationMessage = true,
                    InvitedUserMessageInfo = new InvitedUserMessageInfo { 
                    CustomizedMessageBody = "Message"
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
