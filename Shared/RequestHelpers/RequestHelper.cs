using System.IO;
using System.Net;
using System.Text;

namespace Shared.RequestHelpers
{
    public static class RequestHelper
    {
        public static string GetRequest(string url, string id = null)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}