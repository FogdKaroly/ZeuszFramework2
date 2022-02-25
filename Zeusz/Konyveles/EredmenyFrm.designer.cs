namespace Zeusz.Konyveles
{
    partial class EredmenyFrm
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
            this.lekerDatumLbl = new System.Windows.Forms.Label();
            this.excelExportBtn = new System.Windows.Forms.Button();
            this.csvExportBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.eredmenyPanel = new System.Windows.Forms.Panel();
            this.eredmenyDgv = new System.Windows.Forms.DataGridView();
            this.sorszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.megnevezes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elozoEv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modositasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targyev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.evTxb = new System.Windows.Forms.TextBox();
            this.lekeresBtn = new System.Windows.Forms.Button();
            this.eredmenyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eredmenyDgv)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(53, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Eredmény";
            // 
            // lekerDatumLbl
            // 
            this.lekerDatumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lekerDatumLbl.AutoSize = true;
            this.lekerDatumLbl.Location = new System.Drawing.Point(522, 610);
            this.lekerDatumLbl.Name = "lekerDatumLbl";
            this.lekerDatumLbl.Size = new System.Drawing.Size(54, 20);
            this.lekerDatumLbl.TabIndex = 38;
            this.lekerDatumLbl.Text = "dátum";
            // 
            // excelExportBtn
            // 
            this.excelExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.excelExportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.excelExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelExportBtn.Location = new System.Drawing.Point(12, 591);
            this.excelExportBtn.Name = "excelExportBtn";
            this.excelExportBtn.Size = new System.Drawing.Size(169, 58);
            this.excelExportBtn.TabIndex = 39;
            this.excelExportBtn.Text = "Exportálás Excelbe";
            this.excelExportBtn.UseVisualStyleBackColor = false;
            this.excelExportBtn.Click += new System.EventHandler(this.excelExportBtn_Click);
            // 
            // csvExportBtn
            // 
            this.csvExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.csvExportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.csvExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csvExportBtn.Location = new System.Drawing.Point(187, 591);
            this.csvExportBtn.Name = "csvExportBtn";
            this.csvExportBtn.Size = new System.Drawing.Size(169, 58);
            this.csvExportBtn.TabIndex = 36;
            this.csvExportBtn.Text = "Exportálás CSV-be";
            this.csvExportBtn.UseVisualStyleBackColor = false;
            this.csvExportBtn.Click += new System.EventHandler(this.csvExportBtn_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 610);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Lekérdezés dátuma:";
            // 
            // eredmenyPanel
            // 
            this.eredmenyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.eredmenyPanel.AutoSize = true;
            this.eredmenyPanel.Controls.Add(this.eredmenyDgv);
            this.eredmenyPanel.Location = new System.Drawing.Point(12, 53);
            this.eredmenyPanel.MaximumSize = new System.Drawing.Size(1500, 1500);
            this.eredmenyPanel.Name = "eredmenyPanel";
            this.eredmenyPanel.Size = new System.Drawing.Size(812, 535);
            this.eredmenyPanel.TabIndex = 40;
            // 
            // eredmenyDgv
            // 
            this.eredmenyDgv.AllowUserToAddRows = false;
            this.eredmenyDgv.AllowUserToDeleteRows = false;
            this.eredmenyDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.eredmenyDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eredmenyDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eredmenyDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sorszam,
            this.megnevezes,
            this.elozoEv,
            this.modositasok,
            this.targyev});
            this.eredmenyDgv.Location = new System.Drawing.Point(-1, 0);
            this.eredmenyDgv.Name = "eredmenyDgv";
            this.eredmenyDgv.ReadOnly = true;
            this.eredmenyDgv.RowTemplate.Height = 25;
            this.eredmenyDgv.Size = new System.Drawing.Size(810, 532);
            this.eredmenyDgv.TabIndex = 0;
            // 
            // sorszam
            // 
            this.sorszam.HeaderText = "Sorszám";
            this.sorszam.Name = "sorszam";
            this.sorszam.ReadOnly = true;
            // 
            // megnevezes
            // 
            this.megnevezes.HeaderText = "Megnevezés";
            this.megnevezes.Name = "megnevezes";
            this.megnevezes.ReadOnly = true;
            // 
            // elozoEv
            // 
            this.elozoEv.HeaderText = "Előző év";
            this.elozoEv.Name = "elozoEv";
            this.elozoEv.ReadOnly = true;
            // 
            // modositasok
            // 
            this.modositasok.HeaderText = "Módosítások";
            this.modositasok.Name = "modositasok";
            this.modositasok.ReadOnly = true;
            // 
            // targyev
            // 
            this.targyev.HeaderText = "Tárgyév";
            this.targyev.Name = "targyev";
            this.targyev.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Év";
            // 
            // evTxb
            // 
            this.evTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.evTxb.Location = new System.Drawing.Point(555, 14);
            this.evTxb.Name = "evTxb";
            this.evTxb.Size = new System.Drawing.Size(100, 26);
            this.evTxb.TabIndex = 42;
            // 
            // lekeresBtn
            // 
            this.lekeresBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lekeresBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.lekeresBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lekeresBtn.Location = new System.Drawing.Point(655, 594);
            this.lekeresBtn.Name = "lekeresBtn";
            this.lekeresBtn.Size = new System.Drawing.Size(169, 58);
            this.lekeresBtn.TabIndex = 43;
            this.lekeresBtn.Text = "Lekérdezés";
            this.lekeresBtn.UseVisualStyleBackColor = false;
            this.lekeresBtn.Click += new System.EventHandler(this.lekeresBtn_Click);
            // 
            // EredmenyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.lekeresBtn);
            this.Controls.Add(this.evTxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eredmenyPanel);
            this.Controls.Add(this.lekerDatumLbl);
            this.Controls.Add(this.excelExportBtn);
            this.Controls.Add(this.csvExportBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EredmenyFrm";
            this.Text = "EredmenyFrm";
            this.eredmenyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eredmenyDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lekerDatumLbl;
        private System.Windows.Forms.Button excelExportBtn;
        private System.Windows.Forms.Button csvExportBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel eredmenyPanel;
        private System.Windows.Forms.DataGridView eredmenyDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorszam;
        private System.Windows.Forms.DataGridViewTextBoxColumn megnevezes;
        private System.Windows.Forms.DataGridViewTextBoxColumn elozoEv;
        private System.Windows.Forms.DataGridViewTextBoxColumn modositasok;
        private System.Windows.Forms.DataGridViewTextBoxColumn targyev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox evTxb;
        private System.Windows.Forms.Button lekeresBtn;
    }
}