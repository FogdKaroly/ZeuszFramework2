namespace Zeusz
{
    partial class BejelentkezesFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.felhasznaloCbx = new System.Windows.Forms.ComboBox();
            this.jelszoTxb = new System.Windows.Forms.TextBox();
            this.bejelentkezesBtn = new System.Windows.Forms.Button();
            this.datumLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(213, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Felhasználó";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(213, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jelszó";
            // 
            // felhasznaloCbx
            // 
            this.felhasznaloCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.felhasznaloCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.felhasznaloCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.felhasznaloCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.felhasznaloCbx.FormattingEnabled = true;
            this.felhasznaloCbx.Location = new System.Drawing.Point(292, 248);
            this.felhasznaloCbx.MaximumSize = new System.Drawing.Size(303, 0);
            this.felhasznaloCbx.Name = "felhasznaloCbx";
            this.felhasznaloCbx.Size = new System.Drawing.Size(303, 28);
            this.felhasznaloCbx.TabIndex = 2;
            // 
            // jelszoTxb
            // 
            this.jelszoTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.jelszoTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.jelszoTxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.jelszoTxb.Location = new System.Drawing.Point(292, 337);
            this.jelszoTxb.MaximumSize = new System.Drawing.Size(306, 26);
            this.jelszoTxb.Name = "jelszoTxb";
            this.jelszoTxb.PasswordChar = '*';
            this.jelszoTxb.Size = new System.Drawing.Size(306, 26);
            this.jelszoTxb.TabIndex = 3;
            // 
            // bejelentkezesBtn
            // 
            this.bejelentkezesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bejelentkezesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.bejelentkezesBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bejelentkezesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bejelentkezesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bejelentkezesBtn.Location = new System.Drawing.Point(396, 400);
            this.bejelentkezesBtn.Name = "bejelentkezesBtn";
            this.bejelentkezesBtn.Size = new System.Drawing.Size(202, 46);
            this.bejelentkezesBtn.TabIndex = 4;
            this.bejelentkezesBtn.Text = "Bejelentkezés";
            this.bejelentkezesBtn.UseVisualStyleBackColor = false;
            this.bejelentkezesBtn.Click += new System.EventHandler(this.bejelentkezesBtn_Click);
            // 
            // datumLbl
            // 
            this.datumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datumLbl.AutoSize = true;
            this.datumLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.datumLbl.Location = new System.Drawing.Point(489, 95);
            this.datumLbl.Name = "datumLbl";
            this.datumLbl.Size = new System.Drawing.Size(0, 20);
            this.datumLbl.TabIndex = 6;
            // 
            // BejelentkezesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.datumLbl);
            this.Controls.Add(this.bejelentkezesBtn);
            this.Controls.Add(this.jelszoTxb);
            this.Controls.Add(this.felhasznaloCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BejelentkezesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zeusz bejelentkezés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox felhasznaloCbx;
        private System.Windows.Forms.TextBox jelszoTxb;
        private System.Windows.Forms.Button bejelentkezesBtn;
        private System.Windows.Forms.Label datumLbl;
    }
}