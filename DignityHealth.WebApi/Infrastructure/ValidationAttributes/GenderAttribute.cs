namespace DignityHealth.WebApi.Infrastructure.ValidationAttributes
{
    /// <summary>
    /// Gets the localized Gender validation message.
    /// </summary>
    public class GenderAttribute : AllowedValues
    {
        private string _resourceKey;

        /// <summary>
        /// Constructor takes resource key
        /// </summary>
        /// <param name="resourceKey">ResourceKey</param>
        public GenderAttribute(string resourceKey = "")
        {
            _resourceKey = resourceKey;
            CommaSeparatedValues = DWResources.DWRes.GenderValues;
        }

        /// <summary>
        /// Overriding FormatErrorMessage to have our custom logic to return localized resource.
        /// </summary>
        /// <param name="name">Property Name</param>
        /// <returns>Localized resource</returns>
        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(_resourceKey))
                return string.Format(DWResources.DWRes.ResourceManager.GetString("ValidationAllowedValues"), name, DWResources.DWRes.GenderValues);
            return DWResources.DWRes.ResourceManager.GetString(_resourceKey);
        }
    }
}