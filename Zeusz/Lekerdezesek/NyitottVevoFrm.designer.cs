namespace Zeusz.Lekerdezesek
{
    partial class NyitottVevoFrm
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
            this.nyitottVevoPanel = new System.Windows.Forms.Panel();
            this.nyitottVevokLbx = new System.Windows.Forms.ListBox();
            this.nyitottVevoPanel.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nyitott vevő tételek";
            // 
            // nyitottVevoPanel
            // 
            this.nyitottVevoPanel.Controls.Add(this.nyitottVevokLbx);
            this.nyitottVevoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nyitottVevoPanel.Location = new System.Drawing.Point(0, 62);
            this.nyitottVevoPanel.Name = "nyitottVevoPanel";
            this.nyitottVevoPanel.Size = new System.Drawing.Size(834, 599);
            this.nyitottVevoPanel.TabIndex = 5;
            // 
            // nyitottVevokLbx
            // 
            this.nyitottVevokLbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nyitottVevokLbx.FormattingEnabled = true;
            this.nyitottVevokLbx.ItemHeight = 20;
            this.nyitottVevokLbx.Location = new System.Drawing.Point(0, 0);
            this.nyitottVevokLbx.Name = "nyitottVevokLbx";
            this.nyitottVevokLbx.Size = new System.Drawing.Size(834, 599);
            this.nyitottVevokLbx.TabIndex = 0;
            this.nyitottVevokLbx.DoubleClick += new System.EventHandler(this.nyitottVevokLbx_DoubleClick);
            // 
            // NyitottVevoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.nyitottVevoPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NyitottVevoFrm";
            this.Text = "NyitottVevoFrm";
            this.nyitottVevoPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel nyitottVevoPanel;
        private System.Windows.Forms.ListBox nyitottVevokLbx;
    }
}