﻿using AutoMapper;
﻿using DentalWarranty.WebApi.Models.Users;
﻿using Enterprise.NHibernate;
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
    public class UserManager : BaseModelManager, IUserManager
    {
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Constructor for DentistManager.
        /// </summary>
        /// <param name="userRepository">IDentistRepository object</param>
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets all patients data.
        /// </summary>
        /// <returns>Returns all available patients list</returns>
        public IEnumerable<UserVM> GetAll()
        {
            var users = _userRepository.All();
            var userVms = Mapper.Map<IEnumerable<UserVM>>(users);
            return userVms;
        }

        /// <summary>
        /// Returns user details based on supplied patient Id.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User View Model object</returns>
        public UserVM Get(int id)
        {
            var user = _userRepository.FindBy(id);

            if (user == null)
                throw new DentistNotAvailableException();

            return Mapper.Map<User, UserVM>(user);
        }

        public UserVM GetByUsernameAndPassword(string userName, string passwordHash)
        {
            var user = _userRepository.FindBy( u => u.UserName == userName && u.PasswordHash == passwordHash);
            if (user == null)
                throw new DentistNotAvailableException();

            return Mapper.Map<User, UserVM>(user);
        }

        
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userVm">User object</param>
        /// <returns>Returns User View Model object</returns>
        [UnitOfWork]
        public UserVM Add(UserVM userVm)
        {
            var userId = _userRepository.Add(Mapper.Map<UserVM, User>(userVm));
            return userVm;
        }


        /// <summary>
        /// Updates user details
        /// </summary>
        /// <param name="userVm">User view model object</param>
        /// <param name="userId">Dentist Id</param>
        /// <returns>Returns update status</returns>
        [UnitOfWork]
        public bool Update(int userId, UserVM userVm)
        {
            var user = _userRepository.FindBy(userId);

            if (user == null)
                throw new DentistNotAvailableException();
            user = Mapper.Map<UserVM, User>(userVm);

            return _userRepository.Update(user);

        }

        /// <summary>
        /// Deletes the patient based on passed Id.
        /// </summary>
        /// <param name="id">Dentist Id to be deleted</param>
        [UnitOfWork]
        public bool Remove(int id)
        {
            var dentist = _userRepository.FindBy(id);

            if (dentist == null)
                throw new DentistNotAvailableException();

            return _userRepository.Delete(dentist);
        }

    }
}