using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalWarranty.WebApi.Models.Common
{
    public class RefreshTokenVM
    {
        public string Id { get; set; }

        public string Subject { get; set; }

        public string ClientId { get; set; }

        public string ProtectedTicket { get; set; }
    }
}