namespace Zeusz.Lekerdezesek
{
    partial class NyitottVevoLezarasaFrm
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
            this.gazdasagiEsemenyLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kovetelOsszegLbl = new System.Windows.Forms.Label();
            this.kovetelSzamlaLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.szamlaszamLbl = new System.Windows.Forms.Label();
            this.partnerNeveLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tSzamlaCbx = new System.Windows.Forms.ComboBox();
            this.tSzamlaTxb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rogzitesBtn = new System.Windows.Forms.Button();
            this.idLbl = new System.Windows.Forms.Label();
            this.partnerkodLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.teljesitesDtp = new System.Windows.Forms.DateTimePicker();
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
            this.label1.Location = new System.Drawing.Point(57, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nyitott vevő tételek lezárása";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gazdasagiEsemenyLbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.kovetelOsszegLbl);
            this.groupBox1.Controls.Add(this.kovetelSzamlaLbl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.szamlaszamLbl);
            this.groupBox1.Controls.Add(this.partnerNeveLbl);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1005, 229);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Könyvelés adatai";
            // 
            // gazdasagiEsemenyLbl
            // 
            this.gazdasagiEsemenyLbl.AutoSize = true;
            this.gazdasagiEsemenyLbl.Location = new System.Drawing.Point(20, 192);
            this.gazdasagiEsemenyLbl.Name = "gazdasagiEsemenyLbl";
            this.gazdasagiEsemenyLbl.Size = new System.Drawing.Size(154, 20);
            this.gazdasagiEsemenyLbl.TabIndex = 6;
            this.gazdasagiEsemenyLbl.Text = "Gazdasági esemény";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Követel összeg: ";
            // 
            // kovetelOsszegLbl
            // 
            this.kovetelOsszegLbl.AutoSize = true;
            this.kovetelOsszegLbl.Location = new System.Drawing.Point(150, 136);
            this.kovetelOsszegLbl.Name = "kovetelOsszegLbl";
            this.kovetelOsszegLbl.Size = new System.Drawing.Size(116, 20);
            this.kovetelOsszegLbl.TabIndex = 4;
            this.kovetelOsszegLbl.Text = "Követel összeg";
            // 
            // kovetelSzamlaLbl
            // 
            this.kovetelSzamlaLbl.AutoSize = true;
            this.kovetelSzamlaLbl.Location = new System.Drawing.Point(95, 81);
            this.kovetelSzamlaLbl.Name = "kovetelSzamlaLbl";
            this.kovetelSzamlaLbl.Size = new System.Drawing.Size(113, 20);
            this.kovetelSzamlaLbl.TabIndex = 3;
            this.kovetelSzamlaLbl.Text = "követel számla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Követel: ";
            // 
            // szamlaszamLbl
            // 
            this.szamlaszamLbl.AutoSize = true;
            this.szamlaszamLbl.Location = new System.Drawing.Point(715, 35);
            this.szamlaszamLbl.Name = "szamlaszamLbl";
            this.szamlaszamLbl.Size = new System.Drawing.Size(100, 20);
            this.szamlaszamLbl.TabIndex = 1;
            this.szamlaszamLbl.Text = "Számlaszám";
            // 
            // partnerNeveLbl
            // 
            this.partnerNeveLbl.AutoSize = true;
            this.partnerNeveLbl.Location = new System.Drawing.Point(20, 35);
            this.partnerNeveLbl.Name = "partnerNeveLbl";
            this.partnerNeveLbl.Size = new System.Drawing.Size(99, 20);
            this.partnerNeveLbl.TabIndex = 0;
            this.partnerNeveLbl.Text = "Partner neve";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tSzamlaCbx);
            this.groupBox2.Controls.Add(this.tSzamlaTxb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1005, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kiegyenlítés";
            // 
            // tSzamlaCbx
            // 
            this.tSzamlaCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tSzamlaCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSzamlaCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tSzamlaCbx.FormattingEnabled = true;
            this.tSzamlaCbx.Location = new System.Drawing.Point(20, 91);
            this.tSzamlaCbx.Name = "tSzamlaCbx";
            this.tSzamlaCbx.Size = new System.Drawing.Size(979, 28);
            this.tSzamlaCbx.TabIndex = 2;
            this.tSzamlaCbx.SelectedIndexChanged += new System.EventHandler(this.tSzamlaCbx_SelectedIndexChanged);
            // 
            // tSzamlaTxb
            // 
            this.tSzamlaTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tSzamlaTxb.Location = new System.Drawing.Point(150, 46);
            this.tSzamlaTxb.Name = "tSzamlaTxb";
            this.tSzamlaTxb.Size = new System.Drawing.Size(141, 26);
            this.tSzamlaTxb.TabIndex = 1;
            this.tSzamlaTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSzamlaTxb_KeyPress);
            this.tSzamlaTxb.Leave += new System.EventHandler(this.tSzamlaTxb_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tartozik számla";
            // 
            // rogzitesBtn
            // 
            this.rogzitesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rogzitesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesBtn.Location = new System.Drawing.Point(817, 493);
            this.rogzitesBtn.Name = "rogzitesBtn";
            this.rogzitesBtn.Size = new System.Drawing.Size(194, 52);
            this.rogzitesBtn.TabIndex = 8;
            this.rogzitesBtn.Text = "Rögzítés";
            this.rogzitesBtn.UseVisualStyleBackColor = false;
            this.rogzitesBtn.Click += new System.EventHandler(this.rogzitesBtn_Click);
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(463, 17);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(0, 20);
            this.idLbl.TabIndex = 9;
            this.idLbl.Visible = false;
            // 
            // partnerkodLbl
            // 
            this.partnerkodLbl.AutoSize = true;
            this.partnerkodLbl.Location = new System.Drawing.Point(781, 19);
            this.partnerkodLbl.Name = "partnerkodLbl";
            this.partnerkodLbl.Size = new System.Drawing.Size(0, 20);
            this.partnerkodLbl.TabIndex = 10;
            this.partnerkodLbl.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Teljesítés";
            // 
            // teljesitesDtp
            // 
            this.teljesitesDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.teljesitesDtp.Location = new System.Drawing.Point(113, 470);
            this.teljesitesDtp.Name = "teljesitesDtp";
            this.teljesitesDtp.Size = new System.Drawing.Size(134, 26);
            this.teljesitesDtp.TabIndex = 12;
            // 
            // NyitottVevoLezarasaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.teljesitesDtp);
            this.Controls.Add(this.label5);
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
            this.Name = "NyitottVevoLezarasaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NyitottVevoLezarasaFrm";
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
        private System.Windows.Forms.Label gazdasagiEsemenyLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label kovetelOsszegLbl;
        private System.Windows.Forms.Label kovetelSzamlaLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label szamlaszamLbl;
        private System.Windows.Forms.Label partnerNeveLbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox tSzamlaCbx;
        private System.Windows.Forms.TextBox tSzamlaTxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button rogzitesBtn;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label partnerkodLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker teljesitesDtp;
    }
}