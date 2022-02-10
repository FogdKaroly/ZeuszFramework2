namespace Zeusz
{
    partial class CegvalasztoFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cegekCbx = new System.Windows.Forms.ComboBox();
            this.kivalasztBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(228, 240);
            this.label1.MaximumSize = new System.Drawing.Size(357, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kérem, válassza ki a könyvelni kívánt céget!";
            // 
            // cegekCbx
            // 
            this.cegekCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cegekCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.cegekCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cegekCbx.FormattingEnabled = true;
            this.cegekCbx.Location = new System.Drawing.Point(228, 286);
            this.cegekCbx.MaximumSize = new System.Drawing.Size(357, 0);
            this.cegekCbx.Name = "cegekCbx";
            this.cegekCbx.Size = new System.Drawing.Size(357, 28);
            this.cegekCbx.TabIndex = 1;
            // 
            // kivalasztBtn
            // 
            this.kivalasztBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.kivalasztBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kivalasztBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kivalasztBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kivalasztBtn.Location = new System.Drawing.Point(331, 343);
            this.kivalasztBtn.MaximumSize = new System.Drawing.Size(155, 44);
            this.kivalasztBtn.Name = "kivalasztBtn";
            this.kivalasztBtn.Size = new System.Drawing.Size(155, 44);
            this.kivalasztBtn.TabIndex = 2;
            this.kivalasztBtn.Text = "Kiválaszt";
            this.kivalasztBtn.UseVisualStyleBackColor = false;
            this.kivalasztBtn.Click += new System.EventHandler(this.kivalasztBtn_Click);
            // 
            // CegvalasztoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.kivalasztBtn);
            this.Controls.Add(this.cegekCbx);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CegvalasztoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Könyvelendő cég kiválasztása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cegekCbx;
        private System.Windows.Forms.Button kivalasztBtn;
    }
}