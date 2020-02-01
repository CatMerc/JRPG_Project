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
        public struct AppStatus
        {
            public static bool KillThread { get; set; } = false;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            //InputHandling input = new InputHandling(form);
            PlayerCharacter character = new PlayerCharacter(form);
            Thread thread = new Thread(() => { debugTest(character, ref form); });
            thread.Start();
            Application.Run(form);
            AppStatus.KillThread = true;
        }

        public static void debugTest(PlayerCharacter pc, ref Form1 form)
        {
            Controls controls = pc.GetControls();
            while (!AppStatus.KillThread)
            {
                if (controls.GoUp)
                {
                    form.BackColor = Color.DarkGreen;
                }
                else if (controls.GoDown)
                {
                    form.BackColor = Color.Chocolate;
                }
                else if (controls.GoRight)
                {
                    form.BackColor = Color.Black;
                }
                else if (controls.GoLeft)
                {
                    form.BackColor = Color.Red;
                }
                else if (controls.GoUpRight)
                {
                    form.BackColor = Color.IndianRed;
                }
                else if (controls.GoUpLeft)
                {
                    form.BackColor = Color.Moccasin;
                }
                else if (controls.GoDownLeft)
                {
                    form.BackColor = Color.Honeydew;
                }
                else if (controls.GoDownRight)
                {
                    form.BackColor = Color.Tomato;
                }
                else
                {
                    form.BackColor = Color.White;
                }
            }
        }

    }
}
