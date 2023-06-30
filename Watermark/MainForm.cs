using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Watermark
{
    public partial class MainForm : Form
    {
        string underlinedtext = "Nathan Woodburn";
        string othertext = "nathan@woodburn.au\nother stuff\n";
        string oldtext;
        int screennum;
        public MainForm(int screen,string text1,string text2)
        {
            InitializeComponent();
            screennum = screen;
            underlinedtext = text1;
            othertext = text2;
        }
        bool clickable;
        string arg;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            clickable = false;           
            label1.Text = underlinedtext;            
            othertext = othertext.Replace("{MACHINENAME}", Environment.MachineName);
            othertext = othertext.Replace("{USERNAME}", Environment.UserName);
            othertext = othertext.Replace("{USERDNAME}", Environment.UserDomainName);
            othertext = othertext.Replace("{PROCESSORCOUNT}", Environment.ProcessorCount.ToString());
            bool exists = true;
            do
            {
                try
                {
                    string input = othertext;
                    string output = input.Split('{', '}')[1];
                    arg = output;
                    if (arg.ToLower() == "black")
                    {
                        BodyText.ForeColor = Color.Black;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "white")
                    {
                        BodyText.ForeColor = Color.White;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "red")
                    {
                        BodyText.ForeColor = Color.Red;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "green")
                    {
                        BodyText.ForeColor = Color.Green;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "brown")
                    {
                        BodyText.ForeColor = Color.Brown;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "tblack")
                    {
                        label1.ForeColor = Color.Black;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "twhite")
                    {
                        label1.ForeColor = Color.White;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "tred")
                    {
                        label1.ForeColor = Color.Red;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "tgreen")
                    {
                        label1.ForeColor = Color.Green;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else if (arg.ToLower() == "tbrown")
                    {
                        label1.ForeColor = Color.SaddleBrown;
                        othertext = othertext.Replace("{" + arg + "}", "");
                    }
                    else
                    {
                        othertext = othertext.Replace("{", "");
                        othertext = othertext.Replace("}", "");
                        clickable = true;
                    }
                }
                catch (Exception)
                {
                    exists = false;
                }
            } while (exists);
            oldtext = othertext;
            if (othertext.Contains("{TIME}"))
            {
                othertext.Replace("{TIME}", DateTime.Now.ToLongTimeString());
                timetimer.Start();
            }
           
            
            
            BodyText.Text = othertext;
            this.Location = Screen.AllScreens[screennum].WorkingArea.Location;
            this.Left = Screen.AllScreens[screennum].WorkingArea.X + Screen.AllScreens[screennum].Bounds.Width - this.Width - 70;
            this.Top = Screen.AllScreens[screennum].WorkingArea.Y + Screen.AllScreens[screennum].Bounds.Height - this.Height - 50;
            this.SendToBack();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            // Send the form to the back when clicked to stop it from being in the way of other windows
            this.SendToBack();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Don't allow the form to be closed by the user (using ALT+F4)
            if (e.CloseReason == CloseReason.UserClosing) e.Cancel = true;
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
        private void MainForm_Activated(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void TitleText_DoubleClick(object sender, EventArgs e)
        {
            if (Clipboard.GetText() == label1.Text || Clipboard.GetText() == BodyText.Text)
            {
                Clipboard.Clear();
            }
            if (clickable)
            {
                try
                {
                    if (IsValidEmail(arg)) Process.Start("mailto:" + arg);
                    else Process.Start(arg);
                }
                catch
                {
                    // Do nothing to prevent crashing
                }
            }
        }

        private void OnLoad_Tick(object sender, EventArgs e)
        {
            // Catch the form when it is loaded and send it to the back
            this.SendToBack();
            OnLoadTimer.Stop();
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void timetimer_Tick(object sender, EventArgs e)
        {
            othertext = oldtext.Replace("{TIME}", DateTime.Now.ToLongTimeString());
            BodyText.Text = othertext;
        }
    }
}
