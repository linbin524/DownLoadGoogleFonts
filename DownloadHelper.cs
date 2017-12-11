
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOP.Common
{
  
    public class DownloadHelper
    {
        //异常信息的队列
        public static Queue<string> ExcMsg;

        static DownloadHelper()
        {
            ExcMsg = new Queue<string>();
            ThreadPool.QueueUserWorkItem(u =>
                {
                    while (true)
                    {
                        string str = string.Empty;

                        if (ExcMsg == null)
                        {
                            continue;
                        }

                        lock (ExcMsg)
                        {
                            if (ExcMsg.Count > 0)
                                str = ExcMsg.Dequeue();
                        }
                        //往日志文件里面写就可以了。
                        if (!string.IsNullOrEmpty(str))
                        {
                           //下载队列操作
                        }
                        if (ExcMsg.Count() <= 0)
                        {
                            Thread.Sleep(30);
                        }


                    }
                });
        }

        public static void WriteDownloadQueue(string url)
        {
            lock (ExcMsg)
            {
                ExcMsg.Enqueue(url);
            }

        }


    }
}
