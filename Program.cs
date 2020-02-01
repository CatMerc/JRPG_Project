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
            //OctaDirection Direction = pc.Controls.Direction;
            while (!AppStatus.KillThread)
            {
                switch (pc.Controls.Direction)
                {
                    case CurrentControl.GoUp:
                        form.BackColor = Color.Yellow;
                        break;
                    case CurrentControl.GoDown:
                        form.BackColor = Color.Purple;
                        break;
                    case CurrentControl.GoRight:
                        form.BackColor = Color.Orange;
                        break;
                    case CurrentControl.GoLeft:
                        form.BackColor = Color.LightBlue;
                        break;
                    case CurrentControl.GoUpRight:
                        form.BackColor = Color.FromArgb(235, 207, 52);
                        break;
                    case CurrentControl.GoUpLeft:
                        form.BackColor = Color.Green;
                        break;
                    case CurrentControl.GoDownLeft:
                        form.BackColor = Color.DeepSkyBlue;
                        break;
                    case CurrentControl.GoDownRight:
                        form.BackColor = Color.Red;
                        break;
                    case CurrentControl.None:
                        form.BackColor = Color.White;
                        break;
                }
            }

        }
    }
}
