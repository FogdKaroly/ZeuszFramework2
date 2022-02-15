namespace Zeusz.Lekerdezesek
{
    partial class FokonyviKartonFrm
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
            this.igTxb = new System.Windows.Forms.TextBox();
            this.tolTxb = new System.Windows.Forms.TextBox();
            this.fokonyviSzamTolTxb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fokonyviSzamIgTxb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kartonDgv = new System.Windows.Forms.DataGridView();
            this.honap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teljesites = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.szamlaszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ellenSzamla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tErtek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kErtek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gazdasagiEsemeny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lekerdezesBtn = new System.Windows.Forms.Button();
            this.excelExportBtn = new System.Windows.Forms.Button();
            this.lekerDatumLbl = new System.Windows.Forms.Label();
            this.csvExportBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kartonDgv)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(56, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Főkönyvi karton lekérdezése";
            // 
            // igTxb
            // 
            this.igTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.igTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.igTxb.Location = new System.Drawing.Point(272, 57);
            this.igTxb.Name = "igTxb";
            this.igTxb.Size = new System.Drawing.Size(100, 26);
            this.igTxb.TabIndex = 26;
            this.igTxb.Text = "12";
            // 
            // tolTxb
            // 
            this.tolTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tolTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tolTxb.Location = new System.Drawing.Point(146, 57);
            this.tolTxb.Name = "tolTxb";
            this.tolTxb.Size = new System.Drawing.Size(100, 26);
            this.tolTxb.TabIndex = 25;
            this.tolTxb.Text = "0";
            // 
            // fokonyviSzamTolTxb
            // 
            this.fokonyviSzamTolTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fokonyviSzamTolTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.fokonyviSzamTolTxb.Location = new System.Drawing.Point(557, 57);
            this.fokonyviSzamTolTxb.Name = "fokonyviSzamTolTxb";
            this.fokonyviSzamTolTxb.Size = new System.Drawing.Size(89, 26);
            this.fokonyviSzamTolTxb.TabIndex = 24;
            this.fokonyviSzamTolTxb.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Főkönyvi szám:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Időszak (hónap):";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "-";
            // 
            // fokonyviSzamIgTxb
            // 
            this.fokonyviSzamIgTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fokonyviSzamIgTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.fokonyviSzamIgTxb.Location = new System.Drawing.Point(672, 57);
            this.fokonyviSzamIgTxb.Name = "fokonyviSzamIgTxb";
            this.fokonyviSzamIgTxb.Size = new System.Drawing.Size(89, 26);
            this.fokonyviSzamIgTxb.TabIndex = 28;
            this.fokonyviSzamIgTxb.Text = "999999";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.kartonDgv);
            this.panel1.Location = new System.Drawing.Point(12, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 486);
            this.panel1.TabIndex = 29;
            // 
            // kartonDgv
            // 
            this.kartonDgv.AllowUserToAddRows = false;
            this.kartonDgv.AllowUserToDeleteRows = false;
            this.kartonDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kartonDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kartonDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.honap,
            this.teljesites,
            this.szamlaszam,
            this.ellenSzamla,
            this.tErtek,
            this.kErtek,
            this.gazdasagiEsemeny});
            this.kartonDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kartonDgv.Location = new System.Drawing.Point(0, 0);
            this.kartonDgv.Name = "kartonDgv";
            this.kartonDgv.ReadOnly = true;
            this.kartonDgv.RowTemplate.Height = 25;
            this.kartonDgv.Size = new System.Drawing.Size(810, 486);
            this.kartonDgv.TabIndex = 0;
            // 
            // honap
            // 
            this.honap.HeaderText = "Hónap";
            this.honap.Name = "honap";
            this.honap.ReadOnly = true;
            // 
            // teljesites
            // 
            this.teljesites.HeaderText = "Teljesítés";
            this.teljesites.Name = "teljesites";
            this.teljesites.ReadOnly = true;
            // 
            // szamlaszam
            // 
            this.szamlaszam.HeaderText = "Számlaszám";
            this.szamlaszam.Name = "szamlaszam";
            this.szamlaszam.ReadOnly = true;
            // 
            // ellenSzamla
            // 
            this.ellenSzamla.HeaderText = "Ellenszámla";
            this.ellenSzamla.Name = "ellenSzamla";
            this.ellenSzamla.ReadOnly = true;
            // 
            // tErtek
            // 
            this.tErtek.HeaderText = "Tartozik érték";
            this.tErtek.Name = "tErtek";
            this.tErtek.ReadOnly = true;
            // 
            // kErtek
            // 
            this.kErtek.HeaderText = "Követel érték";
            this.kErtek.Name = "kErtek";
            this.kErtek.ReadOnly = true;
            // 
            // gazdasagiEsemeny
            // 
            this.gazdasagiEsemeny.HeaderText = "Gazdasági esemény";
            this.gazdasagiEsemeny.Name = "gazdasagiEsemeny";
            this.gazdasagiEsemeny.ReadOnly = true;
            // 
            // lekerdezesBtn
            // 
            this.lekerdezesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lekerdezesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.lekerdezesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lekerdezesBtn.Location = new System.Drawing.Point(682, 591);
            this.lekerdezesBtn.MaximumSize = new System.Drawing.Size(140, 58);
            this.lekerdezesBtn.Name = "lekerdezesBtn";
            this.lekerdezesBtn.Size = new System.Drawing.Size(140, 58);
            this.lekerdezesBtn.TabIndex = 30;
            this.lekerdezesBtn.Text = "Lekérdezés";
            this.lekerdezesBtn.UseVisualStyleBackColor = false;
            this.lekerdezesBtn.Click += new System.EventHandler(this.lekerdezesBtn_Click);
            // 
            // excelExportBtn
            // 
            this.excelExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.excelExportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.excelExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelExportBtn.Location = new System.Drawing.Point(12, 591);
            this.excelExportBtn.MaximumSize = new System.Drawing.Size(169, 58);
            this.excelExportBtn.Name = "excelExportBtn";
            this.excelExportBtn.Size = new System.Drawing.Size(169, 58);
            this.excelExportBtn.TabIndex = 31;
            this.excelExportBtn.Text = "Exportálás Excelbe";
            this.excelExportBtn.UseVisualStyleBackColor = false;
            this.excelExportBtn.Visible = false;
            this.excelExportBtn.Click += new System.EventHandler(this.excelExportBtn_Click);
            // 
            // lekerDatumLbl
            // 
            this.lekerDatumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lekerDatumLbl.AutoSize = true;
            this.lekerDatumLbl.Location = new System.Drawing.Point(522, 610);
            this.lekerDatumLbl.Name = "lekerDatumLbl";
            this.lekerDatumLbl.Size = new System.Drawing.Size(54, 20);
            this.lekerDatumLbl.TabIndex = 21;
            this.lekerDatumLbl.Text = "dátum";
            this.lekerDatumLbl.Visible = false;
            // 
            // csvExportBtn
            // 
            this.csvExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.csvExportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.csvExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csvExportBtn.Location = new System.Drawing.Point(187, 591);
            this.csvExportBtn.MaximumSize = new System.Drawing.Size(169, 58);
            this.csvExportBtn.Name = "csvExportBtn";
            this.csvExportBtn.Size = new System.Drawing.Size(169, 58);
            this.csvExportBtn.TabIndex = 19;
            this.csvExportBtn.Text = "Exportálás CSV-be";
            this.csvExportBtn.UseVisualStyleBackColor = false;
            this.csvExportBtn.Visible = false;
            this.csvExportBtn.Click += new System.EventHandler(this.csvExportBtn_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 610);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Lekérdezés dátuma:";
            // 
            // FokonyviKartonFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.lekerDatumLbl);
            this.Controls.Add(this.excelExportBtn);
            this.Controls.Add(this.csvExportBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lekerdezesBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fokonyviSzamIgTxb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.igTxb);
            this.Controls.Add(this.tolTxb);
            this.Controls.Add(this.fokonyviSzamTolTxb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FokonyviKartonFrm";
            this.Text = "FokonyviKartonFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kartonDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox igTxb;
        private System.Windows.Forms.TextBox tolTxb;
        private System.Windows.Forms.TextBox fokonyviSzamTolTxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fokonyviSzamIgTxb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button lekerdezesBtn;
        private System.Windows.Forms.Button excelExportBtn;
        private System.Windows.Forms.DataGridView kartonDgv;
        private System.Windows.Forms.Label lekerDatumLbl;
        private System.Windows.Forms.Button csvExportBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn honap;
        private System.Windows.Forms.DataGridViewTextBoxColumn teljesites;
        private System.Windows.Forms.DataGridViewTextBoxColumn szamlaszam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ellenSzamla;
        private System.Windows.Forms.DataGridViewTextBoxColumn tErtek;
        private System.Windows.Forms.DataGridViewTextBoxColumn kErtek;
        private System.Windows.Forms.DataGridViewTextBoxColumn gazdasagiEsemeny;
    }
}