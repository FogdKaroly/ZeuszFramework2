namespace Zeusz.Lekerdezesek
{
    partial class NyitottSzallitoLezarasaFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.szamlaszamLbl = new System.Windows.Forms.Label();
            this.gazdasagiEsemenyLbl = new System.Windows.Forms.Label();
            this.tartozikOsszegLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tartozikSzamlaLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.partnerNeveLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kSzamlaCbx = new System.Windows.Forms.ComboBox();
            this.kSzamlaTxb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rogzitesBtn = new System.Windows.Forms.Button();
            this.idLbl = new System.Windows.Forms.Label();
            this.partnerkodLbl = new System.Windows.Forms.Label();
            this.teljesitesDtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(60, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nyitott szállító tételek lezárása";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.szamlaszamLbl);
            this.groupBox1.Controls.Add(this.gazdasagiEsemenyLbl);
            this.groupBox1.Controls.Add(this.tartozikOsszegLbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tartozikSzamlaLbl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.partnerNeveLbl);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 242);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Könyvelés adatai";
            // 
            // szamlaszamLbl
            // 
            this.szamlaszamLbl.AutoSize = true;
            this.szamlaszamLbl.Location = new System.Drawing.Point(710, 46);
            this.szamlaszamLbl.Name = "szamlaszamLbl";
            this.szamlaszamLbl.Size = new System.Drawing.Size(100, 20);
            this.szamlaszamLbl.TabIndex = 6;
            this.szamlaszamLbl.Text = "Számlaszám";
            // 
            // gazdasagiEsemenyLbl
            // 
            this.gazdasagiEsemenyLbl.AutoSize = true;
            this.gazdasagiEsemenyLbl.Location = new System.Drawing.Point(27, 200);
            this.gazdasagiEsemenyLbl.Name = "gazdasagiEsemenyLbl";
            this.gazdasagiEsemenyLbl.Size = new System.Drawing.Size(150, 20);
            this.gazdasagiEsemenyLbl.TabIndex = 5;
            this.gazdasagiEsemenyLbl.Text = "gazdasági esemény";
            // 
            // tartozikOsszegLbl
            // 
            this.tartozikOsszegLbl.AutoSize = true;
            this.tartozikOsszegLbl.Location = new System.Drawing.Point(174, 144);
            this.tartozikOsszegLbl.Name = "tartozikOsszegLbl";
            this.tartozikOsszegLbl.Size = new System.Drawing.Size(116, 20);
            this.tartozikOsszegLbl.TabIndex = 4;
            this.tartozikOsszegLbl.Text = "tartozik összeg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tartozik összeg:";
            // 
            // tartozikSzamlaLbl
            // 
            this.tartozikSzamlaLbl.AutoSize = true;
            this.tartozikSzamlaLbl.Location = new System.Drawing.Point(132, 92);
            this.tartozikSzamlaLbl.Name = "tartozikSzamlaLbl";
            this.tartozikSzamlaLbl.Size = new System.Drawing.Size(115, 20);
            this.tartozikSzamlaLbl.TabIndex = 2;
            this.tartozikSzamlaLbl.Text = "tartozik számla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tartozik:";
            // 
            // partnerNeveLbl
            // 
            this.partnerNeveLbl.AutoSize = true;
            this.partnerNeveLbl.Location = new System.Drawing.Point(27, 46);
            this.partnerNeveLbl.Name = "partnerNeveLbl";
            this.partnerNeveLbl.Size = new System.Drawing.Size(99, 20);
            this.partnerNeveLbl.TabIndex = 0;
            this.partnerNeveLbl.Text = "Partner neve";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kSzamlaCbx);
            this.groupBox2.Controls.Add(this.kSzamlaTxb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1005, 144);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kiegyenlítés";
            // 
            // kSzamlaCbx
            // 
            this.kSzamlaCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kSzamlaCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kSzamlaCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kSzamlaCbx.FormattingEnabled = true;
            this.kSzamlaCbx.Location = new System.Drawing.Point(27, 86);
            this.kSzamlaCbx.Name = "kSzamlaCbx";
            this.kSzamlaCbx.Size = new System.Drawing.Size(972, 28);
            this.kSzamlaCbx.TabIndex = 2;
            this.kSzamlaCbx.SelectedIndexChanged += new System.EventHandler(this.kSzamlaCbx_SelectedIndexChanged);
            // 
            // kSzamlaTxb
            // 
            this.kSzamlaTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kSzamlaTxb.Location = new System.Drawing.Point(152, 35);
            this.kSzamlaTxb.Name = "kSzamlaTxb";
            this.kSzamlaTxb.Size = new System.Drawing.Size(151, 26);
            this.kSzamlaTxb.TabIndex = 1;
            this.kSzamlaTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kSzamlaTxb_KeyPress);
            this.kSzamlaTxb.Leave += new System.EventHandler(this.kSzamlaTxb_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Követel számla";
            // 
            // rogzitesBtn
            // 
            this.rogzitesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rogzitesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesBtn.Location = new System.Drawing.Point(817, 507);
            this.rogzitesBtn.Name = "rogzitesBtn";
            this.rogzitesBtn.Size = new System.Drawing.Size(194, 52);
            this.rogzitesBtn.TabIndex = 9;
            this.rogzitesBtn.Text = "Rögzítés";
            this.rogzitesBtn.UseVisualStyleBackColor = false;
            this.rogzitesBtn.Click += new System.EventHandler(this.rogzitesBtn_Click);
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(522, 17);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(0, 20);
            this.idLbl.TabIndex = 10;
            this.idLbl.Visible = false;
            // 
            // partnerkodLbl
            // 
            this.partnerkodLbl.AutoSize = true;
            this.partnerkodLbl.Location = new System.Drawing.Point(668, 19);
            this.partnerkodLbl.Name = "partnerkodLbl";
            this.partnerkodLbl.Size = new System.Drawing.Size(0, 20);
            this.partnerkodLbl.TabIndex = 11;
            this.partnerkodLbl.Visible = false;
            // 
            // teljesitesDtp
            // 
            this.teljesitesDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.teljesitesDtp.Location = new System.Drawing.Point(127, 484);
            this.teljesitesDtp.Name = "teljesitesDtp";
            this.teljesitesDtp.Size = new System.Drawing.Size(132, 26);
            this.teljesitesDtp.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Teljesítés";
            // 
            // NyitottSzallitoLezarasaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.teljesitesDtp);
            this.Controls.Add(this.partnerkodLbl);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.rogzitesBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NyitottSzallitoLezarasaFrm";
            this.Text = "NyitottSzallitoFrm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label partnerNeveLbl;
        private System.Windows.Forms.Label tartozikSzamlaLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tartozikOsszegLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label gazdasagiEsemenyLbl;
        private System.Windows.Forms.Label szamlaszamLbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox kSzamlaTxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox kSzamlaCbx;
        private System.Windows.Forms.Button rogzitesBtn;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label partnerkodLbl;
        private System.Windows.Forms.DateTimePicker teljesitesDtp;
        private System.Windows.Forms.Label label5;
    }
}