namespace Zeusz.Lekerdezesek
{
    partial class MutatoszamokFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.likviditasiMutatoLbl = new System.Windows.Forms.Label();
            this.likviditasiGyorsrataLbl = new System.Windows.Forms.Label();
            this.nettoMukodoTokeLbl = new System.Windows.Forms.Label();
            this.adossagallomanyAranyaLbl = new System.Windows.Forms.Label();
            this.tokeszerkezetiMutatoLbl = new System.Windows.Forms.Label();
            this.befektetettEszkozFedezettsegLbl = new System.Windows.Forms.Label();
            this.vagyonszerkezetLbl = new System.Windows.Forms.Label();
            this.befektetettEszkozAranyLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kilepesBtn
            // 
            this.kilepesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(208)))), ((int)(((byte)(201)))));
            this.kilepesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kilepesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mutatószámok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.adossagallomanyAranyaLbl);
            this.groupBox1.Controls.Add(this.nettoMukodoTokeLbl);
            this.groupBox1.Controls.Add(this.likviditasiGyorsrataLbl);
            this.groupBox1.Controls.Add(this.likviditasiMutatoLbl);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 233);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pénzügyi helyzet mutatószámai";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.befektetettEszkozAranyLbl);
            this.groupBox2.Controls.Add(this.vagyonszerkezetLbl);
            this.groupBox2.Controls.Add(this.befektetettEszkozFedezettsegLbl);
            this.groupBox2.Controls.Add(this.tokeszerkezetiMutatoLbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(394, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 233);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vagyoni helyzet mutatószámai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Likviditási mutató:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Likviditási gyorsráta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nettó működő tőke:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tőkeszerkezeti mutató:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Befektetett eszközök fedezettsége:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Vagyonszerkezet:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Befektetett eszközök aránya:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Adósságállomány aránya:";
            // 
            // likviditasiMutatoLbl
            // 
            this.likviditasiMutatoLbl.AutoSize = true;
            this.likviditasiMutatoLbl.Location = new System.Drawing.Point(288, 45);
            this.likviditasiMutatoLbl.Name = "likviditasiMutatoLbl";
            this.likviditasiMutatoLbl.Size = new System.Drawing.Size(60, 20);
            this.likviditasiMutatoLbl.TabIndex = 4;
            this.likviditasiMutatoLbl.Text = "label10";
            // 
            // likviditasiGyorsrataLbl
            // 
            this.likviditasiGyorsrataLbl.AutoSize = true;
            this.likviditasiGyorsrataLbl.Location = new System.Drawing.Point(288, 96);
            this.likviditasiGyorsrataLbl.Name = "likviditasiGyorsrataLbl";
            this.likviditasiGyorsrataLbl.Size = new System.Drawing.Size(60, 20);
            this.likviditasiGyorsrataLbl.TabIndex = 5;
            this.likviditasiGyorsrataLbl.Text = "label10";
            // 
            // nettoMukodoTokeLbl
            // 
            this.nettoMukodoTokeLbl.AutoSize = true;
            this.nettoMukodoTokeLbl.Location = new System.Drawing.Point(288, 146);
            this.nettoMukodoTokeLbl.Name = "nettoMukodoTokeLbl";
            this.nettoMukodoTokeLbl.Size = new System.Drawing.Size(60, 20);
            this.nettoMukodoTokeLbl.TabIndex = 6;
            this.nettoMukodoTokeLbl.Text = "label10";
            // 
            // adossagallomanyAranyaLbl
            // 
            this.adossagallomanyAranyaLbl.AutoSize = true;
            this.adossagallomanyAranyaLbl.Location = new System.Drawing.Point(288, 197);
            this.adossagallomanyAranyaLbl.Name = "adossagallomanyAranyaLbl";
            this.adossagallomanyAranyaLbl.Size = new System.Drawing.Size(60, 20);
            this.adossagallomanyAranyaLbl.TabIndex = 7;
            this.adossagallomanyAranyaLbl.Text = "label10";
            // 
            // tokeszerkezetiMutatoLbl
            // 
            this.tokeszerkezetiMutatoLbl.AutoSize = true;
            this.tokeszerkezetiMutatoLbl.Location = new System.Drawing.Point(341, 45);
            this.tokeszerkezetiMutatoLbl.Name = "tokeszerkezetiMutatoLbl";
            this.tokeszerkezetiMutatoLbl.Size = new System.Drawing.Size(60, 20);
            this.tokeszerkezetiMutatoLbl.TabIndex = 4;
            this.tokeszerkezetiMutatoLbl.Text = "label10";
            // 
            // befektetettEszkozFedezettsegLbl
            // 
            this.befektetettEszkozFedezettsegLbl.AutoSize = true;
            this.befektetettEszkozFedezettsegLbl.Location = new System.Drawing.Point(341, 96);
            this.befektetettEszkozFedezettsegLbl.Name = "befektetettEszkozFedezettsegLbl";
            this.befektetettEszkozFedezettsegLbl.Size = new System.Drawing.Size(60, 20);
            this.befektetettEszkozFedezettsegLbl.TabIndex = 5;
            this.befektetettEszkozFedezettsegLbl.Text = "label10";
            // 
            // vagyonszerkezetLbl
            // 
            this.vagyonszerkezetLbl.AutoSize = true;
            this.vagyonszerkezetLbl.Location = new System.Drawing.Point(341, 146);
            this.vagyonszerkezetLbl.Name = "vagyonszerkezetLbl";
            this.vagyonszerkezetLbl.Size = new System.Drawing.Size(60, 20);
            this.vagyonszerkezetLbl.TabIndex = 6;
            this.vagyonszerkezetLbl.Text = "label10";
            // 
            // befektetettEszkozAranyLbl
            // 
            this.befektetettEszkozAranyLbl.AutoSize = true;
            this.befektetettEszkozAranyLbl.Location = new System.Drawing.Point(341, 197);
            this.befektetettEszkozAranyLbl.Name = "befektetettEszkozAranyLbl";
            this.befektetettEszkozAranyLbl.Size = new System.Drawing.Size(60, 20);
            this.befektetettEszkozAranyLbl.TabIndex = 7;
            this.befektetettEszkozAranyLbl.Text = "label10";
            // 
            // MutatoszamokFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kilepesBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MutatoszamokFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mutatószámok";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label adossagallomanyAranyaLbl;
        private System.Windows.Forms.Label nettoMukodoTokeLbl;
        private System.Windows.Forms.Label likviditasiGyorsrataLbl;
        private System.Windows.Forms.Label likviditasiMutatoLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label befektetettEszkozAranyLbl;
        private System.Windows.Forms.Label vagyonszerkezetLbl;
        private System.Windows.Forms.Label befektetettEszkozFedezettsegLbl;
        private System.Windows.Forms.Label tokeszerkezetiMutatoLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}