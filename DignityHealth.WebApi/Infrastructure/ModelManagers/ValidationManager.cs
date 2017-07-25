using Enterprise;
using Enterprise.NHibernate;
using DentalWarranty.Domain;
using DentalWarranty.Domain.RepositoryInterfaces;
using DentalWarranty.WebApi.Infrastructure.Exceptions;
using DentalWarranty.WebApi.Infrastructure.ModelManagers.Interfaces;
using System;

namespace DentalWarranty.WebApi.Infrastructure.ModelManagers
{
    /// <summary>
    ///  Provides account validation related operations
    /// </summary>
    public class ValidationManager : IValidationManager
    {
        private readonly IValidationRepository _validationRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validationRepository">IValidationRepository object</param>
        public ValidationManager(IValidationRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        /// <summary>
        /// Gets validation code based on the passed email
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>Validation code</returns>
        public string GetValidationCode(string email)
        {
            //if active validation code exist throw an exception
            Validation validation = _validationRepository.FindBy(e => e.Email.ToLower() == email.ToLower() && e.ExpiredOn >= DateTime.Now);
            if (validation != null)
            {
                throw new ActiveValidationCodeExistException();
            }
            string validationCode = RandomCodeGenerator.Instance.Generate();

            validation = new Validation { ValidationCode = validationCode, Email = email, CreatedOn = DateTime.Now, ExpiredOn = DateTime.Now.AddDays(Convert.ToDouble(1)) };
            if (_validationRepository.Add(validation) <= 0)
                validationCode = string.Empty;

            return validationCode;
        }

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="validationCode">validation code</param>
        /// <returns>Boolean</returns>
        [UnitOfWork]
        public bool VerifyValidationCode(string email, string validationCode)
        {
            return CheckValidationCode(email, validationCode);
        }

        /// <summary>
        /// Verifies the validation code
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="validationCode">validation code</param>
        /// <returns>Boolean</returns>
        public bool CheckValidationCode(string email, string validationCode)
        {
            Validation validation = _validationRepository.FindBy(e => e.ValidationCode == validationCode &&
                                                                 e.Email.ToLower() == email.ToLower() &&
                                                                 e.ExpiredOn >= DateTime.Now);
            if (validation != null)
            {
                validation.ExpiredOn = DateTime.Now;
                _validationRepository.Update(validation);
                return true;
            }
            return false;
        }
    }
}