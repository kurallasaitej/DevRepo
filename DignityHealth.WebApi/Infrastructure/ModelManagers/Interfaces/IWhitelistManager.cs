using System.Collections.Generic;
using DignityHealth.Domain;
using DignityHealth.WebApi.Models.Whitelists;

namespace DignityHealth.WebApi.Infrastructure.ModelManagers.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWhitelistManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistType"></param>
        /// <returns></returns>
        WhitelistVM GetWhitelist(WhitelistType whitelistType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistModel"></param>
        /// <returns></returns>
        bool CreateWhitelistEmail(WhitelistVM whitelistModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistModel"></param>
        /// <returns></returns>
        bool CreateWhitelistDomain(WhitelistVM whitelistModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistType"></param>
        /// <param name="whitelistModel"></param>
        /// <returns></returns>
        bool UpdateWhitelistEmail(WhitelistType whitelistType,WhitelistVM whitelistModel);
    }
}
