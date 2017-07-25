using DentalWarranty.WebApi.Models.Common;
using DentalWarranty.WebApi.Models.Dentists;
//using DentalWarranty.WebApi.Models.Patients;
using System.Collections.Generic;
using DentalWarranty.WebApi.Models.Users;

namespace DentalWarranty.WebApi.Infrastructure.ModelManagers.Interfaces
{
    /// <summary>
    ///  This interface must be implemented by all patient related business operations.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Gets all clients data.
        /// </summary>
        /// <returns>Returns all available clients list</returns>
        IEnumerable<UserVM> GetAll();

        /// <summary>
        /// Gets client details based on supplied client Id.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>User View Model object</returns>
        UserVM Get(int userId);

        /// <summary>
        /// Gets user detials based on supplied user name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        UserVM GetByUsernameAndPassword(string userName, string passwordHash);

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="item">Client object</param>
        /// <returns>Returns Client object</returns>
        UserVM Add(UserVM item);

        /// <summary>
        /// Updates cleint details for the passed client Id.
        /// </summary>
        /// <param name="item">ClientVM object</param>
        /// <param name="clientId">Client Id</param>
        /// <returns>Returns update status</returns>
        bool Update(int userId, UserVM item);

        /// <summary>
        /// Deletes the dentist based on passed Id.
        /// </summary>
        /// <param name="id">Dentist Id to be deleted</param>
        bool Remove(int id);

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
