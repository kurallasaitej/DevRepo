using DentalWarranty.WebApi.Models.Common;
using DentalWarranty.WebApi.Models.Dentists;
//using DentalWarranty.WebApi.Models.Patients;
using System.Collections.Generic;

namespace DentalWarranty.WebApi.Infrastructure.ModelManagers.Interfaces
{
    /// <summary>
    ///  This interface must be implemented by all patient related business operations.
    /// </summary>
    public interface IRefreshTokenManager
    {
        /// <summary>
        /// Gets all clients data.
        /// </summary>
        /// <returns>Returns all available clients list</returns>
        IEnumerable<RefreshTokenVM> GetAll();

        /// <summary>
        /// Gets client details based on supplied client Id.
        /// </summary>
        /// <param name="clientId">Patient Id</param>
        /// <returns>PatientViewModel object</returns>
        RefreshTokenVM Get(string refreshTokenId);

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="item">Client object</param>
        /// <returns>Returns Client object</returns>
        RefreshTokenVM Add(RefreshTokenVM item);

        /// <summary>
        /// Updates cleint details for the passed client Id.
        /// </summary>
        /// <param name="item">ClientVM object</param>
        /// <param name="clientId">Client Id</param>
        /// <returns>Returns update status</returns>
        bool Update(string refreshTokenId, RefreshTokenVM item);

        /// <summary>
        /// Deletes the dentist based on passed Id.
        /// </summary>
        /// <param name="id">Dentist Id to be deleted</param>
        bool Remove(string id);

        ///// <summary>
        ///// Registers a new patient
        ///// </summary>
        ///// <param name="cmdModel">PatientCommandModel</param>
        ///// <param name="patientId">Patient Id</param>
        ///// <returns>Returns validation code</returns>
        //string RegisterPatient(PatientCommandModel cmdModel, out int patientId);        

        ///// <summary>
        ///// Update patient resource as viewed based on supplied patient id and resource id
        ///// </summary>
        ///// <param name="patientId">Patient Id</param>
        ///// <param name="resourceId">Resource Id</param>
        ///// <returns>ModelManagerResult</returns>
        //ModelManagerResult<bool> UpdatePatientResourceAsViewed(int patientId, int resourceId);

        ///// <summary>
        ///// Returns patient's email
        ///// </summary>
        ///// <param name="patientEmailCommandModel">PatientEmailCommandModel object</param>
        ///// <returns>ModelManagerResult(PatientEmailViewModel)</returns>
        //ModelManagerResult<PatientEmailViewModel> GetPatientEmail(PatientEmailQueryModel patientEmailCommandModel);

        
    }
}
