using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Xml;

namespace 自动截屏并上传
{
    class AppSettings
    {
        public static int APP_ID = 111;
        public static string SECRET_ID = "SECRET_ID";
        public static string SECRET_KEY = "SECRET_KEY";
        public static string BUCKET_NAME = "job_hunter";
        public static int TIME_OUT = 30000;
        public static int COPY_FREQ = 10000;
        public static int CLIENT_NUM = 4;
        public static string JOB_NAME = "job_hunter";
        public static string REDIS_SERVER = "S833BCbj82wy8y23b@es.wanqing520.cn";
        //加载万象优图的配置文件
        public static void loadConfig()
        {
            try
            {
                string ppath = System.Environment.CurrentDirectory;//获取当前应用程序的路径             
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ppath + "\\config.xml");

                XmlNode xn = xmlDoc.SelectSingleNode("system");

                XmlNodeList xnl = xn.ChildNodes;

                foreach (XmlNode xnf in xnl)
                {
                    XmlElement xe = (XmlElement)xnf;

                    XmlNodeList xnf1 = xe.ChildNodes;
                    foreach (XmlNode xn2 in xnf1)
                    {
                        if (xn2.Name == "APP_ID")//如果找到
                        {
                            APP_ID = Convert.ToInt32(xn2.InnerText);
                        }
                        else if (xn2.Name == "SECRET_ID")
                        {
                            SECRET_ID = xn2.InnerText;
                        }
                        else if (xn2.Name == "SECRET_KEY")
                        {
                            SECRET_KEY = xn2.InnerText;
                        }
                        else if (xn2.Name == "BUCKET_NAME")
                        {
                            BUCKET_NAME = xn2.InnerText;
                        }
                        else if (xn2.Name == "TIME_OUT")
                        {
                            int tmp = int.Parse(xn2.InnerText);
                            if (tmp > 2000)
                            {
                                TIME_OUT = tmp;
                            }
                        }
                        else if (xn2.Name == "CLIENT_NUM")
                        {
                            int tmp = int.Parse(xn2.InnerText);
                            if (tmp < 4 && tmp > 0)
                            {
                                CLIENT_NUM = tmp;
                            }
                        }
                        else if (xn2.Name == "COPT_FREQ")
                        {
                            int tmp = int.Parse(xn2.InnerText);
                            if (tmp > 2000)
                            {
                                COPY_FREQ = tmp;
                            }
                        }
                        else if(xn2.Name == "REDIS_SERVER")
                        {
                            REDIS_SERVER = xn2.InnerText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                APP_ID = 111;
                SECRET_ID = "SECRET_ID";
                SECRET_KEY = "SECRET_KEY";
                BUCKET_NAME = "job_hunter";
                TIME_OUT = 30000;
                CLIENT_NUM = 4;
                COPY_FREQ = 10000;
                REDIS_SERVER = "S833BCbj82wy8y23b@es.wanqing520.cn";
            }
        }


        public static string MD5Encrypt64(string password)
        {
            return "appid" + password.GetHashCode();
        }
    }
}
