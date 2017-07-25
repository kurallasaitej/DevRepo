using System;
using System.Configuration;

namespace DignityHealth.Infrastructure.Utilities
{
    /// <summary>
    /// Gets configuration relates settings
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Gets token expiration time in minutes
        /// </summary>
        public static int TokenExpirationTimeInMunutes { get { return GetAppSettingInt("Security.TokenExpirationInMinutes"); } }

        /// <summary>
        /// Gets ReAuth token expiration time in minutes
        /// </summary>
        public static int ReAuthTokenExpirationTimeInMunutes { get { return GetAppSettingInt("Security.ReAuthTokenExpirationInMinutes"); } }

        /// <summary>
        /// Gets whether the token validation enabled or not.
        /// </summary>
        public static bool EnableTokenValidation { get { return GetAppSettingBool("Security.EnableTokenValidation"); } }

        /// <summary>
        /// Gets whether the extra security token validation enabled or not.
        /// </summary>
        public static bool EnableExtraSecureTokenValidation { get { return GetAppSettingBool("Security.EnableExtraSecureTokenValidation"); } }
        
        /// <summary>
        /// Gets Content id of image used in email template
        /// </summary>
        public static string ImageContentId { get { return GetAppSetting("Email.ImageContentId"); } }

        /// <summary>
        /// Gets Application Name used in email template
        /// </summary>
        public static string ApplicationName { get { return GetAppSetting("Email.ApplicationName"); } }

        /// <summary>
        /// Gets Expiration Hours of validation code used in email template
        /// </summary>
        public static int ExpirationHours { get { return GetAppSettingInt("Email.ExpirationHours"); } }

        /// <summary>
        /// Gets Image url path used in email template
        /// </summary>
        public static string ImageUrlPath { get { return GetAppSetting("Email.ImageUrlPath"); } }

        /// <summary>
        /// Gets Email template path used in email template
        /// </summary>
        public static string EmailTemplatePath { get { return GetAppSetting("Email.EmailTemplatePath"); } }

        /// <summary>
        /// Checks whether to allow Capella system allowed or not
        /// </summary>
        public static bool IsCapellaSystemAllowed { get { return GetAppSettingBool("IsCapellaSystemAllowed"); } }

        /// <summary>
        /// Gets source system
        /// </summary>
        public static string SourceSystem { get { return GetAppSetting("SourceSystem"); } }

        /// <summary>
        /// Gets Capella patient validation service url
        /// </summary>
        public static string CapellaPatientValidationServiceUrl { get { return GetAppSetting("Capella.PatientValidationServiceUrl"); } }

        /// <summary>
        /// Gets Capella account register service url
        /// </summary>
        public static string CapellaAccountRegisterServiceUrl { get { return GetAppSetting("Capella.AccountRegisterServiceUrl"); } }

        /// <summary>
        /// Gets Capella Active Directory user name
        /// </summary>
        public static string CapellaADUserName { get { return GetAppSetting("Capella.ADUserName"); } }

        /// <summary>
        /// Gets Capella Active Directory password
        /// </summary>
        public static string CapellaADPassword { get { return GetAppSetting("Capella.ADPassword"); } }

        /// <summary>
        /// Gets Capella app token
        /// </summary>
        public static string CapellaAppToken { get { return GetAppSetting("Capella.AppToken"); } }

        /// <summary>
        /// Gets Daily reminders limit 
        /// </summary>
        public static int  DailyReminderslimit { get { return GetAppSettingInt("RecurringReminders.DailyReminderslimit"); } }

        /// <summary>
        /// Gets weekly reminders limit 
        /// </summary>
        public static int WeeklyReminderslimit { get { return GetAppSettingInt("RecurringReminders.WeeklyReminderslimit"); } }

        /// <summary>
        /// Gets Monthly reminders limit 
        /// </summary>
        public static int MonthlyReminderslimit { get { return GetAppSettingInt("RecurringReminders.MonthlyReminderslimit"); } }

        /// <summary>
        /// Gets VSee request token service url
        /// </summary>
        public static string VSeeRequestTokenServiceUrl { get { return GetAppSetting("VSee.RequestTokenServiceUrl"); } }

        /// <summary>
        /// Gets VSee Api key
        /// </summary>
        public static string VSeeApiKey { get { return GetAppSetting("VSee.ApiKey"); } }

        /// <summary>
        /// Gets VSee Api secret
        /// </summary>
        public static string VSeeApiSecret { get { return GetAppSetting("VSee.ApiSecret"); } }
        
        /// <summary>
        /// Gets Active directory domain name
        /// </summary>
        public static string ADDomainName { get { return GetAppSetting("ActiveDirectory.DomainName"); } }

        /// <summary>
        /// Gets secure password to delete user account
        /// </summary>
        public static string DeleteUserAccountSecurePassword { get { return GetAppSetting("DeleteUserAccount.SecurePassword"); } }
        
        /// <summary>
        /// Gets connection string 
        /// </summary>
        public static string DbConnnectionString
        {            
            get
            {               
                var value = ConfigurationManager.ConnectionStrings["PEConnection"].ToString();
                //if (value == null)
                //    throw new ConfigurationErrorsException(string.Format("{0} connection string is missing", "PEConnection"));
                //return HashEncryptor.Base64Decrypt(value.ToString());
                return value;
            }
        }

        /// <summary>
        /// Gets AppSetting value
        /// </summary>
        /// <param name="key">App key</param>
        /// <returns>App setting value</returns>
        public static string GetAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value == null)
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        /// <summary>
        /// Gets AppSetting or passed default value
        /// </summary>
        /// <param name="key">App key</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>App setting value</returns>
        public static string GetAppSettingOrDefault(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value ?? defaultValue;
        }

        public static double GetAppSettingDouble(string key)
        {
            double value;
            if (!double.TryParse(ConfigurationManager.AppSettings[key], out value))
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        public static decimal GetAppSettingDecimal(string key)
        {
            decimal value;
            if (!decimal.TryParse(ConfigurationManager.AppSettings[key], out value))
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        public static decimal GetAppSettingDecimalOrDefault(string key, decimal defaultValue)
        {
            var setting = ConfigurationManager.AppSettings[key];

            if (setting == null)
            {
                return defaultValue;
            }
            decimal value;
            return decimal.TryParse(setting, out value) ? value : defaultValue;
        }

        public static int GetAppSettingIntOrDefault(string key, int defaultValue)
        {
            int value;

            if (!int.TryParse(ConfigurationManager.AppSettings[key], out value))
                return defaultValue;

            return value;
        }

        public static long GetAppSettingLong(string key)
        {
            long value;

            if (!long.TryParse(ConfigurationManager.AppSettings[key], out value))
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        public static int GetAppSettingInt(string key)
        {
            int value;

            if (!int.TryParse(ConfigurationManager.AppSettings[key], out value))
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        public static ulong GetAppSettingULong(string key)
        {
            ulong value;

            if (!ulong.TryParse(ConfigurationManager.AppSettings[key], out value))
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        public static bool GetAppSettingBool(string key)
        {
            bool value;

            if (!bool.TryParse(ConfigurationManager.AppSettings[key], out value))
                throw new ConfigurationErrorsException(string.Format("{0} app setting is missing", key));

            return value;
        }

        public static Uri GetAppSettingUri(string key)
        {
            string setting = GetAppSetting(key);

            try
            {
                var uri = new Uri(setting);
                return uri;
            }

            catch (Exception e)
            {
                throw new ConfigurationErrorsException(string.Format("{0} app setting is not a valid URI: {1}", key, e.Message));
            }
        }

        public static bool GetAppSettingBoolOrDefault(string key, bool defaultValue)
        {
            var setting = ConfigurationManager.AppSettings[key];

            if (setting == null)
            {
                return defaultValue;
            }
            bool value;
            return bool.TryParse(setting, out value) ? value : defaultValue;
        }
    }
}
