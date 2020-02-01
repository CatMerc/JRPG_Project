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
        public bool GoRight { get; set; }
        public bool GoLeft { get; set; }
        public bool GoUp { get; set; }
        public bool GoDown { get; set; }
        public bool GoUpRight { get; set; }
        public bool GoUpLeft { get; set; }
        public bool GoDownRight { get; set; }
        public bool GoDownLeft { get; set; }

        public Controls()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
        // Logic to determine which direction to go based upon keyboard status
        public void Evaluate(Keyboard keyboard)
        {
            SetNone();
            if (keyboard.UpArrow && !keyboard.DownArrow)
            {
                if (keyboard.LeftArrow && !keyboard.RightArrow)
                {
                    SetGoUpLeft();
                }
                else if (keyboard.RightArrow && !keyboard.LeftArrow)
                {
                    SetGoUpRight();
                }
                else
                {
                    SetGoUp();
                }
            }
            else if (keyboard.DownArrow && !keyboard.UpArrow)
            {
                if (keyboard.LeftArrow && !keyboard.RightArrow)
                {
                    SetGoDownLeft();
                }
                else if (keyboard.RightArrow && !keyboard.LeftArrow)
                {
                    SetGoDownRight();
                }
                else
                {
                    SetGoDown();
                }
            }
            else if (keyboard.LeftArrow && !keyboard.RightArrow)
            {
                SetGoLeft();
            }
            else if (keyboard.RightArrow && !keyboard.LeftArrow)
            {
                SetGoRight();
            }
            else
            {
                SetNone();
            }
        }

        // Sets the direction and zeroes out the rest
        public void SetGoRight()
        {
            GoRight = true;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
        public void SetGoLeft()
        {
            GoRight = false;
            GoLeft = true;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
        public void SetGoUp()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = true;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
        public void SetGoDown()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = true;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
        public void SetGoUpLeft()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = true;
            GoDownRight = false;
            GoDownLeft = false;
        }
        public void SetGoUpRight()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = true;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
        public void SetGoDownLeft()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = true;
        }
        public void SetGoDownRight()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = true;
            GoDownLeft = false;
        }
        public void SetNone()
        {
            GoRight = false;
            GoLeft = false;
            GoUp = false;
            GoDown = false;
            GoUpRight = false;
            GoUpLeft = false;
            GoDownRight = false;
            GoDownLeft = false;
        }
    }
}
