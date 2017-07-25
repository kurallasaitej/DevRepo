using System;

namespace DignityHealth.WebApi.Infrastructure.Exceptions
{
    /// <summary>
    /// Patient Not Available Exception
    /// </summary>
    public class DentistNotAvailableException : Exception
    {
    }

    /// <summary>
    /// Patient Not Found Exception
    /// </summary>
    public class PatientNotFoundException : Exception
    {
    }
}