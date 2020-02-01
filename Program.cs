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
        public struct AppStatus // Struct for killing threads once execution is done
        {
            public static bool KillThread { get; set; } = false;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            PlayerCharacter character = new PlayerCharacter(form);
            Thread thread = new Thread(() => { PlayerControls(character, ref form); }); // Initiates thread to handle input
            thread.Start();
            Application.Run(form); // Form blocks the main function until it closes
            AppStatus.KillThread = true; // Once form closes send the thread kill message
        }

        public static void PlayerControls(PlayerCharacter pc, ref Form1 form)
        {
            Controls controls = pc.Controls;
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
