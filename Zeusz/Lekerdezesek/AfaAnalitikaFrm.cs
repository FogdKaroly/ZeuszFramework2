using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Lekerdezesek
{
    public partial class AfaAnalitikaFrm : Form
    {
        public AfaAnalitikaFrm()
        {
            InitializeComponent();
            lekerDatumLbl.Text = DateTime.Now.ToShortDateString();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void lekerdezesBtn_Click(object sender, EventArgs e)
        {
            afaAnalitikaDgv.Rows.Clear();

            List<Konyveles.KonyvelesiTetel> tetelek = AdatbazisMuveletek.Lekerdezesek.AfaAnalitikaLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, Convert.ToInt32(tolTxb.Text), Convert.ToInt32(igTxb.Text));

            for (int i = 1; i <= 12; i++)
            {
                var honap = from tetel in tetelek where tetel.Honap == i select tetel;

                foreach (var tetel in honap)
                {
                    afaAnalitikaDgv.Rows.Add(
                            new object[]
                            {
                                tetel.Honap,
                                tetel.Szamlaszam,
                                AdatbazisMuveletek.Lekerdezesek.PartnerNevLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, tetel.Partnerkod),
                                tetel.AfaTeljesites.ToShortDateString(),
                                Math.Round(tetel.TOsszeg, 2),
                                tetel.Afakulcs,
                                Math.Round(tetel.AfaSzamitas(), 2),
                                tetel.TOsszeg + tetel.AfaSzamitas()
                            }
                    );
                }
                Osszesites(i); 
                
            }

            void Osszesites(int honap)
            {
                double netto = 0;
                double afatartalom = 0;
                for (int i = 0; i < afaAnalitikaDgv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(afaAnalitikaDgv.Rows[i].Cells[0].Value.ToString()) == honap)
                    {
                        netto += Convert.ToDouble(afaAnalitikaDgv.Rows[i].Cells[4].Value.ToString());
                        afatartalom += Convert.ToDouble(afaAnalitikaDgv.Rows[i].Cells[6].Value.ToString());
                    }

                }
                if (netto != 0 || afatartalom != 0)
                {
                    afaAnalitikaDgv.Rows.Add(
                                    new object[]
                                    {
                        honap,
                        "",
                        "",
                        "Összesen",
                        Math.Round(netto, 2),
                        "",
                        Math.Round(afatartalom, 2),
                        Math.Round(netto + afatartalom, 2)
                                    }
                                ); 
                }
            }

            

            excelExportBtn.Visible = true;
            csvExportBtn.Visible = true;
            lekerDatumLbl.Visible = true;

            AdatbazisMuveletek.Lekerdezesek.AfaTorles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
        }

        // Innen a segítség: https://www.c-sharpcorner.com/blogs/export-datagridview-data-to-csv-in-c-sharp
        private void excelExportBtn_Click(object sender, EventArgs e)
        {
            if (afaAnalitikaDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < afaAnalitikaDgv.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = afaAnalitikaDgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < afaAnalitikaDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < afaAnalitikaDgv.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = afaAnalitikaDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void csvExportBtn_Click(object sender, EventArgs e)
        {
            if (afaAnalitikaDgv.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                saveFileDialog.FileName = "afa_analitika.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    int sorokSzama = afaAnalitikaDgv.Columns.Count;
                    string sorNevek = "";
                    string[] exportAdatok = new string[afaAnalitikaDgv.Rows.Count + 1];

                    for (int i = 0; i < sorokSzama; i++)
                    {
                        sorNevek += afaAnalitikaDgv.Columns[i].HeaderText.ToString();
                    }
                    exportAdatok[0] += sorNevek;

                    for (int i = 1; (i - 1) < afaAnalitikaDgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < sorokSzama; j++)
                        {
                            exportAdatok[i] += afaAnalitikaDgv.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(saveFileDialog.FileName, exportAdatok, Encoding.UTF8);

                    MessageBox.Show("Az ÁFA analitika exportálása CSV-be sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
