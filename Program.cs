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
            ref XYCoord XY = ref pc.Controls.XY;
            while (!AppStatus.KillThread)
            {
                if (XY.Y == 1)
                {
                    if (XY.X == 0)
                    {
                        form.BackColor = Color.Yellow;
                    }
                    else if (XY.X == 1)
                    {
                        form.BackColor = Color.FromArgb(235, 207, 52);
                    }
                    else if (XY.X == -1)
                    {
                        form.BackColor = Color.Green;
                    }
                }
                else if (XY.Y == -1)
                {
                    if (XY.X == 0)
                    {
                        form.BackColor = Color.Purple;
                    }
                    else if (XY.X == 1)
                    {
                        form.BackColor = Color.Red;
                    }
                    else if (XY.X == -1)
                    {
                        form.BackColor = Color.DeepSkyBlue;
                    }
                }
                else
                {
                    if (XY.X == 0)
                    {
                        form.BackColor = Color.White;
                    }
                    else if (XY.X == 1)
                    {
                        form.BackColor = Color.Orange;
                    }
                    else if (XY.X == -1)
                    {
                        form.BackColor = Color.LightBlue;
                    }
                }
            }

        }
    }
}
