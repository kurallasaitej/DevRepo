using AutoMapper;
using DignityHealth.Domain;
using DignityHealth.WebApi.Models.Whitelists;

namespace DignityHealth.WebApi.Infrastructure.AutoMapper
{
    /// <summary>
    /// Auto maps the classes
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Initializes mapping  classes
        /// </summary>
        public static void Configure()
        {
            Mapper.CreateMap<WhitelistEmail, WhitelistVM>();
            Mapper.CreateMap<WhitelistVM, WhitelistEmail>();

            Mapper.CreateMap<WhitelistDomain, WhitelistVM>();
            Mapper.CreateMap<WhitelistVM, WhitelistDomain>();
        }
    }
}