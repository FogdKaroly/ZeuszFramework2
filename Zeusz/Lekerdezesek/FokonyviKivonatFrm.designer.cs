namespace Zeusz.Lekerdezesek
{
    partial class FokonyviKivonatFrm
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
            this.label4 = new System.Windows.Forms.Label();
            this.fokonyviSzamTxb = new System.Windows.Forms.TextBox();
            this.lekerdezesBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kivonatDgv = new System.Windows.Forms.DataGridView();
            this.fokonyviSzam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tForgalom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kForgalom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egyenleg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excelExportBtn = new System.Windows.Forms.Button();
            this.csvExportBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lekerDatumLbl = new System.Windows.Forms.Label();
            this.tolTxb = new System.Windows.Forms.TextBox();
            this.igTxb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.evTxb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kivonatDgv)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(58, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Főkönyvi kivonat lekérdezése";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Időszak (hónap):";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Főkönyvi szám:";
            // 
            // fokonyviSzamTxb
            // 
            this.fokonyviSzamTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fokonyviSzamTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.fokonyviSzamTxb.Location = new System.Drawing.Point(681, 60);
            this.fokonyviSzamTxb.Name = "fokonyviSzamTxb";
            this.fokonyviSzamTxb.Size = new System.Drawing.Size(141, 26);
            this.fokonyviSzamTxb.TabIndex = 12;
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
            this.lekerdezesBtn.TabIndex = 13;
            this.lekerdezesBtn.Text = "Lekérdezés";
            this.lekerdezesBtn.UseVisualStyleBackColor = false;
            this.lekerdezesBtn.Click += new System.EventHandler(this.lekerdezesBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.kivonatDgv);
            this.panel1.Location = new System.Drawing.Point(12, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 486);
            this.panel1.TabIndex = 14;
            // 
            // kivonatDgv
            // 
            this.kivonatDgv.AllowUserToAddRows = false;
            this.kivonatDgv.AllowUserToDeleteRows = false;
            this.kivonatDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kivonatDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kivonatDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fokonyviSzam,
            this.tForgalom,
            this.kForgalom,
            this.egyenleg});
            this.kivonatDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kivonatDgv.Location = new System.Drawing.Point(0, 0);
            this.kivonatDgv.Name = "kivonatDgv";
            this.kivonatDgv.ReadOnly = true;
            this.kivonatDgv.RowTemplate.Height = 25;
            this.kivonatDgv.Size = new System.Drawing.Size(810, 486);
            this.kivonatDgv.TabIndex = 0;
            // 
            // fokonyviSzam
            // 
            this.fokonyviSzam.HeaderText = "Főkönyvi szám";
            this.fokonyviSzam.Name = "fokonyviSzam";
            this.fokonyviSzam.ReadOnly = true;
            // 
            // tForgalom
            // 
            this.tForgalom.HeaderText = "Tartozik forgalom";
            this.tForgalom.Name = "tForgalom";
            this.tForgalom.ReadOnly = true;
            // 
            // kForgalom
            // 
            this.kForgalom.HeaderText = "Követel forgalom";
            this.kForgalom.Name = "kForgalom";
            this.kForgalom.ReadOnly = true;
            // 
            // egyenleg
            // 
            this.egyenleg.HeaderText = "Egyenleg";
            this.egyenleg.Name = "egyenleg";
            this.egyenleg.ReadOnly = true;
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
            this.excelExportBtn.TabIndex = 15;
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
            this.csvExportBtn.TabIndex = 16;
            this.csvExportBtn.Text = "Exportálás CSV-be";
            this.csvExportBtn.UseVisualStyleBackColor = false;
            this.csvExportBtn.Visible = false;
            this.csvExportBtn.Click += new System.EventHandler(this.csvExportBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(362, 610);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Lekérdezés dátuma:";
            // 
            // lekerDatumLbl
            // 
            this.lekerDatumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lekerDatumLbl.AutoSize = true;
            this.lekerDatumLbl.Location = new System.Drawing.Point(522, 610);
            this.lekerDatumLbl.Name = "lekerDatumLbl";
            this.lekerDatumLbl.Size = new System.Drawing.Size(54, 20);
            this.lekerDatumLbl.TabIndex = 18;
            this.lekerDatumLbl.Text = "dátum";
            this.lekerDatumLbl.Visible = false;
            // 
            // tolTxb
            // 
            this.tolTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tolTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.tolTxb.Location = new System.Drawing.Point(307, 60);
            this.tolTxb.Name = "tolTxb";
            this.tolTxb.Size = new System.Drawing.Size(100, 26);
            this.tolTxb.TabIndex = 19;
            this.tolTxb.Text = "0";
            // 
            // igTxb
            // 
            this.igTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.igTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.igTxb.Location = new System.Drawing.Point(433, 60);
            this.igTxb.Name = "igTxb";
            this.igTxb.Size = new System.Drawing.Size(100, 26);
            this.igTxb.TabIndex = 20;
            this.igTxb.Text = "12";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Év";
            // 
            // evTxb
            // 
            this.evTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.evTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.evTxb.Location = new System.Drawing.Point(45, 60);
            this.evTxb.Name = "evTxb";
            this.evTxb.Size = new System.Drawing.Size(100, 26);
            this.evTxb.TabIndex = 22;
            // 
            // FokonyviKivonatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.evTxb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.igTxb);
            this.Controls.Add(this.tolTxb);
            this.Controls.Add(this.lekerDatumLbl);
            this.Controls.Add(this.csvExportBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.excelExportBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lekerdezesBtn);
            this.Controls.Add(this.fokonyviSzamTxb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FokonyviKivonatFrm";
            this.Text = "FokonyviKivonatFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kivonatDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fokonyviSzamTxb;
        private System.Windows.Forms.Button lekerdezesBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button excelExportBtn;
        private System.Windows.Forms.Button csvExportBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lekerDatumLbl;
        private System.Windows.Forms.DataGridView kivonatDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn fokonyviSzam;
        private System.Windows.Forms.DataGridViewTextBoxColumn tForgalom;
        private System.Windows.Forms.DataGridViewTextBoxColumn kForgalom;
        private System.Windows.Forms.DataGridViewTextBoxColumn egyenleg;
        private System.Windows.Forms.TextBox tolTxb;
        private System.Windows.Forms.TextBox igTxb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox evTxb;
    }
}