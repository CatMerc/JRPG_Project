using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace JRPGProject
{
    public class InputHandling
    {
        readonly Keyboard keyboard = new Keyboard();
        public InputHandling(Form form)
        {
            form.KeyDown += new KeyEventHandler(KeyDownState); // Adds KeyDownState and KeyUpState as subscribers to their respective events
            form.KeyUp += new KeyEventHandler(KeyUpState);
        }
        private void KeyDownState(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            keyboard.SetDownState(e.KeyValue);
        }
        private void KeyUpState(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            keyboard.SetUpState(e.KeyValue);
        }
        public Keyboard GetKeyboard()
        {
            return keyboard;
        }
        public Controls GetControls()
        {
            return keyboard.controls;
        }
        
    }
    public class Keyboard
    {
        public Controls controls = new Controls();
        public bool RightArrow { get; set; }
        public bool LeftArrow { get; set; }
        public bool UpArrow { get; set; }
        public bool DownArrow { get; set; }

        // Sets respective property to true upon keypress
        public void SetDownState(int input)
        {
            switch (input)
            {
                case Direction.up:
                    UpArrow = true;
                    break;
                case Direction.down:
                    DownArrow = true;
                    break;
                case Direction.left:
                    LeftArrow = true;
                    break;
                case Direction.right:
                    RightArrow = true;
                    break;
            }
            controls.Evaluate(this);
        }
        // Sets respective property to false upon key up 
        public void SetUpState(int input)
        {
            switch (input)
            {
                case Direction.up:
                    UpArrow = false;
                    break;
                case Direction.down:
                    DownArrow = false;
                    break;
                case Direction.left:
                    LeftArrow = false;
                    break;
                case Direction.right:
                    RightArrow = false;
                    break;
            }
            controls.Evaluate(this);
        }
        
        public Keyboard GetKeyboard()
        {
            return this;
        }
    }

    public class Controls
    {
        public XYCoord XY = new XYCoord();
        public void Evaluate(Keyboard keyboard)
        {
            XY.Y = 0;
            XY.X = 0;
            if (keyboard.UpArrow)
            {
                XY.Y += 1;
            }
            if (keyboard.DownArrow)
            {
                XY.Y -= 1;
            }
            if (keyboard.RightArrow)
            {
                XY.X += 1;
            }
            if (keyboard.LeftArrow)
            {
                XY.X -= 1;
            }
        }
    }
}
