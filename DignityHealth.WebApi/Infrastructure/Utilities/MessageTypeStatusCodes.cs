namespace DignityHealth.WebApi.Infrastructure.Utilities
{
    /// <summary>
    /// Message Type Status Codes
    /// </summary>
    public enum MessageTypeStatusCodes
    {
        Information = 0,
        System = 1,
        User = 2,  //Member is already registered!!
        Warning = 3,
        Error = 4,
        Success = 5
    }
}