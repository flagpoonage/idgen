using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH.Codesequences.Harness
{
    public partial class ASCIICheckboard : UserControl
    {        
        public delegate void PressEvent(ASCIIPressbox sender);

        public event PressEvent Pressed;

        public ASCIICheckboard()
        {
            InitializeComponent();

            this.GenerateCheckboard();
        }

        private void GenerateCheckboard()
        {
            var characterString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,/:;\"'[]{}+=_-()*&^%$#@!~|\\";

            var characters = characterString.ToCharArray();

            var bytes = Encoding.ASCII.GetBytes(characterString);
            
            for(int i = 0; i < characters.Length; i++)
            {
                var pBox = new ASCIIPressbox();

                pBox.Value = bytes[i];

                pBox.Character = characters[i];

                var rowsPassed = (int)(i / 17); // 17 number of 30px keys can fit into 510px
                
                var keysOnRow = i - (rowsPassed * 17);

                pBox.Left = keysOnRow * 30;

                pBox.Top = rowsPassed * 30;

                pBox.Clicked += pBox_Clicked;

                this.Controls.Add(pBox);
            }
        }

        void pBox_Clicked(ASCIIPressbox sender)
        {
            if (this.Pressed != null)
            {
                this.Pressed(sender);
            }
        }

        internal void PressButtons(byte[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                foreach (ASCIIPressbox press in this.Controls)
                {
                    if (press.Value == values[i])
                    {
                        press.Check();
                        break;
                    }
                }
            }
        }

        internal void Unpress()
        {
            foreach (ASCIIPressbox press in this.Controls)
            {
                press.Uncheck();
            }
        }
    }
}
