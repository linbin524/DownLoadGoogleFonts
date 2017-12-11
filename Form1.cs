using AOP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownLoadGoogleFonts
{
    public partial class Form1 : Form
    {

        public static Queue<string> downUrlQueue;
        public delegate void InvokeHandler();//多线程委托调用
        public Form1()
        {
            downUrlQueue = new Queue<string>();
            InitializeComponent();
        }
        public Thread t1;

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_downloadFont_Click(object sender, EventArgs e)
        {
            t1 = new Thread(new ThreadStart(() =>
               {
                   while (true)
                   {
                       this.Invoke(new InvokeHandler(() =>
                       {

                           if (downUrlQueue.Count() > 0)
                           {
                               string url = downUrlQueue.Dequeue();
                               string[] tempArray = url.Split('/');
                               string fileName = tempArray[tempArray.Length - 1];
                               HttpRequestHelper.DownloadFile(url, System.Environment.CurrentDirectory + "/font/" + fileName);
                               tb_downLoadRecord.AppendText(System.Environment.CurrentDirectory + "/font/" + fileName + "\r\n");
                           }

                       }));
                       Thread.Sleep(100);//线程100 0.1 正好
                    }

               }));

            t1.Start();



        }
        /// <summary>
        /// 解析源文件字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_analysisUrl_Click(object sender, EventArgs e)
        {
            string requestText = tb_fileContent.Text.Trim();
            string RegexStr = "(?<=url\\()[^\\)]+";

            MatchCollection mc;
            Regex r = new Regex(RegexStr);

            mc = r.Matches(requestText);

            List<string> list = new List<string>();

            tb_fileContent.Text = "";
            for (int i = 0; i < mc.Count; i++)
            {
                if (!mc[i].Value.Contains("../font/"))
                {
                    WriteDownloadQueue(mc[i].Value);
                    tb_fileContent.AppendText(mc[i].Value+ "\r\n");
                }

            }

            MessageBox.Show("解析完成！");

        }

        public static void WriteDownloadQueue(string url)
        {
            lock (downUrlQueue)
            {
                downUrlQueue.Enqueue(url);
            }

        }
    }
}
