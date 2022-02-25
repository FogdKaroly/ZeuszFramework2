namespace Zeusz.Lekerdezesek
{
    partial class AfaAnalitikaFrm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.afaAnalitikaDgv = new System.Windows.Forms.DataGridView();
            this.honap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afaTeljesites = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nettoErtek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afakulcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afaTartalom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brutto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lekerDatumLbl = new System.Windows.Forms.Label();
            this.excelExportBtn = new System.Windows.Forms.Button();
            this.csvExportBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lekerdezesBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.evTxb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afaAnalitikaDgv)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "ÁFA analitika készítése";
            // 
            // igTxb
            // 
            this.igTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.igTxb.Location = new System.Drawing.Point(704, 14);
            this.igTxb.Name = "igTxb";
            this.igTxb.Size = new System.Drawing.Size(100, 26);
            this.igTxb.TabIndex = 30;
            this.igTxb.Text = "12";
            // 
            // tolTxb
            // 
            this.tolTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tolTxb.Location = new System.Drawing.Point(578, 14);
            this.tolTxb.Name = "tolTxb";
            this.tolTxb.Size = new System.Drawing.Size(100, 26);
            this.tolTxb.TabIndex = 29;
            this.tolTxb.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Időszak (hónap):";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.afaAnalitikaDgv);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 531);
            this.panel1.TabIndex = 31;
            // 
            // afaAnalitikaDgv
            // 
            this.afaAnalitikaDgv.AllowUserToAddRows = false;
            this.afaAnalitikaDgv.AllowUserToDeleteRows = false;
            this.afaAnalitikaDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.afaAnalitikaDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.afaAnalitikaDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.honap,
            this.sorszam,
            this.partner,
            this.afaTeljesites,
            this.nettoErtek,
            this.afakulcs,
            this.afaTartalom,
            this.brutto});
            this.afaAnalitikaDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afaAnalitikaDgv.Location = new System.Drawing.Point(0, 0);
            this.afaAnalitikaDgv.Name = "afaAnalitikaDgv";
            this.afaAnalitikaDgv.ReadOnly = true;
            this.afaAnalitikaDgv.RowTemplate.Height = 25;
            this.afaAnalitikaDgv.Size = new System.Drawing.Size(810, 531);
            this.afaAnalitikaDgv.TabIndex = 0;
            // 
            // honap
            // 
            this.honap.HeaderText = "Hónap";
            this.honap.Name = "honap";
            this.honap.ReadOnly = true;
            // 
            // sorszam
            // 
            this.sorszam.HeaderText = "Sorszám";
            this.sorszam.Name = "sorszam";
            this.sorszam.ReadOnly = true;
            // 
            // partner
            // 
            this.partner.HeaderText = "Partner";
            this.partner.Name = "partner";
            this.partner.ReadOnly = true;
            // 
            // afaTeljesites
            // 
            this.afaTeljesites.HeaderText = "Teljesítés";
            this.afaTeljesites.Name = "afaTeljesites";
            this.afaTeljesites.ReadOnly = true;
            // 
            // nettoErtek
            // 
            this.nettoErtek.HeaderText = "Nettó";
            this.nettoErtek.Name = "nettoErtek";
            this.nettoErtek.ReadOnly = true;
            // 
            // afakulcs
            // 
            this.afakulcs.HeaderText = "Áfakulcs";
            this.afakulcs.Name = "afakulcs";
            this.afakulcs.ReadOnly = true;
            // 
            // afaTartalom
            // 
            this.afaTartalom.HeaderText = "Áfatartalom";
            this.afaTartalom.Name = "afaTartalom";
            this.afaTartalom.ReadOnly = true;
            // 
            // brutto
            // 
            this.brutto.HeaderText = "Bruttó";
            this.brutto.Name = "brutto";
            this.brutto.ReadOnly = true;
            // 
            // lekerDatumLbl
            // 
            this.lekerDatumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lekerDatumLbl.AutoSize = true;
            this.lekerDatumLbl.Location = new System.Drawing.Point(522, 610);
            this.lekerDatumLbl.Name = "lekerDatumLbl";
            this.lekerDatumLbl.Size = new System.Drawing.Size(54, 20);
            this.lekerDatumLbl.TabIndex = 34;
            this.lekerDatumLbl.Text = "dátum";
            this.lekerDatumLbl.Visible = false;
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
            this.excelExportBtn.TabIndex = 36;
            this.excelExportBtn.Text = "Exportálás Excelbe";
            this.excelExportBtn.UseVisualStyleBackColor = false;
            this.excelExportBtn.Visible = false;
            this.excelExportBtn.Click += new System.EventHandler(this.excelExportBtn_Click);
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
            this.csvExportBtn.TabIndex = 32;
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
            this.label6.TabIndex = 33;
            this.label6.Text = "Lekérdezés dátuma:";
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
            this.lekerdezesBtn.TabIndex = 35;
            this.lekerdezesBtn.Text = "Lekérdezés";
            this.lekerdezesBtn.UseVisualStyleBackColor = false;
            this.lekerdezesBtn.Click += new System.EventHandler(this.lekerdezesBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Év";
            // 
            // evTxb
            // 
            this.evTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.evTxb.Location = new System.Drawing.Point(299, 14);
            this.evTxb.Name = "evTxb";
            this.evTxb.Size = new System.Drawing.Size(100, 26);
            this.evTxb.TabIndex = 38;
            // 
            // AfaAnalitikaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.evTxb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lekerDatumLbl);
            this.Controls.Add(this.excelExportBtn);
            this.Controls.Add(this.csvExportBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lekerdezesBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.igTxb);
            this.Controls.Add(this.tolTxb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AfaAnalitikaFrm";
            this.Text = "AfaAnalitikaFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.afaAnalitikaDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox igTxb;
        private System.Windows.Forms.TextBox tolTxb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView afaAnalitikaDgv;
        private System.Windows.Forms.Label lekerDatumLbl;
        private System.Windows.Forms.Button excelExportBtn;
        private System.Windows.Forms.Button csvExportBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button lekerdezesBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn honap;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorszam;
        private System.Windows.Forms.DataGridViewTextBoxColumn partner;
        private System.Windows.Forms.DataGridViewTextBoxColumn afaTeljesites;
        private System.Windows.Forms.DataGridViewTextBoxColumn nettoErtek;
        private System.Windows.Forms.DataGridViewTextBoxColumn afakulcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn afaTartalom;
        private System.Windows.Forms.DataGridViewTextBoxColumn brutto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox evTxb;
    }
}