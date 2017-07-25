
namespace DignityHealth.WebApi.Infrastructure.Utilities
{
    /// <summary>
    /// Global class for constants
    /// </summary>
    public class GlobalConstants
    {
        /// <summary>
        /// Regular expression for User/Patient Name
        /// </summary>
        public const string NameRegularExpression = @"^[a-zA-Z''-'\s]{1,40}$";

        /// <summary>
        /// Regular expression for Password
        /// </summary>
        public const string PasswordRegularExpression = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";

        /// <summary>
        /// Regular expression for AlphaNumeric
        /// </summary>
        public const string AlphaNumericRegularExpression = @"^[a-z A-Z 0-9 .]{0,20}$";
        
        /// <summary>
        /// Regular expression for Pipe separated numbers
        /// </summary>
        public const string PipeDelimNumbersRegularExpression = @"^[1-9]([|][1-9])*$";

        /// <summary>
        /// GET
        /// </summary>
        public const string Get = "GET";

        /// <summary>
        /// Authorization
        /// </summary>
        public const string Authorization = "Authorization";

        /// <summary>
        /// Basic
        /// </summary>
        public const string Basic = "Basic";

        /// <summary>
        /// POST
        /// </summary>
        public const string Post = "POST";

        /// <summary>
        /// Json Application Type
        /// </summary>
        public const string JsonApplicationType = "application/json";

        /// <summary>
        /// Daily Reminder
        /// </summary>
        public const string DailyReminder = "D";

        /// <summary>
        /// Weekly Reminder
        /// </summary>
        public const string WeeklyReminder = "W";

        /// <summary>
        /// Monthly Reminder
        /// </summary>
        public const string MonthlyReminder = "M";

        
        /// <summary>
        /// Weekdays property in RecurringReminderCommandModel
        /// </summary>
        public const string Weekdays = "Weekdays";

        /// <summary>
        /// MonthlyDeliveryDay property in RecurringReminderCommandModel
        /// </summary>
        public const string MonthlyDeliveryDay = "MonthlyDeliveryDay";

        /// <summary>
        /// Reminder Type Resource
        /// </summary>
        public const string Resource = "Resource";


        /// <summary>
        /// Auth header schema
        /// </summary>
        public const string AuthSchema = "xBasic";


        /// <summary>
        /// Auth header schema parameter.
        /// </summary>
        public const string AuthSchemaParam = "realm=\"realm\"";

    }
}
