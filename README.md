This is a base project of mine using IdentityServer4. It uses .net core and the following Identity Server Grant Types:
-Client Credentials - used in server to server or machine to machine, intranet internal. No user resource involved.
-Implicit\ImplicitAndClientCredentials
  client tells browser that the user is on.client says i want to redirect the user/browser to the identity svr. once redirectd. id svr asks
  user for their username/password. after user logs in, they arepresetned with a consent page. asks user, do you approve of this client.
- ResourceOwnerPassword 
    the resource owner is the user. a user makes use of the client. like mobile device, web site. Good for trusted users
    internal to company and we can trust their credentials, like guid from username and password. like if we developed our own comany app.
    in this scenario, not only does the client have to send a client id to identity server, but also sends the user's user name and password, along with 
    the client id to the identity server. Identity svr 4 will maintain a list of users. So in the config file, we need to add saving for resource owner.
    
               
