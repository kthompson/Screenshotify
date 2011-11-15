using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Screenshotify
{
    class Imgur
    {
        private static string ApiKey = "a4fcbe61088adcc663a8d6b45331735a";

        public static string Post(Bitmap image)
        {
            var buffer = new MemoryStream();
            image.Save(buffer, ImageFormat.Jpeg, 100);

            return Post(buffer.ToArray());
        }

        public static string Post(byte[] image)
        {
            var base64String = Convert.ToBase64String(image);
            string uploadRequestString = "image=" + EscapeDataString(base64String) + "&key=" + ApiKey;

            var webRequest = (HttpWebRequest)WebRequest.Create("http://api.imgur.com/2/upload");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ServicePoint.Expect100Continue = false;

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(uploadRequestString);
                streamWriter.Flush();

                WebResponse response = webRequest.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    var responseReader = new StreamReader(responseStream);

                    return responseReader.ReadToEnd();
                }
            }
        }

        private static string EscapeDataString(string base64String)
        {
            var length = base64String.Length;
            var sb = new StringBuilder(length);

            const int chunkSize = 64000;
            for (int i = 0; i < length; i+=chunkSize)
            {
                sb.Append(length - i < chunkSize
                              ? Uri.EscapeDataString(base64String.Substring(i))
                              : Uri.EscapeDataString(base64String.Substring(i, chunkSize)));
            }

            return sb.ToString();
        }
    }
}
