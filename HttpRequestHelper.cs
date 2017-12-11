using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//----------------------------------------------
//简介：跨域请求
//
//
//作者：林滨
//----------------------------------------------
namespace AOP.Common
{
   public class HttpRequestHelper
    {        /// <summary>
        /// Get 发送提交
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, System.Text.Encoding.UTF8);
                strRet = ser.ReadToEnd();
                ser.Close();
                sr.Close();
                ser = null;
                sr = null;
                hs.Close();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }
        public static string GetFile(string url,string fileName)
        {
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                //Stream sr = hs.GetResponseStream();
                //StreamReader ser = new StreamReader(sr, System.Text.Encoding.UTF8);
                //strRet = ser.ReadToEnd();
                //ser.Close();
                //sr.Close();

                StreamToImageFile(hs.GetResponseStream(), fileName);
                hs.Close();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }

        public static void StreamToImageFile(Stream stream, string fileName)
        {

            #region 下载图片
            System.Drawing.Image ResourceImage = System.Drawing.Image.FromStream(stream);
            ResourceImage.Save(System.Environment.CurrentDirectory + "/font/" + fileName); 
            #endregion

            //// 把 Stream 转换成 byte[]   
            //byte[] bytes = new byte[stream.Length];
            //stream.Read(bytes, 0, bytes.Length);
            //// 设置当前流的位置为流的开始   
            //stream.Seek(0, SeekOrigin.Begin);

            //// 把 byte[] 写入文件   
            //FileStream fs = new FileStream(fileName, FileMode.Create);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Write(bytes);
            //bw.Close();

            //fs.Close();
        }  
        /// <summary>
        ///post 提交操作
        /// </summary>
        /// <param name="url">接口路径</param>
        /// <param name="requestFormStr">Form 表单参数 看对方接口接收的数据类型，动态处理，常规是json、& 参数位要一一对应，不是任意排列</param>
        /// <param name="isJsonFormat">是否是Json格式</param> //wjl 20161208
        /// <returns></returns>
        public static string Post(string url, string requestFormStr, bool isJsonFormat = false)//添加isJsonFormat,用于设置ContentType
        {

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            CookieContainer cc = new CookieContainer();
            request = (HttpWebRequest)WebRequest.Create(url);//请求路径
            request.Method = "POST";
            if (isJsonFormat)//wjl add 添加isJsonFormat参数 20161208
            {
                request.ContentType = "application/json;charset=UTF-8";
            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            }

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";
            // string requestForm = "userName=1693372175&userPassword=123456";     //拼接Form表单里的信息
            byte[] postdatabyte = Encoding.UTF8.GetBytes(requestFormStr);
            request.ContentLength = postdatabyte.Length;
            request.AllowAutoRedirect = false;
            request.CookieContainer = cc;
            request.KeepAlive = true;
            request.Timeout = 30 * 60 * 1000;

            Stream stream;
            stream = request.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length); //设置请求主体的内容
            stream.Close();

            //接收响应
            response = (HttpWebResponse)request.GetResponse();

            Stream streamResult = response.GetResponseStream();
            StreamReader sr = new StreamReader(streamResult, System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            streamResult.Close();
            response.Close();
            string[] tt = result.Split('\n');
            return result;

        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="downLoadUrl">文件的url路径</param>
        /// <param name="saveFullName">需要保存在本地的路径(包含文件名)</param>
        /// <returns></returns>
        public static bool DownloadFile(string downLoadUrl, string saveFullName)
        {
            bool flagDown = false;
            System.Net.HttpWebRequest httpWebRequest = null;
            try
            {
                //根据url获取远程文件流
                httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(downLoadUrl);

                System.Net.HttpWebResponse httpWebResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                System.IO.Stream sr = httpWebResponse.GetResponseStream();

                //创建本地文件写入流
                System.IO.Stream sw = new System.IO.FileStream(saveFullName, System.IO.FileMode.Create);

                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = sr.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    sw.Write(by, 0, osize);
                    osize = sr.Read(by, 0, (int)by.Length);
                }
                System.Threading.Thread.Sleep(100);
                flagDown = true;
                sw.Close();
                sr.Close();
            }
            catch (System.Exception)
            {
                if (httpWebRequest != null)
                    httpWebRequest.Abort();
            }
            return flagDown;
        }

    }
}
