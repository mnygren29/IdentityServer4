using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace IdentityServer4.ConsoleClient
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            //discover all the endpoints using metadata of identity server
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            if(disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            //get a bearer token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("IdentityServer4IdentitySvr");

            if(tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.IsError);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("/n/n");
        }
    }
}
