using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.ConsoleClient
{
    class Program
    {
        //TO TEST:
        //1. First run the identity server projec
        //2. Next, run the api
        //3. Lastly, run the console app
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

            //consume our client api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            //create customer using bearer token

            var customerInfo = new StringContent(
                JsonConvert.SerializeObject(
                    new { Id = 3, BorrowerFirstName = "J", BorrowerLastName = "sd" }),
                Encoding.UTF8, "application/json");

            var createCustomerResponse = await client.PostAsync("http://localhost:60565/api/Borrowers",
                customerInfo);

            if(!createCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(createCustomerResponse.StatusCode);
            }

            //get a list of all of the customers
            var getCustomerResponse = await client.GetAsync("http://localhost:60565/api/Borrowers");
            if(!getCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(getCustomerResponse.StatusCode);
            }
            else
            {
                var content = await getCustomerResponse.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Console.Read();



        }
    }
}
