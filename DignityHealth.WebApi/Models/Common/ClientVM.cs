using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalWarranty.WebApi.Models.Common
{
    public class ClientVM
    {
        public string Id { get; set; }

        public string ClientSecret { get; set; }

        public string Name { get; set; }

        public byte AppType { get; set; }

        public bool Active { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        public string AllowedOrigin { get; set; }
    }
}