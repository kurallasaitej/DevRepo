using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalWarranty.WebApi.Models.Common
{
    public class Client
    {
        /// <summary>
        /// Id of the Client
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Client Secret Key
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Name of the client
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Applicaton Type
        /// 1: Native App (Console / Mobile / Windows / Asp.net)
        /// 0: Client App (AngularJs / BackboneJs etc)
        /// </summary>
        public byte AppType { get; set; }

        /// <summary>
        /// Active (True / False)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Refresh token life time
        /// No of millisec(s) 
        /// </summary>
        public int RefreshTokenLifeTime { get; set; }
        
        /// <summary>
        /// Allowed origin
        /// CORS
        /// </summary>
        public string AllowedOrigin { get; set; }


    }
}