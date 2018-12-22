using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.IdentitySvr
{
    public class Config
    {

        //add test user for creating a user base flow instead of just clientcredentials
        public static List<TestUser> GetUsers()
        {

            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="jblack",
                    Password="skywalker"
                },
                 new TestUser
                {
                    SubjectId="2",
                    Username="jblack2",
                    Password="skywalker2"
                }
            };


        }

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
                //Implicit client tells browser that the user is on.client says i want to redirect the user/browser to the identity svr. once redirectd. id svr asks
                //user for their username/password. after user logs in, they arepresetned with a consent page. asks user, do you approve of this client.
                //ImplicitAndClientCredentials 
                //Code used on sites where there is a link, like to facebook or google. they will send back a code from identity server. User is involved
                //resource owner or authorization code. MVC, ASP.net, server side app. or third party native app. you can use this authorization code flow grant type.
                //CodeAndClientCredentials  get; 
                //Hybrid combine ideneity sver with auth code from faceboook or google. and implicit - get an identity token back, which is sent to the browser
                //
                //HybridAndClientCredentials 
                //ClientCredentials --most often used in server to server or machine to machine, intranet internal. No user resource involved.
                //the client sends the secret. so cant use in web based apps. dont use in web based like spa
               
                //ResourceOwnerPassword - the resource owner is the user. a user makes use of the client. like mobile device, web site. Good for trusted users
                //internal to company and we can trust their credentials, like guid from username and password. like if we developed our own comany app.
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
                },
        new Client
                {
                    ClientId="ro.client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
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
