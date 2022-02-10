namespace Zeusz
{
    partial class JogosultsagKezelesFrm
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
            this.felhasznaloCbx = new System.Windows.Forms.ComboBox();
            this.jogosultsagPanel = new System.Windows.Forms.Panel();
            this.jogosultsagokDgv = new System.Windows.Forms.DataGridView();
            this.rogzitesBtn = new System.Windows.Forms.Button();
            this.menupont_neve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jogosultsag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jogosultsagPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jogosultsagokDgv)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(54, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jogosultságok kezelése";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Felhasználó kiválasztása";
            // 
            // felhasznaloCbx
            // 
            this.felhasznaloCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.felhasznaloCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.felhasznaloCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.felhasznaloCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.felhasznaloCbx.FormattingEnabled = true;
            this.felhasznaloCbx.Location = new System.Drawing.Point(365, 73);
            this.felhasznaloCbx.MaximumSize = new System.Drawing.Size(287, 0);
            this.felhasznaloCbx.Name = "felhasznaloCbx";
            this.felhasznaloCbx.Size = new System.Drawing.Size(287, 28);
            this.felhasznaloCbx.TabIndex = 4;
            this.felhasznaloCbx.SelectedIndexChanged += new System.EventHandler(this.felhasznaloCbx_SelectedIndexChanged);
            // 
            // jogosultsagPanel
            // 
            this.jogosultsagPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.jogosultsagPanel.Controls.Add(this.jogosultsagokDgv);
            this.jogosultsagPanel.Location = new System.Drawing.Point(55, 131);
            this.jogosultsagPanel.MaximumSize = new System.Drawing.Size(730, 440);
            this.jogosultsagPanel.Name = "jogosultsagPanel";
            this.jogosultsagPanel.Size = new System.Drawing.Size(730, 440);
            this.jogosultsagPanel.TabIndex = 5;
            // 
            // jogosultsagokDgv
            // 
            this.jogosultsagokDgv.AllowUserToAddRows = false;
            this.jogosultsagokDgv.AllowUserToDeleteRows = false;
            this.jogosultsagokDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.jogosultsagokDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jogosultsagokDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jogosultsagokDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menupont_neve,
            this.jogosultsag});
            this.jogosultsagokDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jogosultsagokDgv.Location = new System.Drawing.Point(0, 0);
            this.jogosultsagokDgv.MultiSelect = false;
            this.jogosultsagokDgv.Name = "jogosultsagokDgv";
            this.jogosultsagokDgv.RowTemplate.Height = 25;
            this.jogosultsagokDgv.Size = new System.Drawing.Size(730, 440);
            this.jogosultsagokDgv.TabIndex = 0;
            // 
            // rogzitesBtn
            // 
            this.rogzitesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rogzitesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.rogzitesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rogzitesBtn.Location = new System.Drawing.Point(585, 592);
            this.rogzitesBtn.MaximumSize = new System.Drawing.Size(200, 40);
            this.rogzitesBtn.Name = "rogzitesBtn";
            this.rogzitesBtn.Size = new System.Drawing.Size(200, 40);
            this.rogzitesBtn.TabIndex = 6;
            this.rogzitesBtn.Text = "Módosítások rögzítése";
            this.rogzitesBtn.UseVisualStyleBackColor = false;
            this.rogzitesBtn.Click += new System.EventHandler(this.rogzitesBtn_Click);
            // 
            // menupont_neve
            // 
            this.menupont_neve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.menupont_neve.HeaderText = "Menüpont neve";
            this.menupont_neve.Name = "menupont_neve";
            this.menupont_neve.ReadOnly = true;
            this.menupont_neve.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // jogosultsag
            // 
            this.jogosultsag.HeaderText = "Jogosultság";
            this.jogosultsag.Name = "jogosultsag";
            this.jogosultsag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // JogosultsagKezelesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.rogzitesBtn);
            this.Controls.Add(this.jogosultsagPanel);
            this.Controls.Add(this.felhasznaloCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JogosultsagKezelesFrm";
            this.Text = "JogosultsagKezelesFrm";
            this.jogosultsagPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jogosultsagokDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox felhasznaloCbx;
        private System.Windows.Forms.Panel jogosultsagPanel;
        private System.Windows.Forms.DataGridView jogosultsagokDgv;
        private System.Windows.Forms.Button rogzitesBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menupont_neve;
        private System.Windows.Forms.DataGridViewTextBoxColumn jogosultsag;
    }
}