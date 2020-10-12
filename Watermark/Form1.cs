using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Watermark
{
    public partial class Form1 : Form
    {
        string underlinedtext = "Nathan Woodburn";
        string othertext = "nathan.woodburn2611@gmail.com\nother stuff\n";
        string oldtext;
        int screennum;
        public Form1(int screen,string text1,string text2)
        {
            InitializeComponent();
            screennum = screen;
            underlinedtext = text1;
            othertext = text2;
        }
        bool clickable;
        string email;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            clickable = false;
           
            label1.Text = underlinedtext;
            //label2.Text = othertext + "\nMachine Name: " + Environment.MachineName + "\n\n";
            
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
                    email = output;
                    if (email.ToLower() == "black")
                    {
                        label2.ForeColor = Color.Black;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "white")
                    {
                        label2.ForeColor = Color.White;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "red")
                    {
                        label2.ForeColor = Color.Red;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "green")
                    {
                        label2.ForeColor = Color.Green;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "brown")
                    {
                        label2.ForeColor = Color.Brown;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "tblack")
                    {
                        label1.ForeColor = Color.Black;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "twhite")
                    {
                        label1.ForeColor = Color.White;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "tred")
                    {
                        label1.ForeColor = Color.Red;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "tgreen")
                    {
                        label1.ForeColor = Color.Green;
                        othertext = othertext.Replace("{" + email + "}", "");
                    }
                    else if (email.ToLower() == "tbrown")
                    {
                        label1.ForeColor = Color.SaddleBrown;
                        othertext = othertext.Replace("{" + email + "}", "");
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
           
            
            
            //othertext = othertext.Replace("{SYSSIZE}", Environment.SystemPageSize.ToString());            
            //othertext = othertext.Replace("{SYSSIZEFORMAT}", FormatBytes(Environment.SystemPageSize));
            //othertext = othertext.Replace("{TICKCOUNT}", Environment.TickCount.ToString());
            //othertext = othertext.Replace("{WORKINGSET}", FormatBytes(Environment.WorkingSet));
            //            { SYSSIZE}
            //            Size of systems memory page in bytes
            //{ SYSSIZEFORMAT}
            //            Size of systems memory page in best match
            //{ TICKCOUNT}
            //            milliseconds since system started
            //{ WORKINGSET}
            //            amount of physical memory mapped to the process context


            label2.Text = othertext;
            //this.AutoSize = false;
            
            //this.Height = this.Height + 100;
            this.Location = Screen.AllScreens[screennum].WorkingArea.Location;
            this.Left = Screen.AllScreens[screennum].WorkingArea.X + Screen.AllScreens[screennum].Bounds.Width - this.Width - 70;
            this.Top = Screen.AllScreens[screennum].WorkingArea.Y + Screen.AllScreens[screennum].Bounds.Height - this.Height - 50;
            this.SendToBack();
        }
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
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
        private void Form1_Activated(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F16)
            //{

            //    if (this.TransparencyKey == Color.White)
            //        this.TransparencyKey = this.BackColor;
            //    else
            //        this.TransparencyKey = Color.White;
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (Clipboard.GetText() == label1.Text || Clipboard.GetText() == label2.Text)
            {
                Clipboard.Clear();
            }
            if (clickable)
            {
                try
                {
                    if (IsValidEmail(email))
                    {
                        Process.Start("mailto:" + email);
                    }
                    //else if (email.ToLower() == "exit")
                    //{
                    //    Environment.Exit(1);
                    //}
                    else
                    {
                        Process.Start(email);
                        //MessageBox.Show("HJ");
                    }
                }
                catch
                {
                    
                }
                

            }
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SendToBack();
            timer1.Stop();
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
            label2.Text = othertext;
        }
    }
}
