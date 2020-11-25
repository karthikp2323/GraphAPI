using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureActiveDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            //InviteUser inviteUser = new InviteUser();
            //inviteUser.AuthenticateAsync().Wait();

            ReadUser readUser = new ReadUser();
            readUser.GetToken().Wait();

            //Crypto crypto = new Crypto();
            //crypto.TestEncryption();

            Console.ReadLine();
        }
    }
}
