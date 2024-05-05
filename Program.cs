using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google_Trends_SCR
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //なんかしらんけど/cで起動時Form2ではなく3で立ち上がる、サンデープログラマーにはわからん、そこまで問題ないから放置
            if (args.Contains("/c"))
            {
                Application.Run(new Form2());
            }
            else if (args.Contains("/p"))
            {
                Application.Run(new Form3());
            }
            else if(args.Contains("/s"))
            {
                //多重起動防止
                Mutex app_mutex = new Mutex(false, "MYSOFTWARE_001");
                if (app_mutex.WaitOne(0, false) == false)
                {
                    return;
                }
                Application.Run(new Form1());
            }
            else
            {
                //多重起動防止
                Mutex app_mutex = new Mutex(false, "MYSOFTWARE_001");
                if (app_mutex.WaitOne(0, false) == false)
                {
                    return;
                }
                Application.Run(new Form1());
            }
        }
    }
}
