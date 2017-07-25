using System;

namespace DignityHealth.WebApi.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        /// <summary>
        /// Summary of the member
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Model type
        /// </summary>
        public Type ModelType { get; set; }

        /// <summary>
        /// Name of the model
        /// </summary>
        public string Name { get; set; }
    }
}