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
using Microsoft.Office.Interop.Excel;

namespace Zeusz.Lekerdezesek
{
    public partial class FokonyviKartonFrm : Form
    {
        List<Konyveles.KonyvelesiTetel> tetelek;

        public FokonyviKartonFrm()
        {
            InitializeComponent();
            lekerDatumLbl.Text = DateTime.Now.ToShortDateString();
            evTxb.Text = DateTime.Now.Year.ToString();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void lekerdezesBtn_Click(object sender, EventArgs e)
        {
            tetelek = AdatbazisMuveletek.Lekerdezesek.KartonLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, Convert.ToInt32(tolTxb.Text), Convert.ToInt32(igTxb.Text), fokonyviSzamTolTxb.Text, fokonyviSzamIgTxb.Text, Convert.ToInt32(evTxb.Text));

            kartonDgv.Rows.Clear();

            for (int i = 1; i <= 12; i++)
            {
                var esemeny = from tetel in tetelek where tetel.Honap == i select tetel;
                List<Konyveles.Szamla> szamlak = AdatbazisMuveletek.Lekerdezesek.SzamlakLekerese();
                List<Konyveles.KonyvelesiTetel> konyvelesiTetelek = new List<Konyveles.KonyvelesiTetel>();

                double osszesT = 0;
                double osszesK = 0;
                int honap = i;

                for (int j = 0; j < szamlak.Count; j++)
                {
                    foreach (var item in esemeny)
                    {
                        if (item.TSzamla == szamlak[j].Szamlaszam)
                        {
                            konyvelesiTetelek.Add(item);
                        }
                    }
                    foreach (var item in konyvelesiTetelek)
                    {
                        kartonDgv.Rows.Add(
                            new object[]
                            {
                                item.Honap,
                                item.Teljesites.ToShortDateString(),
                                item.TSzamla,
                                item.KSzamla,
                                Math.Round(item.TOsszeg, 2),
                                Math.Round(item.KOsszeg, 2),
                                item.Gazdasagi_esemeny
                            }
                        );
                    }

                    foreach (var item in konyvelesiTetelek)
                    {
                        osszesT += item.TOsszeg;
                        osszesK += item.KOsszeg;
                    }

                    if (osszesT != 0 || osszesK != 0)
                    {
                        kartonDgv.Rows.Add(
                            new object[]
                            {
                                i,
                                "",
                                "",
                                "Összesen: ",
                                Math.Round(osszesT, 2),
                                Math.Round(osszesK, 2),
                                ""
                            }
                        );
                        kartonDgv.Rows.Add(
                            new object[]
                            {
                                "",
                                "",
                                "",
                                "",
                                "",
                                "",
                                ""
                            }
                        );
                    }

                    osszesT = 0;
                    osszesK = 0;
                    konyvelesiTetelek.Clear();
                }
                
            }

            excelExportBtn.Visible = true;
            csvExportBtn.Visible = true;
            lekerDatumLbl.Visible = true;

            AdatbazisMuveletek.Lekerdezesek.KartonTorles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
        }

        private void excelExportBtn_Click(object sender, EventArgs e)
        {
            if (kartonDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < kartonDgv.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = kartonDgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < kartonDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < kartonDgv.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = kartonDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void csvExportBtn_Click(object sender, EventArgs e)
        {
            if (kartonDgv.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                saveFileDialog.FileName = "karton.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    int sorokSzama = kartonDgv.Columns.Count;
                    string sorNevek = "";
                    string[] exportAdatok = new string[kartonDgv.Rows.Count + 1];

                    for (int i = 0; i < sorokSzama; i++)
                    {
                        sorNevek += kartonDgv.Columns[i].HeaderText.ToString();
                    }
                    exportAdatok[0] += sorNevek;

                    for (int i = 1; (i - 1) < kartonDgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < sorokSzama; j++)
                        {
                            exportAdatok[i] += kartonDgv.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(saveFileDialog.FileName, exportAdatok, Encoding.UTF8);

                    MessageBox.Show("A karton exportálása CSV-be sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
