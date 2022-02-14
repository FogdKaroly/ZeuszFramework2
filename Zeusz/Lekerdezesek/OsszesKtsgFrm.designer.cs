namespace Zeusz.Lekerdezesek
{
    partial class OsszesKtsgFrm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.kilepesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.osszesKtsgPanel = new System.Windows.Forms.Panel();
            this.osszesKtsgChrt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.osszesKtsgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osszesKtsgChrt)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(60, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Összes költség megoszlása";
            // 
            // osszesKtsgPanel
            // 
            this.osszesKtsgPanel.Controls.Add(this.osszesKtsgChrt);
            this.osszesKtsgPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.osszesKtsgPanel.Location = new System.Drawing.Point(0, 54);
            this.osszesKtsgPanel.Name = "osszesKtsgPanel";
            this.osszesKtsgPanel.Size = new System.Drawing.Size(834, 607);
            this.osszesKtsgPanel.TabIndex = 10;
            // 
            // osszesKtsgChrt
            // 
            this.osszesKtsgChrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            chartArea1.Name = "ChartArea1";
            this.osszesKtsgChrt.ChartAreas.Add(chartArea1);
            this.osszesKtsgChrt.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.osszesKtsgChrt.Legends.Add(legend1);
            this.osszesKtsgChrt.Location = new System.Drawing.Point(0, 0);
            this.osszesKtsgChrt.Name = "osszesKtsgChrt";
            this.osszesKtsgChrt.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series1.Legend = "Legend1";
            series1.Name = "OsszesKtsg";
            this.osszesKtsgChrt.Series.Add(series1);
            this.osszesKtsgChrt.Size = new System.Drawing.Size(834, 607);
            this.osszesKtsgChrt.TabIndex = 0;
            this.osszesKtsgChrt.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            title1.Name = "Title1";
            title1.Text = "Összes költség megoszlása";
            this.osszesKtsgChrt.Titles.Add(title1);
            // 
            // OsszesKtsgFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.osszesKtsgPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OsszesKtsgFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Összes költség megoszlása";
            this.osszesKtsgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.osszesKtsgChrt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel osszesKtsgPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart osszesKtsgChrt;
    }
}