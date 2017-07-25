
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DentalWarranty.WebApi.Infrastructure.ModelManagers.Interfaces;
using DentalWarranty.WebApi.Models.Common;
using Microsoft.Owin.Security.Infrastructure;

namespace DentalWarranty.WebApi.Infrastructure.Oauth
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IRefreshTokenManager _refreshTokenManager;

        public RefreshTokenProvider()
        {}

        public RefreshTokenProvider(IRefreshTokenManager refreshTokenManager)
        {
            _refreshTokenManager = refreshTokenManager;
        }

        
        public async  System.Threading.Tasks.Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshTokenVM()
            {
                Id = GetHash(refreshTokenId),
                ClientId = clientid,
                Subject = context.Ticket.Identity.Name
            };

            context.Ticket.Properties.IssuedUtc = DateTime.UtcNow;
            context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime));

            token.ProtectedTicket = context.SerializeTicket();
            await Task.Run(() =>
                {
                    var result = _refreshTokenManager.Add(token);

                    if (result != null)
                    {
                        context.SetToken(refreshTokenId);
                    }
                });

        }


        public async System.Threading.Tasks.Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = GetHash(context.Token);
            await Task.Run(() => {
            var refreshToken = _refreshTokenManager.Get(hashedTokenId);

                if (refreshToken != null)
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket(refreshToken.ProtectedTicket);
                    var result = _refreshTokenManager.Remove(hashedTokenId);
                }
            });
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}