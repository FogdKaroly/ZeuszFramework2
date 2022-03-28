namespace Zeusz.Lekerdezesek
{
    partial class BevetelKtsgAranyFrm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.kilepesBtn = new System.Windows.Forms.Button();
            this.bevetelKtsgAranyPanel = new System.Windows.Forms.Panel();
            this.bevetelKtsgChrt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bevetelKtsgAranyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bevetelKtsgChrt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(59, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Bevételek és költségek aránya";
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
            this.kilepesBtn.TabIndex = 10;
            this.kilepesBtn.Text = "X";
            this.kilepesBtn.UseVisualStyleBackColor = false;
            this.kilepesBtn.Click += new System.EventHandler(this.kilepesBtn_Click);
            // 
            // bevetelKtsgAranyPanel
            // 
            this.bevetelKtsgAranyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.bevetelKtsgAranyPanel.Controls.Add(this.bevetelKtsgChrt);
            this.bevetelKtsgAranyPanel.Location = new System.Drawing.Point(12, 58);
            this.bevetelKtsgAranyPanel.Name = "bevetelKtsgAranyPanel";
            this.bevetelKtsgAranyPanel.Size = new System.Drawing.Size(810, 591);
            this.bevetelKtsgAranyPanel.TabIndex = 12;
            // 
            // bevetelKtsgChrt
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.Maximum = 12D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisX.Title = "Hónap";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.Title = "Ft";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.Name = "ChartArea1";
            this.bevetelKtsgChrt.ChartAreas.Add(chartArea1);
            this.bevetelKtsgChrt.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.bevetelKtsgChrt.Legends.Add(legend1);
            this.bevetelKtsgChrt.Location = new System.Drawing.Point(0, 0);
            this.bevetelKtsgChrt.Name = "bevetelKtsgChrt";
            this.bevetelKtsgChrt.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.LegendText = "Bevétel";
            series1.Name = "bevetel";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.LegendText = "Költségek-ráfordítások";
            series2.Name = "koltsegRaford";
            this.bevetelKtsgChrt.Series.Add(series1);
            this.bevetelKtsgChrt.Series.Add(series2);
            this.bevetelKtsgChrt.Size = new System.Drawing.Size(810, 591);
            this.bevetelKtsgChrt.TabIndex = 0;
            this.bevetelKtsgChrt.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            title1.Name = "Title1";
            title1.Text = "Bevételek és költségek aránya";
            this.bevetelKtsgChrt.Titles.Add(title1);
            // 
            // BevetelKtsgAranyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.bevetelKtsgAranyPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BevetelKtsgAranyFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BevetelKtsgAranyFrm";
            this.bevetelKtsgAranyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bevetelKtsgChrt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Panel bevetelKtsgAranyPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart bevetelKtsgChrt;
    }
}