using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Helper_9H
{
    public class HttpHelper
    {
        public static string Get(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return streamReader.ReadToEnd();
            }
            return null;
        }

        public static string Post(string url, string requestBody)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            // 参数
            Stream reqestStream = request.GetRequestStream();
            byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(requestBody);
            reqestStream.Write(requestBytes, 0, requestBytes.Length);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return streamReader.ReadToEnd();
            }
            return null;
        }

        public static string Post(string url, string fileName, Stream stream)
        {
            string boundary = "---------------------------7d4a6d158c9";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            //-----------------------------7d4a6d158c9
            //Content-Disposition: form-data; name="buffer"; filename="mermercard.png"
            //Content-Type: application/octet-stream

            //......................................

            //-----------------------------7d4a6d158c9
            
            Stream reqestStream = request.GetRequestStream();

            string fileHeader = string.Format(
                "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: application/octet-stream\r\n\r\n",
                boundary,
                "buffer",
                fileName);
            byte[] fileHeaderBytes = System.Text.Encoding.UTF8.GetBytes(fileHeader);
            reqestStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

            byte[] fileBodyBytes = new byte[512];
            int count;
            while ((count = stream.Read(fileBodyBytes, 0, fileBodyBytes.Length)) != 0)
            {
                reqestStream.Write(fileBodyBytes, 0, count);
            }

            string requestBodyEnd = "\r\n--" + boundary + "--\r\n";
            byte[] requestBytesEnd = System.Text.Encoding.UTF8.GetBytes(requestBodyEnd);
            reqestStream.Write(requestBytesEnd, 0, requestBytesEnd.Length);

            // 
            request.ContentType = "multipart/form-data; boundary=" + boundary;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return streamReader.ReadToEnd();
            }
            return null;
        }

        private static bool CheckValidationResult(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
