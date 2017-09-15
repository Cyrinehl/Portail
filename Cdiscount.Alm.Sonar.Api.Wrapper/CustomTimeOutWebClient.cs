using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper
{
    /// <summary>
    /// Class inherited from WebClient which override GetWebRequest method to specify a custom timeout
    /// </summary>
    public class CustomTimeOutWebClient : HttpClient
    {
        private readonly int _requestTimeOut;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTimeOutWebClient"/> class.
        /// </summary>
        /// <param name="timeOut">The time out.</param>
        public CustomTimeOutWebClient(int timeOut)
        {
            _requestTimeOut = timeOut;
        }

        /// <summary>
        /// Gets the web request.
        /// </summary>
        /// <param name="address">The URI.</param>
        /// <returns></returns>
        /*protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest w = base.GetWebRequest(address);
            w.Timeout = _requestTimeOut;
            return w;
        }*/
    }
}
