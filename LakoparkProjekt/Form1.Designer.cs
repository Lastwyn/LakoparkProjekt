namespace LakoparkProjekt
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.jobb = new System.Windows.Forms.PictureBox();
            this.bal = new System.Windows.Forms.PictureBox();
            this.kep = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jobb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kep)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(214, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 291);
            this.panel1.TabIndex = 0;
            // 
            // jobb
            // 
            this.jobb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.jobb.Location = new System.Drawing.Point(482, 388);
            this.jobb.Name = "jobb";
            this.jobb.Size = new System.Drawing.Size(100, 50);
            this.jobb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.jobb.TabIndex = 3;
            this.jobb.TabStop = false;
            this.jobb.Click += new System.EventHandler(this.jobb_Click);
            // 
            // bal
            // 
            this.bal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bal.Location = new System.Drawing.Point(280, 388);
            this.bal.Name = "bal";
            this.bal.Size = new System.Drawing.Size(100, 50);
            this.bal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bal.TabIndex = 2;
            this.bal.TabStop = false;
            this.bal.Click += new System.EventHandler(this.bal_Click);
            // 
            // kep
            // 
            this.kep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kep.Location = new System.Drawing.Point(51, 48);
            this.kep.Name = "kep";
            this.kep.Size = new System.Drawing.Size(100, 114);
            this.kep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kep.TabIndex = 1;
            this.kep.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mentés";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jobb);
            this.Controls.Add(this.bal);
            this.Controls.Add(this.kep);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jobb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox kep;
        private System.Windows.Forms.PictureBox bal;
        private System.Windows.Forms.PictureBox jobb;
        private System.Windows.Forms.Button button1;
    }
}

