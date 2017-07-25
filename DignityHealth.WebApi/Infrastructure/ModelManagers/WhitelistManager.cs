using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DignityHealth.Domain;
using DignityHealth.Domain.RepositoryInterfaces;
using DignityHealth.WebApi.Infrastructure.ModelManagers.Interfaces;
using DignityHealth.WebApi.Infrastructure.Utilities;
using DignityHealth.WebApi.Models.Whitelists;

namespace DignityHealth.WebApi.Infrastructure.ModelManagers
{
    /// <summary>
    /// Whitelist Manager
    /// </summary>
    public class WhitelistManager : BaseModelManager, IWhitelistManager
    {
        private readonly IWhitelistEmailRepository _whitelistEmailRepository;
        private readonly IWhitelistDomainRepository _whitelistDomainRepository;

        /// <summary>
        /// WhitelistManager Constructor
        /// </summary>
        /// <param name="whitelistRepository"></param>
        /// <param name="whitelistDoaminRepository"></param>
        public WhitelistManager(IWhitelistEmailRepository whitelistRepository, IWhitelistDomainRepository whitelistDoaminRepository)
        {
            _whitelistEmailRepository = whitelistRepository;
            _whitelistDomainRepository = whitelistDoaminRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistType"></param>
        /// <returns></returns>
        public WhitelistVM GetWhitelist(WhitelistType whitelistType)
        {
            var whitelistEmails = _whitelistEmailRepository.All();
            // IEnumerable<WhitelistVM> iWhitelistEmails = Mapper.Map<IEnumerable<WhitelistEmail>, IList<WhitelistVM>>(whitelistEmails);


            return new WhitelistVM
            {
                WhitelistEmail = _whitelistEmailRepository.All().AsEnumerable().ToList(),
                WhitelistDomain = _whitelistDomainRepository.All().AsEnumerable().ToList()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistModel"></param>
        /// <returns></returns>
        public bool CreateWhitelistEmail(WhitelistVM whitelistModel)
        {

            var customModel = Mapper.Map<WhitelistVM, WhitelistEmail>(whitelistModel);

            return _whitelistEmailRepository.Add(whitelistModel.WhitelistEmail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistModel"></param>
        /// <returns></returns>
        public bool CreateWhitelistDomain(WhitelistVM whitelistModel)
        {
            var customModel = Mapper.Map<WhitelistVM, WhitelistDomain>(whitelistModel);

            return _whitelistDomainRepository.Add(whitelistModel.WhitelistDomain);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="whitelistType"></param>
        /// <param name="whitelistModel"></param>
        /// <returns></returns>
        public bool UpdateWhitelistEmail(WhitelistType whitelistType, WhitelistVM whitelistModel)
        {
            if (whitelistType == WhitelistType.Email && whitelistModel.WhitelistEmail != null)
            {
                var whitelistedItems = new List<WhitelistEmail>();
                foreach (var item in whitelistModel.WhitelistEmail)
                {
                    var whitelistEmail = _whitelistEmailRepository.FindBy(f => f.Email == item.Email);
                    if (whitelistEmail != null)
                    {
                        whitelistEmail.DeactivatedDate = item.DeactivatedDate;
                    }
                    whitelistedItems.Add(whitelistEmail);
                }

                return _whitelistEmailRepository.Update(whitelistedItems);
            }
            else
            {
                var whitelistedItems = new List<WhitelistDomain>();
                foreach (var item in whitelistModel.WhitelistDomain)
                {
                    var whitelistDomain = _whitelistDomainRepository.FindBy(f => f.DomainName == item.DomainName);
                    if (whitelistDomain != null)
                    {
                        whitelistDomain.DeactivateDate = item.DeactivateDate;
                    }
                    whitelistedItems.Add(whitelistDomain);
                }
                return _whitelistDomainRepository.Update(whitelistedItems);
            }
        }
    }
}