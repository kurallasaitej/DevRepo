using Microsoft.Practices.Unity;
using System;
using System.Web;

namespace Enterprise.UnityLifeTime
{
    /// <summary>
    /// Provides Per Request Lifetime for Unity
    /// </summary>
    public class PerRequestLifetimeManager : LifetimeManager
    {
        private readonly Guid _key;

        /// <summary>
        /// Constructor
        /// </summary>
        public PerRequestLifetimeManager()
        {
            _key = Guid.NewGuid();
        }

        /// <summary>
        /// Gets value based on Key
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        /// <summary>
        /// Sets value for the key.
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_key] = newValue;
        }

        /// <summary>
        /// Removes value for the key
        /// </summary>
        public override void RemoveValue() { } 
    }
}
