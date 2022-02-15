namespace Zeusz.Konyveles
{
    partial class UjVegyesKonyveleseFrm
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
            this.gazdasagiEsemenyTxb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kOsszegTxb = new System.Windows.Forms.TextBox();
            this.kSzamlaCbx = new System.Windows.Forms.ComboBox();
            this.kSzamlaTxb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tOsszegTxb = new System.Windows.Forms.TextBox();
            this.tSzamlaCbx = new System.Windows.Forms.ComboBox();
            this.tSzamlaTxb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rogzitesBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Új vegyes tétel könyvelése";
            // 
            // gazdasagiEsemenyTxb
            // 
            this.gazdasagiEsemenyTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gazdasagiEsemenyTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.gazdasagiEsemenyTxb.Location = new System.Drawing.Point(172, 456);
            this.gazdasagiEsemenyTxb.Name = "gazdasagiEsemenyTxb";
            this.gazdasagiEsemenyTxb.Size = new System.Drawing.Size(650, 26);
            this.gazdasagiEsemenyTxb.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.kOsszegTxb);
            this.groupBox2.Controls.Add(this.kSzamlaCbx);
            this.groupBox2.Controls.Add(this.kSzamlaTxb);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 254);
            this.groupBox2.MaximumSize = new System.Drawing.Size(810, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(810, 178);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Követel";
            // 
            // kOsszegTxb
            // 
            this.kOsszegTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kOsszegTxb.Location = new System.Drawing.Point(141, 130);
            this.kOsszegTxb.Name = "kOsszegTxb";
            this.kOsszegTxb.Size = new System.Drawing.Size(663, 26);
            this.kOsszegTxb.TabIndex = 9;
            this.kOsszegTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kOsszegTxb_KeyPress);
            this.kOsszegTxb.Leave += new System.EventHandler(this.kOsszegTxb_Leave);
            // 
            // kSzamlaCbx
            // 
            this.kSzamlaCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kSzamlaCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kSzamlaCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kSzamlaCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.kSzamlaCbx.FormattingEnabled = true;
            this.kSzamlaCbx.Location = new System.Drawing.Point(6, 84);
            this.kSzamlaCbx.Name = "kSzamlaCbx";
            this.kSzamlaCbx.Size = new System.Drawing.Size(798, 24);
            this.kSzamlaCbx.TabIndex = 8;
            this.kSzamlaCbx.SelectedIndexChanged += new System.EventHandler(this.kSzamlaCbx_SelectedIndexChanged);
            // 
            // kSzamlaTxb
            // 
            this.kSzamlaTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kSzamlaTxb.Location = new System.Drawing.Point(141, 35);
            this.kSzamlaTxb.Name = "kSzamlaTxb";
            this.kSzamlaTxb.Size = new System.Drawing.Size(663, 26);
            this.kSzamlaTxb.TabIndex = 7;
            this.kSzamlaTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kSzamlaTxb_KeyPress);
            this.kSzamlaTxb.Leave += new System.EventHandler(this.kSzamlaTxb_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Követel összeg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Követel számla";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 459);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Gazdasági esemény";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.tOsszegTxb);
            this.groupBox1.Controls.Add(this.tSzamlaCbx);
            this.groupBox1.Controls.Add(this.tSzamlaTxb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.MaximumSize = new System.Drawing.Size(810, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 178);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tartozik";
            // 
            // tOsszegTxb
            // 
            this.tOsszegTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tOsszegTxb.Location = new System.Drawing.Point(141, 130);
            this.tOsszegTxb.Name = "tOsszegTxb";
            this.tOsszegTxb.Size = new System.Drawing.Size(663, 26);
            this.tOsszegTxb.TabIndex = 4;
            this.tOsszegTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tOsszegTxb_KeyPress);
            this.tOsszegTxb.Leave += new System.EventHandler(this.tOsszegTxb_Leave);
            // 
            // tSzamlaCbx
            // 
            this.tSzamlaCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tSzamlaCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSzamlaCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tSzamlaCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tSzamlaCbx.FormattingEnabled = true;
            this.tSzamlaCbx.Location = new System.Drawing.Point(6, 84);
            this.tSzamlaCbx.Name = "tSzamlaCbx";
            this.tSzamlaCbx.Size = new System.Drawing.Size(798, 24);
            this.tSzamlaCbx.TabIndex = 3;
            this.tSzamlaCbx.SelectedIndexChanged += new System.EventHandler(this.tSzamlaCbx_SelectedIndexChanged);
            // 
            // tSzamlaTxb
            // 
            this.tSzamlaTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tSzamlaTxb.Location = new System.Drawing.Point(141, 35);
            this.tSzamlaTxb.Name = "tSzamlaTxb";
            this.tSzamlaTxb.Size = new System.Drawing.Size(663, 26);
            this.tSzamlaTxb.TabIndex = 2;
            this.tSzamlaTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSzamlaTxb_KeyPress);
            this.tSzamlaTxb.Leave += new System.EventHandler(this.tSzamlaTxb_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tartozik összeg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tartozik számla";
            // 
            // rogzitesBtn
            // 
            this.rogzitesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rogzitesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesBtn.Location = new System.Drawing.Point(641, 534);
            this.rogzitesBtn.MaximumSize = new System.Drawing.Size(181, 70);
            this.rogzitesBtn.Name = "rogzitesBtn";
            this.rogzitesBtn.Size = new System.Drawing.Size(181, 70);
            this.rogzitesBtn.TabIndex = 43;
            this.rogzitesBtn.Text = "Rögzítés";
            this.rogzitesBtn.UseVisualStyleBackColor = false;
            this.rogzitesBtn.Click += new System.EventHandler(this.rogzitesBtn_Click);
            // 
            // UjVegyesKonyveleseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.rogzitesBtn);
            this.Controls.Add(this.gazdasagiEsemenyTxb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UjVegyesKonyveleseFrm";
            this.Text = "UjVegyesKonyveleseFrm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gazdasagiEsemenyTxb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox kOsszegTxb;
        private System.Windows.Forms.ComboBox kSzamlaCbx;
        private System.Windows.Forms.TextBox kSzamlaTxb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tOsszegTxb;
        private System.Windows.Forms.ComboBox tSzamlaCbx;
        private System.Windows.Forms.TextBox tSzamlaTxb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button rogzitesBtn;
    }
}