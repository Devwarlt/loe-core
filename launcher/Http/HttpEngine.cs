using System;
using System.IO;
using System.Net;
using System.Text;

namespace LoESoft.Launcher.Http
{
    public class HttpEngine
    {
        public Action<string> OnSuccess { get; set; }
        public Action<string> OnError { get; set; }

        public void SendRequest(string request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{LauncherParameters.SERVER}/{request}");

            var postData = "thing1=hello&thing2=world";

            var data = Encoding.ASCII.GetBytes(postData);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = data.Length;

            using (var stream = httpWebRequest.GetRequestStream())
                stream.Write(data, 0, data.Length);

            try
            {
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var rdr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    OnSuccess?.Invoke(rdr.ReadToEnd());
                }
            }catch(Exception e)
            {
                OnError?.Invoke(e.StackTrace);
            }
        }
    }
}
