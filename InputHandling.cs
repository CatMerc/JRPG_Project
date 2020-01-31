using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace JRPGProject
{
    class InputHandling
    {
        public int State { get; private set; }
        Form Form;
        public InputHandling(Form form)
        {
            Form = form;
            Form.KeyDown +=
                new KeyEventHandler(KeyDownState);
            Form.KeyUp += new KeyEventHandler(KeyUpState);
        }
        private void KeyDownState(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            State = e.KeyValue;
        }
        private void KeyUpState(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyValue == State)
            {
                State = 0;
            } 
        }
    }
}
