namespace Zeusz
{
    partial class FelhasznalokKezeleseFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.felhasznalokCbx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.felhasznalonevTxb = new System.Windows.Forms.TextBox();
            this.jelszoTxb = new System.Windows.Forms.TextBox();
            this.beosztasTxb = new System.Windows.Forms.TextBox();
            this.emailTxb = new System.Windows.Forms.TextBox();
            this.rogzitesUjkentBtn = new System.Windows.Forms.Button();
            this.modositasBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kilepesBtn
            // 
            this.kilepesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kilepesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kilepesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Felhasználók kezelése";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Felhasználónév";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(306, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Válassza ki a felhasználót:";
            // 
            // felhasznalokCbx
            // 
            this.felhasznalokCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.felhasznalokCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.felhasznalokCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.felhasznalokCbx.FormattingEnabled = true;
            this.felhasznalokCbx.Location = new System.Drawing.Point(535, 14);
            this.felhasznalokCbx.Name = "felhasznalokCbx";
            this.felhasznalokCbx.Size = new System.Drawing.Size(287, 28);
            this.felhasznalokCbx.TabIndex = 5;
            this.felhasznalokCbx.SelectedIndexChanged += new System.EventHandler(this.felhasznalokCbx_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jelszó";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Beosztás";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email";
            // 
            // felhasznalonevTxb
            // 
            this.felhasznalonevTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.felhasznalonevTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.felhasznalonevTxb.Location = new System.Drawing.Point(308, 107);
            this.felhasznalonevTxb.Name = "felhasznalonevTxb";
            this.felhasznalonevTxb.Size = new System.Drawing.Size(412, 26);
            this.felhasznalonevTxb.TabIndex = 9;
            // 
            // jelszoTxb
            // 
            this.jelszoTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.jelszoTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.jelszoTxb.Location = new System.Drawing.Point(308, 167);
            this.jelszoTxb.Name = "jelszoTxb";
            this.jelszoTxb.PasswordChar = '*';
            this.jelszoTxb.Size = new System.Drawing.Size(412, 26);
            this.jelszoTxb.TabIndex = 10;
            // 
            // beosztasTxb
            // 
            this.beosztasTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.beosztasTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.beosztasTxb.Location = new System.Drawing.Point(308, 229);
            this.beosztasTxb.Name = "beosztasTxb";
            this.beosztasTxb.Size = new System.Drawing.Size(412, 26);
            this.beosztasTxb.TabIndex = 11;
            // 
            // emailTxb
            // 
            this.emailTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.emailTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.emailTxb.Location = new System.Drawing.Point(308, 289);
            this.emailTxb.Name = "emailTxb";
            this.emailTxb.Size = new System.Drawing.Size(412, 26);
            this.emailTxb.TabIndex = 12;
            // 
            // rogzitesUjkentBtn
            // 
            this.rogzitesUjkentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rogzitesUjkentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesUjkentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesUjkentBtn.Location = new System.Drawing.Point(126, 356);
            this.rogzitesUjkentBtn.MaximumSize = new System.Drawing.Size(217, 68);
            this.rogzitesUjkentBtn.Name = "rogzitesUjkentBtn";
            this.rogzitesUjkentBtn.Size = new System.Drawing.Size(217, 68);
            this.rogzitesUjkentBtn.TabIndex = 19;
            this.rogzitesUjkentBtn.Text = "Rögzítés újként";
            this.rogzitesUjkentBtn.UseVisualStyleBackColor = false;
            this.rogzitesUjkentBtn.Click += new System.EventHandler(this.rogzitesUjkentBtn_Click);
            // 
            // modositasBtn
            // 
            this.modositasBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.modositasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.modositasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modositasBtn.Location = new System.Drawing.Point(503, 356);
            this.modositasBtn.MaximumSize = new System.Drawing.Size(217, 68);
            this.modositasBtn.Name = "modositasBtn";
            this.modositasBtn.Size = new System.Drawing.Size(217, 68);
            this.modositasBtn.TabIndex = 20;
            this.modositasBtn.Text = "Módosítás";
            this.modositasBtn.UseVisualStyleBackColor = false;
            this.modositasBtn.Click += new System.EventHandler(this.modositasBtn_Click);
            // 
            // FelhasznalokKezeleseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.modositasBtn);
            this.Controls.Add(this.rogzitesUjkentBtn);
            this.Controls.Add(this.emailTxb);
            this.Controls.Add(this.beosztasTxb);
            this.Controls.Add(this.jelszoTxb);
            this.Controls.Add(this.felhasznalonevTxb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.felhasznalokCbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FelhasznalokKezeleseFrm";
            this.Text = "FelhasznalokKezeleseFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox felhasznalokCbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox felhasznalonevTxb;
        private System.Windows.Forms.TextBox jelszoTxb;
        private System.Windows.Forms.TextBox beosztasTxb;
        private System.Windows.Forms.TextBox emailTxb;
        private System.Windows.Forms.Button rogzitesUjkentBtn;
        private System.Windows.Forms.Button modositasBtn;
    }
}