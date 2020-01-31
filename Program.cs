using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace JRPGProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.WriteLine("yes");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            InputHandling input = new InputHandling(form);
            Thread thread = new Thread(() => { debugTest(input, ref form); });
            thread.Start();
            Application.Run(form);    
        }
        public static void debugTest(InputHandling input, ref Form1 form)
        {
            while (true)
            {
                Debug.WriteLine(input.State);
                switch (input.State)
                {
                    case (Direction.up):
                        form.BackColor = Color.Black;
                        break;
                    case (Direction.down):
                        form.BackColor = Color.White;
                        break;
                    default:
                        form.BackColor = Color.White;
                        break;
                }
            }
        }

    }
}
