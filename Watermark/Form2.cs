using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermark
{
    public partial class Form2 : Form
    {
        string[] args;
        public Form2(string[] arguments)
        {
            InitializeComponent();
            args = arguments;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }

        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
            int num = 0;
            string orgname = "Watermark";
            string othertext = "Send text through command line\n{white}{tred}For help goto {https://watermark.nathanwoodburn.tk}\nCreated by Nathan Woodburn\nnathan@woodburn.tk\n\n";


            //watermarkapp.tk
                  //https://cutt.ly/watermark
                  //https://cutt.ly/watermarkargs
                  //dropbox link https://rb.gy/ibi3hv
                  //onedrive link https://rb.gy/l6zjle

                //othertext = "Click here to {close}";
                //for (int i = 0; i < args.Length; i++)
                //{
                //    if (i == 1)
                //    {
                //        orgname = args[0];
                //    }
                //    else if (i == 2)
                //    {
                //        othertext = args[1];
                //    }
                //}

                int i = 0;
            //if (args[0] == "SETTEXT")
            //{
                
            //}
            foreach (string arg in args)
            {
                switch (i)
                {
                    case 0:
                        orgname = arg;
                        break;
                    case 1:
                        othertext = arg;
                        break;
                    default:
                        othertext = othertext + "\n" + arg;
                        break;
                        
                }
                i++;
            }
            foreach (Screen scree in Screen.AllScreens)
            {
                Form1 form3 = new Form1(num,orgname,othertext);
                form3.Show();
                num++;
            }
        }
    }
}
