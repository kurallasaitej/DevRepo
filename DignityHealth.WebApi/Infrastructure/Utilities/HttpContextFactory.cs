using System.Web;

namespace DignityHealth.WebApi.Infrastructure.Utilities
{
    /// <summary>
    /// HttpContext factory class
    /// </summary>
    public class HttpContextFactory
    {
        private static HttpContextBase _context;

        /// <summary>
        /// Gets current context
        /// </summary>
        public static HttpContextBase Current
        {
            get
            {
                if (_context != null)
                    return _context;
                if (HttpContext.Current == null)
                {
                    return null;
                }
                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        /// <summary>
        /// Sets current context
        /// </summary>
        /// <param name="context">HttpContextBase class</param>
        public static void SetCurrentContext(HttpContextBase context)
        {
            _context = context;
        }

    }
}