namespace Zeusz.Konyveles
{
    partial class ZarasFrm
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
            this.kilepesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zarasBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kilepesBtn
            // 
            this.kilepesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kilepesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kilepesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.kilepesBtn.Location = new System.Drawing.Point(12, 12);
            this.kilepesBtn.MaximumSize = new System.Drawing.Size(25, 25);
            this.kilepesBtn.Name = "kilepesBtn";
            this.kilepesBtn.Size = new System.Drawing.Size(25, 25);
            this.kilepesBtn.TabIndex = 0;
            this.kilepesBtn.Text = "X";
            this.kilepesBtn.UseVisualStyleBackColor = false;
            this.kilepesBtn.Click += new System.EventHandler(this.kilepesBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(55, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Zárás elkészítése";
            // 
            // zarasBtn
            // 
            this.zarasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.zarasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zarasBtn.Location = new System.Drawing.Point(682, 591);
            this.zarasBtn.Name = "zarasBtn";
            this.zarasBtn.Size = new System.Drawing.Size(140, 58);
            this.zarasBtn.TabIndex = 14;
            this.zarasBtn.Text = "Zárás indítása";
            this.zarasBtn.UseVisualStyleBackColor = false;
            this.zarasBtn.Click += new System.EventHandler(this.zarasBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "A művelet zárja az eredmény és mérlegszámlákat!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "A társasági adó lekönyvelése szükséges a hibátlan záráshoz";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 591);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 58);
            this.button1.TabIndex = 17;
            this.button1.Text = "Zárás visszavonása";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(366, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Az adózott eredmény automatikusan lekönyvelődik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(515, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ha lezárjuk az évet, akkor nem lesz lehetőség új könyvelési tételt felvinni";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(360, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "A nyitott vevő és szállító tételeket zárni szükséges";
            // 
            // ZarasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zarasBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ZarasFrm";
            this.Text = "ZarasFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zarasBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}