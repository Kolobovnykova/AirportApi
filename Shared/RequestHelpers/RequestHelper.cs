using System.IO;
using System.Net;
using System.Text;

namespace Shared.RequestHelpers
{
    public static class RequestHelper
    {
        public static string GetRequest(string url)
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

        public static string PostRequest(string url, string postData)
        {
            var request = WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Post;

            if (!string.IsNullOrWhiteSpace(postData))
            {
                var data = Encoding.ASCII.GetBytes(postData);
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            var response = (HttpWebResponse) request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static string PutRequest(string url, string putData)
        {
            var request = WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Put;

            if (!string.IsNullOrWhiteSpace(putData))
            {
                var data = Encoding.ASCII.GetBytes(putData);
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            var response = (HttpWebResponse) request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static string DeleteRequest(string url)
        {
            var request = WebRequest.Create(url);

            request.Method = "DELETE";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}