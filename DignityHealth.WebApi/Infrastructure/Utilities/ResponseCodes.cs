using System.Net;
using Enterprise.Enums;
using System.ComponentModel;

namespace DignityHealth.WebApi.Infrastructure.Utilities
{
    /// <summary>
    /// Services response codes, messages for below supported HTTPStatusCodes 
    /// 200 - OK            (Success)
    /// 201 - Created       (Success)
    /// 400 - Bad Request   (Client Error)
    /// 401 - Unauthorized  (Client Error)
    /// 403 - Forbidden     (Client Error)
    /// 404 - NotFound      (Client Error)
    /// 500 - Internal Server Error (Server Error)
    /// </summary>
    public enum ResponseCodes
    {
        /// <summary>
        /// Success
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Success")]
        OK = 2000,

        /// <summary>
        /// The request was processed successfully
        /// </summary>
        [HttpStatus(HttpStatusCode.Created)]
        [Description("The request was processed successfully")]
        CREATED = 2001,

        /// <summary>
        /// Invalid Or missing parameters
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Invalid Or missing parameters :")]
        INVALID_MISSING_INPUTS = 4000,

        /// <summary>
        /// Unauthorized Access.
        /// </summary>
        [HttpStatus(HttpStatusCode.Unauthorized)]
        [Description("Unauthorized access")]
        UNAUTHORIZED = 4001,

        /// <summary>
        /// Invalid Username or Password
        /// </summary>
        [HttpStatus(HttpStatusCode.Unauthorized)]
        [Description("Invalid Username or Password")]
        LOGIN_FAILURE = 4100,

        /// <summary>
        /// Unable to send verification code email.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Unable to send verification code email.Please try again.")]
        VALIDATIONMAIL_FAILURE = 4101,

        /// <summary>
        /// An account already created for this patient
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("An account already created for this user")]
        USER_ALREADY_CREATED = 4102,

        /// <summary>
        /// Unable to register the patient.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Dentist Successfully added")]
        DENTIST_ADDED = 4103,

        /// <summary>
        /// Unable to register the patient.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Dentist failed to add")]
        DENTIST_ADDED_FAILED = 4104,

        /// <summary>
        /// Unable to register the patient.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Dentist failed to update")]
        DENTIST_UPDATION_FAILED = 4105,

        /// <summary>
        /// Unable to register the patient.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Dentist successfully updated")]
        DENTIST_UPDATED = 4106,

        /// <summary>
        /// Unable to delete Reminder
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to delete dentist")]
        DENTIST_DELETE_FAILED = 4108,

        /// <summary>
        /// Unable to add the whitelist email.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Whitelist Email Successfully added")]
        WHITELISTEMAIL_ADDED = 5103,

        /// <summary>
        /// Unable to add the whitelist domain.Please try again.
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Whitelist Domain Successfully added")]
        WHITELISTDOMAIN_ADDED = 5104,

        /// <summary>
        /// Unable to generate validation code
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to generate validation code")]
        TOKEN_GENERATION_FAILED = 4104,

        /// <summary>
        /// Unable to update the whitelist
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to update whitelist.")]
        WHITELIST_UPDATION_FAILED = 5105,

        /// <summary>
        /// Whitelist Details updated successfully
        /// </summary>
        [HttpStatus(HttpStatusCode.Created)]
        [Description("Whitelist Details updated successfully.")]
        WHITELIST_UPDATED = 5106,

        /// <summary>
        /// Unable to create Reminder
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to create Reminder")]
        REMIDER_CREATION_FAILED = 4107,

        /// <summary>
        /// Unable to delete Reminder
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to delete Patient")]
        PATIENT_DELETE_FAILED = 5108,

        /// <summary>
        /// Patient Deleted
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Patient info deleted")]
        PATIENT_DELETED = 5109,


        /// <summary>
        /// Unable to acknowledge the Reminder
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to acknowledge the Reminder")]
        REMIDER_ACKNOWLEDGE_FAILED = 4109,

        /// <summary>
        /// Unable to toggle reminder
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to toggle reminder")]
        REMIDER_TOGGLE_FAILED = 4110,

        /// <summary>
        /// Acknowledged reminder cannot be deleted
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Acknowledged reminder cannot be deleted")]
        ACKNOWLEDGED_REMINDER_CANNOT_BE_DELETED = 4111,

        /// <summary>
        /// Due date should be greater than delivery date
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Due date should be greater than delivery date")]
        INVALID_DUE_DATE = 4112,

        /// <summary>
        /// Unable to acknowledge the terms and conditions
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to acknowledge the terms and conditions")]
        ACKNOWLEDGE_TC_FAILED = 4113,

        /// <summary>
        /// Unable to delete the care partner
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to delete the care partner")]
        CAREPARTNER_DELETE_FAILED = 4114,

        /// <summary>
        /// Unable to register the care partner
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("Unable to register the care partner")]
        CAREPARTNER_REGISTRATION_FAILED = 4115,

        /// <summary>
        /// Email already registered for care partner
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Email already registered for care partner")]
        EMAIL_ALREADY_REGISTERED = 4116,

        /// <summary>
        /// Patient can have maximum 3 Care partners
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Patient can have maximum 3 Care partners")]
        CAREPARTNERS_LIMIT_EXCEEDED = 4117,

        /// <summary>
        /// This email is already in use for Patient
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("This email is already in use for Patient")]
        EMAIL_IN_USE_FOR_PATIENT = 4118,

        /// <summary>
        /// Account is not available for this patient.
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Account is not available for this patient.")]
        USER_NOTFOUND = 4200,

        /// <summary>
        /// Patient record not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Dentist record not found with the given details")]
        DENTIST_NOTFOUND = 4201,

        /// <summary>
        /// Validation code is either invalid or expired.
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Validation code is either invalid or expired.")]
        VALIDATIONCODE_NOTFOUND = 4203,

        /// <summary>
        /// Reminder Type is invalid
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Reminder Type is invalid")]
        REMINDER_TYPE_NOTFOUND = 4204,

        /// <summary>
        /// Reminder not found
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Reminder not found")]
        REMINDER_NOTFOUND = 4205,

        /// <summary>
        /// No reminders available
        /// </summary>
        //[Description("No reminders available")]
        //NOREMINDERS_AVAILABLE = 4206,

        /// <summary>
        /// ValidationCode already issued, please check your email
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("ValidationCode already issued, please check your email")]
        VALIDATIONCODE_ALREADY_ACTIVE = 4207,

        /// <summary>
        /// UserName doesn't exist
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("UserName doesn't exist")]
        USER_NOTEXIST = 4208,

        /// <summary>
        /// Provider Details Not Found
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Provider Details Not Found")]
        PROVIDER_NOTFOUND = 4209,

        /// <summary>
        /// Medication not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Medication not found with the given details")]
        MEDICATION_NOTFOUND = 4210,

        /// <summary>
        /// Lab not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Lab not found with the given details")]
        LAB_NOTFOUND = 4211,

        /// <summary>
        /// Care partner record not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Care partner record not found with the given details")]
        CAREPARTNER_NOTFOUND = 4212,

        /// <summary>
        /// Acknowledged reminder cannot be updated
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Acknowledged reminder cannot be updated")]
        ACKNOWLEDGED_REMINDER_CANNOT_BE_UPDATED = 4215,

        /// <summary>
        /// Role is not found
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Specified role is not available")]
        ROLE_NOTFOUND = 4216,

        /// <summary>
        /// Acknowledged reminder cannot be toggled
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Acknowledged reminder cannot be toggled for important")]
        ACKNOWLEDGED_REMINDER_CANNOT_BE_TOGGLED = 4217,

        /// <summary>
        /// Resource not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Resource not found with the given details")]
        RESOURCE_NOTFOUND = 4218,

        /// <summary>
        /// Patient not belongs to the Nurse
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Patient not belongs to the Nurse")]
        PATIENT_NOTBELONGSTO_PROVIDER = 4219,

        /// <summary>
        /// Token expired
        /// </summary>
        [HttpStatus(HttpStatusCode.Unauthorized)]
        [Description("Token Expired")]
        TOKEN_EXPIRED = 4220,

        /// <summary>
        /// Resource not related to group
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Resource not related to group")]
        RESOURCE_NOT_RELATED_TO_GROUP = 4221,

        /// <summary>
        /// Daily reminders cannot be set greater than 30 days from start date
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Daily reminders cannot be set more than 30 days from start date")]
        DAILY_REMINDERS_LIMIT_EXCEEDED = 4222,

        /// <summary>
        /// Weekly reminders cannot be set more than 90 days from start date
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Weekly reminders cannot be set more than 90 days from start date")]
        WEEKLY_REMINDERS_LIMIT_EXCEEDED = 4223,

        /// <summary>
        /// Reminder series not found
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Reminder series not found")]
        REMINDER_SERIES_NOTFOUND = 4224,

        /// <summary>
        /// Weekly reminders cannot be set more than 90 days from start date
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Monthly reminders cannot be set more than 12 months from start date")]
        MONTHLY_REMINDERS_LIMIT_EXCEEDED = 4225,

        /// <summary>
        /// End date should be greater than start date
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("End date should be greater than start date")]
        INVALID_END_DATE = 4226,

        /// <summary>
        /// Recurring reminder cannot be updated
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Recurring reminder cannot be updated")]
        RECURRING_REMINDER_CANNOT_BE_UPDATED = 4227,

        /// <summary>
        /// Resource category not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Resource category not found with the given details")]
        RESOURCE_CATEGORY_NOTFOUND = 4228,

        /// <summary>
        /// Resource not associated to patient
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Resource not associated to patient")]
        RESOURCE_NOT_ASSOCIATED_TO_PATIENT = 4229,

        /// <summary>
        /// Non custom resource cannot be updated
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Non custom resource cannot be updated")]
        NON_CUSTOM_RESOURCE_CANNOT_BE_UPDATED = 4230,

        /// <summary>
        /// Invalid or missing parameters : ResourceId
        /// </summary>
        [HttpStatus(HttpStatusCode.BadRequest)]
        [Description("Invalid or missing parameters : ResourceId")]
        INAVALID_OR_MISSING_PARAMETER_RESOURCEID = 4231,

        /// <summary>
        /// Non custom resource cannot be deleted
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("Non custom resource cannot be deleted")]
        NON_CUSTOM_RESOURCE_CANNOT_BE_DELETED = 4232,

        /// <summary>
        /// No Reminders available within given period
        /// </summary>
        [HttpStatus(HttpStatusCode.Forbidden)]
        [Description("No Reminders available within given period")]
        NO_REMINDERS_AVAILABLE_WITHIN_PERIOD = 4233,

        /// <summary>
        /// Reminders not found for this series
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Reminders not found for this series")]
        REMINDERS_NOTFOUND_FOR_THIS_SERIES = 4234,

        /// <summary>
        /// Lab type not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Lab type not found with the given details")]
        LAB_TYPE_NOTFOUND = 4235,

        /// <summary>
        /// Group not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Group not found with the given details")]
        GROUP_NOTFOUND = 4236,

        /// <summary>
        /// An unexpected error occurred. Please contact administrator
        /// </summary>
        [HttpStatus(HttpStatusCode.InternalServerError)]
        [Description("An unexpected error occurred. Please contact administrator")]
        INTERNAL_SEREVR_ERROR = 5000,

        /// <summary>
        /// Patient record not found with the given details
        /// </summary>
        [HttpStatus(HttpStatusCode.NotFound)]
        [Description("Patient record not found with the given details")]
        PATIENT_NOTFOUND = 5201,

        /// <summary>
        /// Patients successfully added.
        /// </summary>
        [HttpStatus(HttpStatusCode.OK)]
        [Description("Patients Successfully added")]
        PATIENTS_ADDED = 5202
    }
}
