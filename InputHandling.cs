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
    public enum CurrentControl
    {
        None,
        GoRight,
        GoLeft,
        GoUp,
        GoDown,
        GoUpRight,
        GoUpLeft,
        GoDownRight,
        GoDownLeft
    }
    public class Controls
    {
        public CurrentControl Direction;
        // Logic to determine which direction to go based upon keyboard status
        public void Evaluate(Keyboard keyboard)
        {
            if (keyboard.UpArrow && !keyboard.DownArrow)
            {
                if (keyboard.LeftArrow && !keyboard.RightArrow)
                {
                    Direction = CurrentControl.GoUpLeft;
                }
                else if (keyboard.RightArrow && !keyboard.LeftArrow)
                {
                    Direction = CurrentControl.GoUpRight;
                }
                else
                {
                    Direction = CurrentControl.GoUp;
                }
            }
            else if (keyboard.DownArrow && !keyboard.UpArrow)
            {
                if (keyboard.LeftArrow && !keyboard.RightArrow)
                {
                    Direction = CurrentControl.GoDownLeft;
                }
                else if (keyboard.RightArrow && !keyboard.LeftArrow)
                {
                    Direction = CurrentControl.GoDownRight;
                }
                else
                {
                    Direction = CurrentControl.GoDown;
                }
            }
            else if (keyboard.LeftArrow && !keyboard.RightArrow)
            {
                Direction = CurrentControl.GoLeft;
            }
            else if (keyboard.RightArrow && !keyboard.LeftArrow)
            {
                Direction = CurrentControl.GoRight;
            }
            else
            {
                Direction = CurrentControl.None;
            }
        }
    }
}
