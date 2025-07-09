using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HISHpaBhp
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 假設從命令列或其他方式獲取身份證字號
            string idno = args.Length > 0 ? args[0] : "defaultID";
            Application.Run(new Form1(idno));
        }
    }
}
