using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FAMS
{
    class ExtWebClient : WebClient
    {
        public Dictionary<string, string> PostParam = null;
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest tmprequest = base.GetWebRequest(address);

            HttpWebRequest request = tmprequest as HttpWebRequest;

            if (request != null && PostParam != null && PostParam.Count > 0)
            {
                ((HttpWebRequest)request).UserAgent = "FAMS";
                request.Method = "POST";
                //build the post string

                string postData = String.Empty;

                PostParam.Add("mode", "2");
                foreach (KeyValuePair<string, string> obj in PostParam)
                    postData += obj.Key + "=" + obj.Value + "&";

                if (postData.Trim().Length > 0)
                    postData = postData.Substring(0, postData.Length - 1);

                byte[] postBytes = new UTF8Encoding().GetBytes(postData.ToString());

                request.ContentLength = postBytes.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                var stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();
                stream.Dispose();

            }

            return tmprequest;
        }
    }
}
