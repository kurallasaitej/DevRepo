using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DentalWarranty.WebApi.Models.Common;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Microsoft.Owin;


namespace DentalWarranty.WebApi.Infrastructure.Oauth
{
    /// <summary>
    /// Owin Startup Class
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }

        
    }
}