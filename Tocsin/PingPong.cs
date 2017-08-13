using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tocsin
{
    public class PingPong
    {
        /// <summary>
        /// Sends a ping request to a url.
        /// 
        /// <see href="https://stackoverflow.com/questions/7523741/how-do-you-check-if-a-website-is-online-in-c">uzrgm</see>.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool Ping(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = 3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = System.Net.WebRequestMethods.Http.Head;

                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
