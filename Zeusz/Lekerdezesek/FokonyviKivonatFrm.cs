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
    public partial class FokonyviKivonatFrm : Form
    {
        List<Konyveles.KonyvelesiTetel> tetelek;

        public FokonyviKivonatFrm()
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
            tetelek = (AdatbazisMuveletek.Lekerdezesek.KivonatLekeres(Convert.ToInt32(evTxb.Text), AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, Convert.ToInt32(tolTxb.Text), Convert.ToInt32(igTxb.Text), fokonyviSzamTxb.Text));
            List<Konyveles.Szamla> szamlak = AdatbazisMuveletek.Lekerdezesek.OsszesSzamlaLekerese();
            List<Konyveles.KonyvelesiTetel> listazottTetelek = new List<Konyveles.KonyvelesiTetel>();
            string kapcsolodikIde = "";

            double osszesT = 0;
            double osszesK = 0;
            
            kivonatDgv.Rows.Clear();

            foreach (var tetel in tetelek)
            {
                for (int i = 0; i < szamlak.Count; i++)
                {
                    if (tetel.TSzamla == szamlak[i].Szamlaszam)
                    {
                        listazottTetelek.Add(tetel);
                        kapcsolodikIde = szamlak[i].KapcsolodikIde;
                        osszesT += tetel.TOsszeg;
                        osszesK -= tetel.KOsszeg;
                    }
                }
                
                kivonatDgv.Rows.Add(
                    new object[]
                    {
                        tetel.TSzamla,
                        tetel.TOsszeg,
                        tetel.KOsszeg * -1,
                        Math.Round(tetel.TOsszeg - tetel.KOsszeg, 2)
                    }
                );
            }

            if (osszesT != 0 || osszesK != 0)
            {
                kivonatDgv.Rows.Add(
                new object[]
                {
                        kapcsolodikIde + " összesen",
                        osszesT,
                        osszesK,
                        Math.Round((osszesT + osszesK), 2)
                }
            );
            }

            excelExportBtn.Visible = true;
            csvExportBtn.Visible = true;
            lekerDatumLbl.Visible = true;

            AdatbazisMuveletek.Lekerdezesek.KivonatTorles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
        }

        private void excelExportBtn_Click(object sender, EventArgs e)
        {
            if (kivonatDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < kivonatDgv.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = kivonatDgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < kivonatDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < kivonatDgv.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = kivonatDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void csvExportBtn_Click(object sender, EventArgs e)
        {
            if (kivonatDgv.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                saveFileDialog.FileName = "kivonat.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    int sorokSzama = kivonatDgv.Columns.Count;
                    string sorNevek = "";
                    string[] exportAdatok = new string[kivonatDgv.Rows.Count + 1];

                    for (int i = 0; i < sorokSzama; i++)
                    {
                        sorNevek += kivonatDgv.Columns[i].HeaderText.ToString();
                    }
                    exportAdatok[0] += sorNevek;

                    for (int i = 1; (i - 1) < kivonatDgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < sorokSzama; j++)
                        {
                            exportAdatok[i] += kivonatDgv.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(saveFileDialog.FileName, exportAdatok, Encoding.UTF8);

                    MessageBox.Show("A kivonat exportálása CSV-be sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
