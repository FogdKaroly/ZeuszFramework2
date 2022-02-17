namespace Zeusz.Lekerdezesek
{
    partial class VezetoiInfoFrm
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
            this.osszesKtsgBtn = new System.Windows.Forms.Button();
            this.mutatoszamokBtn = new System.Windows.Forms.Button();
            this.egyeniLekerdezes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bevetelKtsgAranyBtn = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(57, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vezetői információk";
            // 
            // osszesKtsgBtn
            // 
            this.osszesKtsgBtn.Location = new System.Drawing.Point(12, 64);
            this.osszesKtsgBtn.Name = "osszesKtsgBtn";
            this.osszesKtsgBtn.Size = new System.Drawing.Size(810, 46);
            this.osszesKtsgBtn.TabIndex = 9;
            this.osszesKtsgBtn.Text = "Összes költség";
            this.osszesKtsgBtn.UseVisualStyleBackColor = true;
            this.osszesKtsgBtn.Click += new System.EventHandler(this.osszesKtsgBtn_Click);
            // 
            // mutatoszamokBtn
            // 
            this.mutatoszamokBtn.Location = new System.Drawing.Point(12, 129);
            this.mutatoszamokBtn.Name = "mutatoszamokBtn";
            this.mutatoszamokBtn.Size = new System.Drawing.Size(810, 46);
            this.mutatoszamokBtn.TabIndex = 10;
            this.mutatoszamokBtn.Text = "Mutatószámok";
            this.mutatoszamokBtn.UseVisualStyleBackColor = true;
            this.mutatoszamokBtn.Click += new System.EventHandler(this.mutatoszamokBtn_Click);
            // 
            // egyeniLekerdezes
            // 
            this.egyeniLekerdezes.Location = new System.Drawing.Point(12, 197);
            this.egyeniLekerdezes.Name = "egyeniLekerdezes";
            this.egyeniLekerdezes.Size = new System.Drawing.Size(810, 46);
            this.egyeniLekerdezes.TabIndex = 11;
            this.egyeniLekerdezes.Text = "Egyéni lekérdezés";
            this.egyeniLekerdezes.UseVisualStyleBackColor = true;
            this.egyeniLekerdezes.Click += new System.EventHandler(this.egyeniLekerdezes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(810, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Adók elemzése";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bevetelKtsgAranyBtn
            // 
            this.bevetelKtsgAranyBtn.Location = new System.Drawing.Point(12, 330);
            this.bevetelKtsgAranyBtn.Name = "bevetelKtsgAranyBtn";
            this.bevetelKtsgAranyBtn.Size = new System.Drawing.Size(810, 46);
            this.bevetelKtsgAranyBtn.TabIndex = 13;
            this.bevetelKtsgAranyBtn.Text = "Bevételek és költségek aránya";
            this.bevetelKtsgAranyBtn.UseVisualStyleBackColor = true;
            this.bevetelKtsgAranyBtn.Click += new System.EventHandler(this.bevetelKtsgAranyBtn_Click);
            // 
            // VezetoiInfoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.bevetelKtsgAranyBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.egyeniLekerdezes);
            this.Controls.Add(this.mutatoszamokBtn);
            this.Controls.Add(this.osszesKtsgBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VezetoiInfoFrm";
            this.Text = "VezetoiInfoFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button osszesKtsgBtn;
        private System.Windows.Forms.Button mutatoszamokBtn;
        private System.Windows.Forms.Button egyeniLekerdezes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bevetelKtsgAranyBtn;
    }
}