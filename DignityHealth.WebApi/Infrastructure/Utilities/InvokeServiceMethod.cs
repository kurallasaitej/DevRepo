using System;
using System.IO;
using System.Net;
using System.Text;

namespace DentalWarranty.WebApi.Infrastructure.Utilities
{
    /// <summary>
    /// Handles methods which invokes service methods
    /// </summary>
    public class InvokeServiceMethod
    {
        /// <summary>
        /// Service method GET invocation
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <returns>Output in JSON format</returns>
        public static string GetInvocation(string requestUri)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            httpWebRequest.Method = GlobalConstants.Get;
            using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Service method GET invocation
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <param name="appToken">App Token</param>
        /// <returns>Output in JSON format</returns>
        public static string GetInvocation(string requestUri, string userName, string password, string appToken)
        {
            string data;
            WebRequest request = WebRequest.Create(requestUri);
            request.Method = GlobalConstants.Get;
            request.Headers[GlobalConstants.Authorization] = string.Format("{0} {1}", 
                                                                            GlobalConstants.Basic,
                                                                            Convert.ToBase64String(Encoding.UTF8.GetBytes(
                                                                            !string.IsNullOrEmpty(appToken) ?
                                                                            string.Format("{0}:{1}:{2}", userName, password, appToken) :
                                                                            string.Format("{0}:{1}", userName, password))));
            request.Credentials = new NetworkCredential(userName, password);
            using (var webResponse = request.GetResponse())
            {
                using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    data = streamReader.ReadToEnd();
                }
            }
            return data;
        }

        /// <summary>
        /// Service method POST invocation
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="json">Json</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <param name="appToken">App Token</param>
        /// <returns>Output in JSON format</returns>
        public static string PostInvocation(string requestUri, string json, string userName, string password, string appToken)
        {
            string data;
            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = GlobalConstants.Post;
            request.Headers[GlobalConstants.Authorization] = string.Format("{0} {1}",
                                                                            GlobalConstants.Basic,
                                                                            Convert.ToBase64String(Encoding.UTF8.GetBytes(
                                                                            !string.IsNullOrEmpty(appToken) ?
                                                                            string.Format("{0}:{1}:{2}", userName, password, appToken) :
                                                                            string.Format("{0}:{1}", userName, password))));
            request.Credentials = new NetworkCredential(userName, password);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = dataBuffer.Length;
            request.ContentType = GlobalConstants.JsonApplicationType;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(dataBuffer, 0, dataBuffer.Length);
                request.Timeout = 300000;

                using (WebResponse webResponse = request.GetResponse())
                {
                    using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        data = streamReader.ReadToEnd();
                    }
                }
            }
            return data;
        }
    }
}