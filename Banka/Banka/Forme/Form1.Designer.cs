namespace Banka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.klijenti_btn = new System.Windows.Forms.Button();
            this.sigurnosnaKontrola_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo.BackgroundImage")));
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Logo.Location = new System.Drawing.Point(210, 51);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(248, 263);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // klijenti_btn
            // 
            this.klijenti_btn.Location = new System.Drawing.Point(210, 340);
            this.klijenti_btn.Name = "klijenti_btn";
            this.klijenti_btn.Size = new System.Drawing.Size(247, 40);
            this.klijenti_btn.TabIndex = 1;
            this.klijenti_btn.Text = "Klijenti";
            this.klijenti_btn.UseVisualStyleBackColor = true;
            // 
            // sigurnosnaKontrola_btn
            // 
            this.sigurnosnaKontrola_btn.Location = new System.Drawing.Point(211, 386);
            this.sigurnosnaKontrola_btn.Name = "sigurnosnaKontrola_btn";
            this.sigurnosnaKontrola_btn.Size = new System.Drawing.Size(247, 40);
            this.sigurnosnaKontrola_btn.TabIndex = 3;
            this.sigurnosnaKontrola_btn.Text = "Sigurnosna Kontrola";
            this.sigurnosnaKontrola_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(650, 526);
            this.Controls.Add(this.sigurnosnaKontrola_btn);
            this.Controls.Add(this.klijenti_btn);
            this.Controls.Add(this.Logo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button klijenti_btn;
        private System.Windows.Forms.Button sigurnosnaKontrola_btn;
    }
}

