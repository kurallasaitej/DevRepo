﻿using DentalWarranty.WebApi.Models.Common;
using NHibernate;
using Enterprise.NHibernate;
using DentalWarranty.Domain;
using DentalWarranty.Domain.RepositoryInterfaces;
using System.Collections.Generic;
using NHibernate.SqlCommand;
using System.Linq;
using NHibernate.Transform;

namespace DentalWarranty.Infrastructure.Repositories
{
    /// <summary>
    /// Provides all patient related operations
    /// </summary>
    public class UserRepository : DomainRepository<User>, IUserRepository
    {

        public UserRepository(ISession session)
            : base(session)
        {
           
        }

  
    }
}
