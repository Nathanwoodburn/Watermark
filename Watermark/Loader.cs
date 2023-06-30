using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Watermark
{
    public partial class Loader : Form
    {
        string[] args;
        public Loader(string[] arguments)
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
        string orgname = "Watermark";
        string othertext = "Send text through command line\n{white}{tred}For help goto {https://github.com/Nathanwoodburn/Watermark}\nCreated by Nathan Woodburn\nnathan@woodburn.au\n\n";
        MainForm[] watermarks;
        private void Form2_Load(object sender, EventArgs e)
        {
            int argNum = 0;
            foreach (string arg in args)
            {
                switch (argNum)
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
                argNum++;
            }
            watermarks = new MainForm[Screen.AllScreens.Count()];
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                watermarks[i] = new MainForm(i, orgname, othertext);
                watermarks[i].Show();
            }
            SystemEvents.DisplaySettingsChanged += RefreshScreens;
        }

        private void RefreshScreens(object sender, EventArgs e)
        {
            foreach (MainForm form in watermarks)
            {
                form.Close();
            }
            watermarks = new MainForm[Screen.AllScreens.Count()];
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                watermarks[i] = new MainForm(i, orgname, othertext);
                watermarks[i].Show();
            }
        }
    }
}
