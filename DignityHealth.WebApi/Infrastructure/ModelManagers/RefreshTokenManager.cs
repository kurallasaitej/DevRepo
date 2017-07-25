﻿using AutoMapper;
using Enterprise.NHibernate;
using DentalWarranty.Domain;
using DentalWarranty.Domain.RepositoryInterfaces;
using DentalWarranty.Infrastructure.Utilities;
using DentalWarranty.WebApi.Infrastructure.Exceptions;
using DentalWarranty.WebApi.Infrastructure.ModelManagers.Interfaces;
using DentalWarranty.WebApi.Infrastructure.Utilities;
using DentalWarranty.WebApi.Models.Common;
using DentalWarranty.WebApi.Models.Dentists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using DentalWarranty.WebApi.Models.Dentists;

namespace DentalWarranty.WebApi.Infrastructure.ModelManagers
{
    /// <summary>
    /// Manages all patient related business operations.
    /// </summary>
    public class RefreshTokenManager : BaseModelManager, IRefreshTokenManager
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        /// <summary>
        /// Constructor for DentistManager.
        /// </summary>
        /// <param name="refreshTokenRepository">IDentistRepository object</param>
        public RefreshTokenManager(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        /// <summary>
        /// Gets all patients data.
        /// </summary>
        /// <returns>Returns all available patients list</returns>
        public IEnumerable<RefreshTokenVM> GetAll()
        {
            var refreshTokens = _refreshTokenRepository.All();
            var refreshTokenVms = Mapper.Map<IEnumerable<RefreshTokenVM>>(refreshTokens);
            return refreshTokenVms;
        }

        /// <summary>
        /// Returns refreshToken details based on supplied patient Id.
        /// </summary>
        /// <param name="refreshTokenId">RefreshToken Id</param>
        /// <returns>RefreshToken View Model object</returns>
        public RefreshTokenVM Get(string refreshTokenId)
        {
            var refreshToken = _refreshTokenRepository.FindBy(c => c.Id == refreshTokenId);

            if (refreshToken == null)
                throw new DentistNotAvailableException();

            return Mapper.Map<RefreshToken, RefreshTokenVM>(refreshToken);
        }

        
        /// <summary>
        /// Creates a new refreshToken.
        /// </summary>
        /// <param name="refreshTokenVm">RefreshToken object</param>
        /// <returns>Returns RefreshToken View Model object</returns>
        [UnitOfWork]
        public RefreshTokenVM Add(RefreshTokenVM refreshTokenVm)
        {
            var refreshTokenId = _refreshTokenRepository.Add(Mapper.Map<RefreshTokenVM, RefreshToken>(refreshTokenVm));
            return refreshTokenVm;
        }


        /// <summary>
        /// Updates refreshToken details
        /// </summary>
        /// <param name="refreshTokenVm">RefreshToken view model object</param>
        /// <param name="refreshTokenId">Dentist Id</param>
        /// <returns>Returns update status</returns>
        [UnitOfWork]
        public bool Update(int refreshTokenId, RefreshTokenVM refreshTokenVm)
        {
            var refreshToken = _refreshTokenRepository.FindBy(refreshTokenId);

            if (refreshToken == null)
                throw new DentistNotAvailableException();
            refreshToken = Mapper.Map<RefreshTokenVM, RefreshToken>(refreshTokenVm);

            return _refreshTokenRepository.Update(refreshToken);

        }

        /// <summary>
        /// Deletes the patient based on passed Id.
        /// </summary>
        /// <param name="id">Dentist Id to be deleted</param>
        [UnitOfWork]
        public bool Remove(string id)
        {
            var token = _refreshTokenRepository.FindBy(r => r.Id == id);

            if (token == null)
                throw new DentistNotAvailableException();

            return _refreshTokenRepository.Delete(token);
        }



        public bool Update(string refreshTokenId, RefreshTokenVM item)
        {
            throw new NotImplementedException();
        }
    }
}