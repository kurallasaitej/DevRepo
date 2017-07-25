using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using DentalWarranty.WebApi.Infrastructure.ModelManagers.Interfaces;
using DentalWarranty.WebApi.Models.Common;
using DentalWarranty.WebApi.Models.Users;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(DentalWarranty.WebApi.Infrastructure.Oauth.Startup))]
namespace DentalWarranty.WebApi.Infrastructure.Oauth
{
   
    public partial class Startup
    {
     
        public void ConfigureAuth(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            
            app.UseOAuthAuthorizationServer(
             new OAuthAuthorizationServerOptions()
                {

                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                    Provider = new AuthorizationProvider(),
                    RefreshTokenProvider = new RefreshTokenProvider()
                });

            //    app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions());
            //    app.UseOAuthAuthorizationServer(
            //        new OAuthAuthorizationServerOptions
            //        {
            //            AuthorizeEndpointPath = new PathString("/Auth"),
            //            //TokenEndpointPath = 
            //            ApplicationCanDisplayErrors = true,
            //            AllowInsecureHttp = true,// Authorization server provider which controls the lifecycle of Authorization Server
            //            Provider = new OAuthAuthorizationServerProvider
            //            {
            //                OnValidateClientRedirectUri = ValidateClientRedirectUri,
            //                OnValidateClientAuthentication = ValidateClientAuthentication,
            //                OnGrantResourceOwnerCredentials = GrantResourceOwnerCredentials,
            //                OnGrantClientCredentials = GrantClientCredetails
            //            },

            //            // Authorization code provider which creates and receives authorization code
            //            AuthorizationCodeProvider = new AuthenticationTokenProvider
            //            {
            //                OnCreate = CreateAuthenticationCode,
            //                OnReceive = ReceiveAuthenticationCode,
            //            },

            //            // Refresh token provider which creates and receives referesh token
            //            RefreshTokenProvider = new AuthenticationTokenProvider
            //            {
            //                OnCreate = CreateRefreshToken,
            //                OnReceive = ReceiveRefreshToken,
            //            }
            //        });
        }

       

        

        //private readonly ConcurrentDictionary<string, string> _authenticationCodes =
        //    new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        //private void CreateAuthenticationCode(AuthenticationTokenCreateContext context)
        //{
        //    context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
        //    _authenticationCodes[context.Token] = context.SerializeTicket();
        //}

        //private void ReceiveAuthenticationCode(AuthenticationTokenReceiveContext context)
        //{
        //    string value;
        //    if (_authenticationCodes.TryRemove(context.Token, out value))
        //    {
        //        context.DeserializeTicket(value);
        //    }
        //}

        //private void CreateRefreshToken(AuthenticationTokenCreateContext context)
        //{
        //    context.SetToken(context.SerializeTicket());
        //}

        //private void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
        //{
        //    context.DeserializeTicket(context.Token);
        //}

        //private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        //{
        //    string clientId;
        //    string clientSecret;
        //    if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
        //        context.TryGetFormCredentials(out clientId, out clientSecret))
        //    {
        //        if (clientId == Clients.Client1.Id && clientSecret == Clients.Client1.ClientSecret)
        //        {
        //            context.Validated();
        //        }
        //    }
        //    return Task.FromResult(0);
        //}

        //private Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        //{
        //    if (context.ClientId == Clients.Client1.Id)
        //    {
        //        context.Validated(Clients.Client1.RedirectUrl);
        //    }

        //    return Task.FromResult(0);
        //}
    }

    public class AuthorizationProvider : IOAuthAuthorizationServerProvider
    {
        private readonly IClientManager _clientManager;
        private readonly IUserManager _userManager;

        public AuthorizationProvider()
        {
            
        }

        public AuthorizationProvider(IClientManager clientManager, IUserManager userManager)
        {
            _clientManager = clientManager;
            _userManager = userManager;
        }

        private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            ClientVM client = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            client = _clientManager.Get(context.ClientId);

            if (client == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            //if (client.AppType == Models.ApplicationTypes.NativeConfidential)
            //{
            //    if (string.IsNullOrWhiteSpace(clientSecret))
            //    {
            //        context.SetError("invalid_clientId", "Client secret should be sent.");
            //        return Task.FromResult<object>(null);
            //    }
            //    else
            //    {
            //        if (client.ClientSecret != Helper.GetHash(clientSecret))
            //        {
            //            context.SetError("invalid_clientId", "Client secret is invalid.");
            //            return Task.FromResult<object>(null);
            //        }
            //    }
            //}

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }
        private async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
            await Task.Run(() => { 
            UserVM user = _userManager.GetByUsernameAndPassword(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { 
                        "as:client_id", context.ClientId ?? string.Empty
                    },
                    { 
                        "userName", context.UserName
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            });
        }

        private Task GrantClientCredetails(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }

        private Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            throw new NotImplementedException();
        }

        Task IOAuthAuthorizationServerProvider.GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            throw new NotImplementedException();
        }

        Task IOAuthAuthorizationServerProvider.GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            throw new NotImplementedException();
        }

        public Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            throw new NotImplementedException();
        }

        Task IOAuthAuthorizationServerProvider.TokenEndpoint(OAuthTokenEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        {
            throw new NotImplementedException();
        }

        Task IOAuthAuthorizationServerProvider.ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            throw new NotImplementedException();
        }
    }
}