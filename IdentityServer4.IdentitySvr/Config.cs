using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.IdentitySvr
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("IdentityServer4IdentitySvr","Borrower api for IdentityServer")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //You can created multiple different grant types. As of now, we have just a basic client credential grant type A grant type is the way a client can
                //communicate with the resource (Api etc) and also the way our client can talk to the identity server
                //Here is a list of possible grant types
                //Implicit 
                //ImplicitAndClientCredentials 
                //Code 
                //CodeAndClientCredentials  get; 
                //Hybrid 
                //HybridAndClientCredentials 
                //ClientCredentials --most often used in server to server or machine to machine, intranet internal. No user resource involved.
                //the client sends the secret. so cant use in web based apps. dont use in web based like spa
                //ResourceOwnerPassword - the resource owner is the user. a user makes use of the client. like mobile device, web site.
                //in this scenario, not only does the client have to send a client id to identity server, but also sends the user's user name and password, along with 
                //the client id to the identity server. Identity svr 4 will maintain a list of users. So in the config file, we need to add saving for resource owner.
                //as of now, just using clientcredentials, we just have the client credentials. we will use asp.net core identity to store the user resource credentials
                //ResourceOwnerPasswordAndClientCredentials 
                //DeviceFlow 

        new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"IdentityServer4IdentitySvr"}
                }
            };
        }

    }
}
