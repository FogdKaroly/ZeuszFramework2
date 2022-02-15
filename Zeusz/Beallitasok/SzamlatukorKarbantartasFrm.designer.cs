namespace Zeusz.Beallitasok
{
    partial class SzamlatukorKarbantartasFrm
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
            this.szamlaKivalasztasCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.konyvelhetoEChbx = new System.Windows.Forms.CheckBox();
            this.szamlaszamTxb = new System.Windows.Forms.TextBox();
            this.szamlaNevTxb = new System.Windows.Forms.TextBox();
            this.rogzitesUjkentBtn = new System.Windows.Forms.Button();
            this.rogzitesBtn = new System.Windows.Forms.Button();
            this.helyeABeszamolobanCbx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kapcsolodikIdeTxb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // kilepesBtn
            // 
            this.kilepesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kilepesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kilepesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.kilepesBtn.Location = new System.Drawing.Point(12, 12);
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
            this.label1.Location = new System.Drawing.Point(67, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Számlatükör karbantartása";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.Location = new System.Drawing.Point(32, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Számla kiválasztása";
            // 
            // szamlaKivalasztasCbx
            // 
            this.szamlaKivalasztasCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.szamlaKivalasztasCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.szamlaKivalasztasCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.szamlaKivalasztasCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.szamlaKivalasztasCbx.FormattingEnabled = true;
            this.szamlaKivalasztasCbx.Location = new System.Drawing.Point(209, 60);
            this.szamlaKivalasztasCbx.Name = "szamlaKivalasztasCbx";
            this.szamlaKivalasztasCbx.Size = new System.Drawing.Size(613, 28);
            this.szamlaKivalasztasCbx.TabIndex = 6;
            this.szamlaKivalasztasCbx.SelectedIndexChanged += new System.EventHandler(this.szamlaKivalasztasCbx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Számla száma";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Számla neve";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Helye a beszámolóban";
            // 
            // konyvelhetoEChbx
            // 
            this.konyvelhetoEChbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.konyvelhetoEChbx.AutoSize = true;
            this.konyvelhetoEChbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.konyvelhetoEChbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.konyvelhetoEChbx.Location = new System.Drawing.Point(314, 322);
            this.konyvelhetoEChbx.Name = "konyvelhetoEChbx";
            this.konyvelhetoEChbx.Size = new System.Drawing.Size(120, 24);
            this.konyvelhetoEChbx.TabIndex = 10;
            this.konyvelhetoEChbx.Text = "Könyvelhető?";
            this.konyvelhetoEChbx.UseVisualStyleBackColor = false;
            // 
            // szamlaszamTxb
            // 
            this.szamlaszamTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.szamlaszamTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.szamlaszamTxb.Location = new System.Drawing.Point(314, 141);
            this.szamlaszamTxb.Name = "szamlaszamTxb";
            this.szamlaszamTxb.Size = new System.Drawing.Size(382, 26);
            this.szamlaszamTxb.TabIndex = 11;
            this.szamlaszamTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.szamlaszamTxb_KeyPress);
            // 
            // szamlaNevTxb
            // 
            this.szamlaNevTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.szamlaNevTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.szamlaNevTxb.Location = new System.Drawing.Point(314, 200);
            this.szamlaNevTxb.Name = "szamlaNevTxb";
            this.szamlaNevTxb.Size = new System.Drawing.Size(382, 26);
            this.szamlaNevTxb.TabIndex = 12;
            // 
            // rogzitesUjkentBtn
            // 
            this.rogzitesUjkentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rogzitesUjkentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesUjkentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesUjkentBtn.Location = new System.Drawing.Point(314, 457);
            this.rogzitesUjkentBtn.MaximumSize = new System.Drawing.Size(172, 62);
            this.rogzitesUjkentBtn.Name = "rogzitesUjkentBtn";
            this.rogzitesUjkentBtn.Size = new System.Drawing.Size(172, 62);
            this.rogzitesUjkentBtn.TabIndex = 14;
            this.rogzitesUjkentBtn.Text = "Rögzítés újként";
            this.rogzitesUjkentBtn.UseVisualStyleBackColor = false;
            this.rogzitesUjkentBtn.Click += new System.EventHandler(this.rogzitesUjkentBtn_Click);
            // 
            // rogzitesBtn
            // 
            this.rogzitesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rogzitesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesBtn.Location = new System.Drawing.Point(524, 457);
            this.rogzitesBtn.MaximumSize = new System.Drawing.Size(172, 62);
            this.rogzitesBtn.Name = "rogzitesBtn";
            this.rogzitesBtn.Size = new System.Drawing.Size(172, 62);
            this.rogzitesBtn.TabIndex = 15;
            this.rogzitesBtn.Text = "Rögzítés";
            this.rogzitesBtn.UseVisualStyleBackColor = false;
            this.rogzitesBtn.Click += new System.EventHandler(this.rogzitesBtn_Click);
            // 
            // helyeABeszamolobanCbx
            // 
            this.helyeABeszamolobanCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.helyeABeszamolobanCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.helyeABeszamolobanCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.helyeABeszamolobanCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helyeABeszamolobanCbx.FormattingEnabled = true;
            this.helyeABeszamolobanCbx.Location = new System.Drawing.Point(314, 384);
            this.helyeABeszamolobanCbx.Name = "helyeABeszamolobanCbx";
            this.helyeABeszamolobanCbx.Size = new System.Drawing.Size(382, 28);
            this.helyeABeszamolobanCbx.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Kapcsolódik ide";
            // 
            // kapcsolodikIdeTxb
            // 
            this.kapcsolodikIdeTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.kapcsolodikIdeTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kapcsolodikIdeTxb.Location = new System.Drawing.Point(314, 268);
            this.kapcsolodikIdeTxb.Name = "kapcsolodikIdeTxb";
            this.kapcsolodikIdeTxb.Size = new System.Drawing.Size(382, 26);
            this.kapcsolodikIdeTxb.TabIndex = 19;
            // 
            // SzamlatukorKarbantartasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.kapcsolodikIdeTxb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.helyeABeszamolobanCbx);
            this.Controls.Add(this.rogzitesBtn);
            this.Controls.Add(this.rogzitesUjkentBtn);
            this.Controls.Add(this.szamlaNevTxb);
            this.Controls.Add(this.szamlaszamTxb);
            this.Controls.Add(this.konyvelhetoEChbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.szamlaKivalasztasCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SzamlatukorKarbantartasFrm";
            this.Text = "SzamlatukorKarbantartasFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox szamlaKivalasztasCbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox konyvelhetoEChbx;
        private System.Windows.Forms.TextBox szamlaszamTxb;
        private System.Windows.Forms.TextBox szamlaNevTxb;
        private System.Windows.Forms.Button rogzitesUjkentBtn;
        private System.Windows.Forms.Button rogzitesBtn;
        private System.Windows.Forms.ComboBox helyeABeszamolobanCbx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox kapcsolodikIdeTxb;
    }
}