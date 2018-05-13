using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 自动截屏并上传
{
    public class SouGouOCR
    {
        #region 搜狗OCR

        //图片转为字节数组
        private byte[] ImgToByte(Image img)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return arr;
            }
            catch
            {
                return null;
            }
        }
        //内容长度，POST时提交的数据
        public byte[] Content_Length(Image img)
        {
            byte[] a = Encoding.UTF8.GetBytes("------WebKitFormBoundary1ZZDB9E4sro7pf0g\r\nContent-Disposition: form-data; name=\"pic_path\"; filename=\"test2018.jpg\"\r\nContent-Type: image/jpeg\r\n\r\n");
            byte[] b = ImgToByte(img);
            byte[] c = Encoding.UTF8.GetBytes("\r\n------WebKitFormBoundary1ZZDB9E4sro7pf0g--\r\n");
            byte[] content = new byte[a.Length + b.Length + c.Length];
            a.CopyTo(content, 0);
            b.CopyTo(content, a.Length);
            c.CopyTo(content, a.Length + b.Length);
            return content;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img">待识别的图片</param>
        /// <returns></returns>
        public string SogouOCR(Image img)
        {
            CookieContainer cc = new CookieContainer();
            string SogouOCRBaseUrl = "http://pic.sogou.com/pic/upload_pic.jsp";
            string url = SogouPost(SogouOCRBaseUrl, cc, Content_Length(img));

            string SogouOCRUrl = "http://pic.sogou.com/pic/ocr/ocrOnline.jsp?query=" + url;
            string SogouGETRef = "http://pic.sogou.com/resource/pic/shitu_intro/word_1.html?keyword=" + url;
            var Result = SogouGet(SogouOCRUrl, cc, SogouGETRef);

            try
            {
                StringReader sr = new StringReader(Result);
                JsonTextReader jsonReader = new JsonTextReader(sr);
                JsonSerializer serializer = new JsonSerializer();
                var r = serializer.Deserialize<SogouResult>(jsonReader);
                int len = r.Result.Count;
                string s = "";
                for (int i = 0; i < len; i++)
                {
                    s += r.Result[i].Content;
                }
                return s.Replace("\n", "\r\n");
            }
            catch
            {
                return "服务器返回异常，请重试。";
            }

        }
        public string SogouPost(string url, CookieContainer cookie, byte[] content)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.CookieContainer = cookie;
            webRequest.Timeout = 10000;
            webRequest.Referer = "http://pic.sogou.com/resource/pic/shitu_intro/index.html";
            webRequest.ContentType = "multipart/form-data; boundary=----WebKitFormBoundary1ZZDB9E4sro7pf0g";
            webRequest.Accept = "*/*";
            webRequest.Headers.Add("Origin: http://pic.sogou.com");
            webRequest.Headers.Add("Accept-Encoding: gzip,deflate");
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.ProtocolVersion = new Version(1, 1);

            webRequest.ContentLength = content.Length;
            Stream requsetSteam = webRequest.GetRequestStream();
            requsetSteam.Write(content, 0, content.Length);
            requsetSteam.Close();

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    Stream st = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        st = new GZipStream(st, CompressionMode.Decompress);
                    using (var reader = new StreamReader(st, Encoding.UTF8))
                    {

                        html = reader.ReadToEnd();
                        reader.Close();
                        webResponse.Close();
                    }
                }
                return html;
            }
            catch
            {
                return null;
            }
        }

        public string SogouGet(string url, CookieContainer cookie, string refer)
        {
            var html = "";
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.CookieContainer = cookie;
            webRequest.Referer = refer;
            webRequest.Timeout = 10000;
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("X-Requested-With: XMLHttpRequest");
            webRequest.Headers.Add("Accept-Encoding: gzip,deflate");
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.ProtocolVersion = new Version(1, 1);

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    Stream st = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        st = new GZipStream(st, CompressionMode.Decompress);
                    using (var reader = new StreamReader(st, Encoding.UTF8))
                    {

                        html = reader.ReadToEnd();
                        reader.Close();
                        webResponse.Close();
                    }
                }
                return html;
            }
            catch
            {
                return null;
            }


        }


        [Serializable]
        public class SogouResult
        {
            private List<Result> result;
            public List<Result> Result
            {
                get { return result; }
                set { result = value; }
            }
        }

        [Serializable]
        public class Result
        {
            private string content;
            public string Content
            {
                get { return content; }
                set { content = value; }
            }
        }

        #endregion
    }
}
