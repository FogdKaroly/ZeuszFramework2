namespace Zeusz
{
    partial class KezdokepernyoFrm
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
            this.legutobbiTetelekDgv = new System.Windows.Forms.DataGridView();
            this.sorszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partnerkod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.szamlaszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tartozik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kovetel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esemeny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.legutobbiTetelekDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // legutobbiTetelekDgv
            // 
            this.legutobbiTetelekDgv.AllowUserToAddRows = false;
            this.legutobbiTetelekDgv.AllowUserToDeleteRows = false;
            this.legutobbiTetelekDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.legutobbiTetelekDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.legutobbiTetelekDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sorszam,
            this.partnerkod,
            this.szamlaszam,
            this.tartozik,
            this.kovetel,
            this.esemeny});
            this.legutobbiTetelekDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legutobbiTetelekDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.legutobbiTetelekDgv.Location = new System.Drawing.Point(0, 0);
            this.legutobbiTetelekDgv.Name = "legutobbiTetelekDgv";
            this.legutobbiTetelekDgv.ReadOnly = true;
            this.legutobbiTetelekDgv.RowTemplate.Height = 25;
            this.legutobbiTetelekDgv.Size = new System.Drawing.Size(834, 661);
            this.legutobbiTetelekDgv.TabIndex = 0;
            // 
            // sorszam
            // 
            this.sorszam.FillWeight = 50F;
            this.sorszam.HeaderText = "Sorszám";
            this.sorszam.MinimumWidth = 50;
            this.sorszam.Name = "sorszam";
            this.sorszam.ReadOnly = true;
            this.sorszam.Width = 125;
            // 
            // partnerkod
            // 
            this.partnerkod.FillWeight = 50F;
            this.partnerkod.HeaderText = "Partnerkód";
            this.partnerkod.MinimumWidth = 50;
            this.partnerkod.Name = "partnerkod";
            this.partnerkod.ReadOnly = true;
            this.partnerkod.Width = 124;
            // 
            // szamlaszam
            // 
            this.szamlaszam.FillWeight = 50F;
            this.szamlaszam.HeaderText = "Számlaszám";
            this.szamlaszam.MinimumWidth = 50;
            this.szamlaszam.Name = "szamlaszam";
            this.szamlaszam.ReadOnly = true;
            this.szamlaszam.Width = 125;
            // 
            // tartozik
            // 
            this.tartozik.FillWeight = 50F;
            this.tartozik.HeaderText = "Tartozik";
            this.tartozik.MinimumWidth = 50;
            this.tartozik.Name = "tartozik";
            this.tartozik.ReadOnly = true;
            this.tartozik.Width = 124;
            // 
            // kovetel
            // 
            this.kovetel.FillWeight = 50F;
            this.kovetel.HeaderText = "Követel";
            this.kovetel.MinimumWidth = 50;
            this.kovetel.Name = "kovetel";
            this.kovetel.ReadOnly = true;
            this.kovetel.Width = 125;
            // 
            // esemeny
            // 
            this.esemeny.FillWeight = 67.43024F;
            this.esemeny.HeaderText = "Esemény";
            this.esemeny.Name = "esemeny";
            this.esemeny.ReadOnly = true;
            this.esemeny.Width = 168;
            // 
            // KezdokepernyoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.legutobbiTetelekDgv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KezdokepernyoFrm";
            this.Text = "KezdokepernyoFrm";
            ((System.ComponentModel.ISupportInitialize)(this.legutobbiTetelekDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView legutobbiTetelekDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorszam;
        private System.Windows.Forms.DataGridViewTextBoxColumn partnerkod;
        private System.Windows.Forms.DataGridViewTextBoxColumn szamlaszam;
        private System.Windows.Forms.DataGridViewTextBoxColumn tartozik;
        private System.Windows.Forms.DataGridViewTextBoxColumn kovetel;
        private System.Windows.Forms.DataGridViewTextBoxColumn esemeny;
    }
}