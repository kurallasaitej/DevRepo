using System.Collections.Generic;
using DignityHealth.Domain;

namespace DignityHealth.WebApi.Models.Whitelists
{
    public class WhitelistVM
    {
        public List<WhitelistEmail> WhitelistEmail { get; set; }
        public List<WhitelistDomain> WhitelistDomain { get; set; }
    }

    public enum WhitelistType
    {
        Email,
        Domain
    };
}