namespace Watermark
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BodyText = new System.Windows.Forms.Label();
            this.OnLoadTimer = new System.Windows.Forms.Timer(this.components);
            this.timetimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nathan Woodburn";
            this.label1.DoubleClick += new System.EventHandler(this.TitleText_DoubleClick);
            // 
            // label2
            // 
            this.BodyText.AutoSize = true;
            this.BodyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BodyText.ForeColor = System.Drawing.Color.White;
            this.BodyText.Location = new System.Drawing.Point(13, 49);
            this.BodyText.Name = "label2";
            this.BodyText.Size = new System.Drawing.Size(111, 25);
            this.BodyText.TabIndex = 1;
            this.BodyText.Text = "More Stuff";
            this.BodyText.DoubleClick += new System.EventHandler(this.TitleText_DoubleClick);
            // 
            // timer1
            // 
            this.OnLoadTimer.Enabled = true;
            this.OnLoadTimer.Tick += new System.EventHandler(this.OnLoad_Tick);
            // 
            // timetimer
            // 
            this.timetimer.Tick += new System.EventHandler(this.timetimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(403, 450);
            this.Controls.Add(this.BodyText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Watermark";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.DoubleClick += new System.EventHandler(this.TitleText_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BodyText;
        private System.Windows.Forms.Timer OnLoadTimer;
        private System.Windows.Forms.Timer timetimer;
    }
}

