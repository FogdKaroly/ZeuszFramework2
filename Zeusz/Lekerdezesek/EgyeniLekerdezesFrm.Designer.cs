namespace Zeusz.Lekerdezesek
{
    partial class EgyeniLekerdezesFrm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.kilepesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.anyagktsgCbx = new System.Windows.Forms.CheckBox();
            this.igenybeVettSzolgCbx = new System.Windows.Forms.CheckBox();
            this.egyekSzolgCbx = new System.Windows.Forms.CheckBox();
            this.berktsgCbx = new System.Windows.Forms.CheckBox();
            this.szemJellEgyebCbx = new System.Windows.Forms.CheckBox();
            this.jarulekCbx = new System.Windows.Forms.CheckBox();
            this.ertekcsokkenesCbx = new System.Windows.Forms.CheckBox();
            this.lekerdezesBtn = new System.Windows.Forms.Button();
            this.koltsegekChrt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.koltsegekChrt)).BeginInit();
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
            this.kilepesBtn.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Egyéni lekérdezés";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Jelölje ki a megtekinteni kívánt tételeket!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "A lekérdezés egy összehasonlító elemzés.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(618, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "A bázis az előző év adatai.";
            // 
            // anyagktsgCbx
            // 
            this.anyagktsgCbx.AutoSize = true;
            this.anyagktsgCbx.Location = new System.Drawing.Point(16, 119);
            this.anyagktsgCbx.Name = "anyagktsgCbx";
            this.anyagktsgCbx.Size = new System.Drawing.Size(124, 24);
            this.anyagktsgCbx.TabIndex = 13;
            this.anyagktsgCbx.Tag = "51";
            this.anyagktsgCbx.Text = "Anyagköltség";
            this.anyagktsgCbx.UseVisualStyleBackColor = true;
            // 
            // igenybeVettSzolgCbx
            // 
            this.igenybeVettSzolgCbx.AutoSize = true;
            this.igenybeVettSzolgCbx.Location = new System.Drawing.Point(16, 163);
            this.igenybeVettSzolgCbx.Name = "igenybeVettSzolgCbx";
            this.igenybeVettSzolgCbx.Size = new System.Drawing.Size(221, 24);
            this.igenybeVettSzolgCbx.TabIndex = 14;
            this.igenybeVettSzolgCbx.Tag = "52";
            this.igenybeVettSzolgCbx.Text = "Igénybe vett szolgáltatások";
            this.igenybeVettSzolgCbx.UseVisualStyleBackColor = true;
            // 
            // egyekSzolgCbx
            // 
            this.egyekSzolgCbx.AutoSize = true;
            this.egyekSzolgCbx.Location = new System.Drawing.Point(16, 214);
            this.egyekSzolgCbx.Name = "egyekSzolgCbx";
            this.egyekSzolgCbx.Size = new System.Drawing.Size(179, 24);
            this.egyekSzolgCbx.TabIndex = 15;
            this.egyekSzolgCbx.Tag = "53";
            this.egyekSzolgCbx.Text = "Egyéb szolgáltatások";
            this.egyekSzolgCbx.UseVisualStyleBackColor = true;
            // 
            // berktsgCbx
            // 
            this.berktsgCbx.AutoSize = true;
            this.berktsgCbx.Location = new System.Drawing.Point(16, 261);
            this.berktsgCbx.Name = "berktsgCbx";
            this.berktsgCbx.Size = new System.Drawing.Size(104, 24);
            this.berktsgCbx.TabIndex = 16;
            this.berktsgCbx.Tag = "54";
            this.berktsgCbx.Text = "Bérköltség";
            this.berktsgCbx.UseVisualStyleBackColor = true;
            // 
            // szemJellEgyebCbx
            // 
            this.szemJellEgyebCbx.AutoSize = true;
            this.szemJellEgyebCbx.Location = new System.Drawing.Point(16, 304);
            this.szemJellEgyebCbx.Name = "szemJellEgyebCbx";
            this.szemJellEgyebCbx.Size = new System.Drawing.Size(266, 24);
            this.szemJellEgyebCbx.TabIndex = 17;
            this.szemJellEgyebCbx.Tag = "55";
            this.szemJellEgyebCbx.Text = "Személyi jellegű egyéb kifizetések";
            this.szemJellEgyebCbx.UseVisualStyleBackColor = true;
            // 
            // jarulekCbx
            // 
            this.jarulekCbx.AutoSize = true;
            this.jarulekCbx.Location = new System.Drawing.Point(16, 352);
            this.jarulekCbx.Name = "jarulekCbx";
            this.jarulekCbx.Size = new System.Drawing.Size(116, 24);
            this.jarulekCbx.TabIndex = 18;
            this.jarulekCbx.Tag = "56";
            this.jarulekCbx.Text = "Bérjárulékok";
            this.jarulekCbx.UseVisualStyleBackColor = true;
            // 
            // ertekcsokkenesCbx
            // 
            this.ertekcsokkenesCbx.AutoSize = true;
            this.ertekcsokkenesCbx.Location = new System.Drawing.Point(16, 399);
            this.ertekcsokkenesCbx.Name = "ertekcsokkenesCbx";
            this.ertekcsokkenesCbx.Size = new System.Drawing.Size(142, 24);
            this.ertekcsokkenesCbx.TabIndex = 19;
            this.ertekcsokkenesCbx.Tag = "57";
            this.ertekcsokkenesCbx.Text = "Értékcsökkenés";
            this.ertekcsokkenesCbx.UseVisualStyleBackColor = true;
            // 
            // lekerdezesBtn
            // 
            this.lekerdezesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.lekerdezesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lekerdezesBtn.Location = new System.Drawing.Point(628, 597);
            this.lekerdezesBtn.Name = "lekerdezesBtn";
            this.lekerdezesBtn.Size = new System.Drawing.Size(194, 52);
            this.lekerdezesBtn.TabIndex = 20;
            this.lekerdezesBtn.Text = "Lekérdezés";
            this.lekerdezesBtn.UseVisualStyleBackColor = false;
            this.lekerdezesBtn.Click += new System.EventHandler(this.lekerdezesBtn_Click);
            // 
            // koltsegekChrt
            // 
            chartArea2.Name = "ChartArea1";
            this.koltsegekChrt.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.koltsegekChrt.Legends.Add(legend2);
            this.koltsegekChrt.Location = new System.Drawing.Point(303, 119);
            this.koltsegekChrt.Name = "koltsegekChrt";
            this.koltsegekChrt.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "bazis";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "targy";
            this.koltsegekChrt.Series.Add(series3);
            this.koltsegekChrt.Series.Add(series4);
            this.koltsegekChrt.Size = new System.Drawing.Size(519, 431);
            this.koltsegekChrt.TabIndex = 21;
            this.koltsegekChrt.Text = "Költségek";
            // 
            // EgyeniLekerdezesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.koltsegekChrt);
            this.Controls.Add(this.lekerdezesBtn);
            this.Controls.Add(this.ertekcsokkenesCbx);
            this.Controls.Add(this.jarulekCbx);
            this.Controls.Add(this.szemJellEgyebCbx);
            this.Controls.Add(this.berktsgCbx);
            this.Controls.Add(this.egyekSzolgCbx);
            this.Controls.Add(this.igenybeVettSzolgCbx);
            this.Controls.Add(this.anyagktsgCbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EgyeniLekerdezesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EgyeniLekerdezesFrm";
            ((System.ComponentModel.ISupportInitialize)(this.koltsegekChrt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox anyagktsgCbx;
        private System.Windows.Forms.CheckBox igenybeVettSzolgCbx;
        private System.Windows.Forms.CheckBox egyekSzolgCbx;
        private System.Windows.Forms.CheckBox berktsgCbx;
        private System.Windows.Forms.CheckBox szemJellEgyebCbx;
        private System.Windows.Forms.CheckBox jarulekCbx;
        private System.Windows.Forms.CheckBox ertekcsokkenesCbx;
        private System.Windows.Forms.Button lekerdezesBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart koltsegekChrt;
    }
}