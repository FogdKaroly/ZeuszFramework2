namespace Zeusz.Sugo
{
    partial class KezikonyvFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KezikonyvFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.kezikonyvPdf = new AxAcroPDFLib.AxAcroPDF();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kezikonyvPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kezikonyvPdf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 661);
            this.panel1.TabIndex = 0;
            // 
            // kezikonyvPdf
            // 
            this.kezikonyvPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kezikonyvPdf.Enabled = true;
            this.kezikonyvPdf.Location = new System.Drawing.Point(0, 0);
            this.kezikonyvPdf.Name = "kezikonyvPdf";
            this.kezikonyvPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("kezikonyvPdf.OcxState")));
            this.kezikonyvPdf.Size = new System.Drawing.Size(834, 661);
            this.kezikonyvPdf.TabIndex = 0;
            // 
            // KezikonyvFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KezikonyvFrm";
            this.Text = "KezikonyvFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kezikonyvPdf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AxAcroPDFLib.AxAcroPDF kezikonyvPdf;
    }
}