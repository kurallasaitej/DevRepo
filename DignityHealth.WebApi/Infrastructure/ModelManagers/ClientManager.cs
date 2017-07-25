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
    public class ClientManager : BaseModelManager, IClientManager
    {
        private readonly IClientRepository _clientRepository;
        /// <summary>
        /// Constructor for DentistManager.
        /// </summary>
        /// <param name="clientRepository">IDentistRepository object</param>
        public ClientManager(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Gets all patients data.
        /// </summary>
        /// <returns>Returns all available patients list</returns>
        public IEnumerable<ClientVM> GetAll()
        {
            var clients = _clientRepository.All();
            var clientVms = Mapper.Map<IEnumerable<ClientVM>>(clients);
            return clientVms;
        }

        /// <summary>
        /// Returns client details based on supplied patient Id.
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <returns>Client View Model object</returns>
        public ClientVM Get(string clientId)
        {
            var client = _clientRepository.FindBy(c => c.Id == clientId);

            if (client == null)
                throw new DentistNotAvailableException();

            return Mapper.Map<Client, ClientVM>(client);
        }

        
        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="clientVm">Client object</param>
        /// <returns>Returns Client View Model object</returns>
        [UnitOfWork]
        public ClientVM Add(ClientVM clientVm)
        {
            var clientId = _clientRepository.Add(Mapper.Map<ClientVM, Client>(clientVm));
            return clientVm;
        }


        /// <summary>
        /// Updates client details
        /// </summary>
        /// <param name="clientVm">Client view model object</param>
        /// <param name="clientId">Dentist Id</param>
        /// <returns>Returns update status</returns>
        [UnitOfWork]
        public bool Update(int clientId, ClientVM clientVm)
        {
            var client = _clientRepository.FindBy(clientId);

            if (client == null)
                throw new DentistNotAvailableException();
            client = Mapper.Map<ClientVM, Client>(clientVm);

            return _clientRepository.Update(client);

        }

        /// <summary>
        /// Deletes the patient based on passed Id.
        /// </summary>
        /// <param name="id">Dentist Id to be deleted</param>
        [UnitOfWork]
        public bool Remove(int id)
        {
            var dentist = _clientRepository.FindBy(id);

            if (dentist == null)
                throw new DentistNotAvailableException();

            return _clientRepository.Delete(dentist);
        }

    }
}