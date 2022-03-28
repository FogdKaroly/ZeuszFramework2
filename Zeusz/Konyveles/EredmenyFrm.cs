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

namespace Zeusz.Konyveles
{
    public partial class EredmenyFrm : Form
    {
        public EredmenyFrm()
        {
            InitializeComponent();
            lekerDatumLbl.Text = DateTime.Now.ToShortDateString();
            evTxb.Text = evTxb.Text = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis.Substring(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis.Length - 4, 4);
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void excelExportBtn_Click(object sender, EventArgs e)
        {
            if (eredmenyDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < eredmenyDgv.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = eredmenyDgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < eredmenyDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < eredmenyDgv.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = eredmenyDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void csvExportBtn_Click(object sender, EventArgs e)
        {
            if (eredmenyDgv.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                saveFileDialog.FileName = "merleg.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    int sorokSzama = eredmenyDgv.Columns.Count;
                    string sorNevek = "";
                    string[] exportAdatok = new string[eredmenyDgv.Rows.Count + 1];

                    for (int i = 0; i < sorokSzama; i++)
                    {
                        sorNevek += eredmenyDgv.Columns[i].HeaderText.ToString();
                    }
                    exportAdatok[0] += sorNevek;

                    for (int i = 1; (i - 1) < eredmenyDgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < sorokSzama; j++)
                        {
                            exportAdatok[i] += eredmenyDgv.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(saveFileDialog.FileName, exportAdatok, Encoding.UTF8);

                    MessageBox.Show("A mérleg exportálása CSV-be sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void eredmenyKonyveleseBtn_Click(object sender, EventArgs e)
        {
            AdatbazisMuveletek.Insertek.EredmenyKonyveles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            MessageBox.Show("Az adózott eredmény könyvelése sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lekeresBtn_Click(object sender, EventArgs e)
        {
            eredmenyDgv.Rows.Clear();

            bool osszktsg = AdatbazisMuveletek.Lekerdezesek.OsszkoltsegesE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            if (osszktsg)
            {
                eredmenyDgv.Rows.Add(new object[] { "    01.", "    Belföldi értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI01(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI01(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    02.", "    Export értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI02(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI02(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  I.", "  Értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    03.", "    Saját termelésű készletek állományváltozása", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAII03(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAII03(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    04.", "    Saját előállítású eszközök aktivált értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAII04(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAII04(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  II.", "  Aktivált saját teljesítmények értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAII(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAII(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  III.", "  Egyéb bevételek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIII(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIII(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    05.", "    Anyagköltség", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV05(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV05(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    06.", "    Igénybe vett szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV06(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV06(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    07.", "    Egyéb szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV07(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV07(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    08.", "    Eladott áruk beszerzési értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV08(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV08(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    09.", "    Eladott (közvetített) szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV09(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV09(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  IV.", "  Anyagjellegű ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    10.", "    Bérköltség", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV10(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV10(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    11.", "    Személyi jellegű egyéb kifizetések", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV11(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV11(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    12.", "    Bérjárulékok", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV12(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV12(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  V.", "  Személyi jellegű ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  VI.", "  Értékcsökkenési leírás", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAVI(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAVI(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  VII.", "  Egyéb ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAVII(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAVII(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "A.", "Üzemi (üzleti) tevékenység eredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEA(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EA(Convert.ToInt32(evTxb.Text)) / 1000f) });
            }
            else
            {
                eredmenyDgv.Rows.Add(new object[] { "    01.", "    Belföldi értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI01(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI01(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    02.", "    Export értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI02(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI02(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  I.", "  Értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    03.", "    Értékesítés elszámolt közvetlen önköltsége", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII03(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII03(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    04.", "    Eladott áruk beszerzési értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII04(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII04(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    05.", "    Eladott (közvetített) szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII05(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII05(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  II.", "  Értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  III.", "  Értékesítés bruttó eredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIII(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIII(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    06.", "    Értékesítési, foorgalmazási költségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV06(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV06(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    07.", "    Igazgatási költségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV07(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV07(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "    08.", "    Egyéb általános költségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV08(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV08(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  IV.", "  Értékesítés közvetett költségei", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  V.", "  Egyéb bevételek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAV(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAV(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  VI.", "  Egyéb ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAVI(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAVI(Convert.ToInt32(evTxb.Text)) / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "A.", "Üzemi (üzleti) tevékenység eredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFA(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFA(Convert.ToInt32(evTxb.Text)) / 1000f) });
            }

            eredmenyDgv.Rows.Add(new object[] { "    13.", "    Kapott (járó) osztalék és részesedés", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII13(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII13(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    14.", "    Részesedésekből származó bevételek, árfolyamnyereségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII14(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII14(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    15.", "    Befektetett pénzügyi eszközökből (értékpapírokból, kölcsönökből) származó bevételek, árfolyamnyereségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII15(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII15(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    16.", "    Egyéb kapott (járó) kamatok és kamatjellegű bevételek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII16(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII16(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    17.", "    Pénzügyi műveletek egyéb bevételei", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII17(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII17(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "  VIII.", "  Pénzügyi műveletek bevételei", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    18.", "    Részesedésekből származó ráfordítások, árfolyamveszteségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX18(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX18(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    19.", "    Befektetett pénzügyi eszközökből (értékpapírokból, kölcsönökből) származó ráfordítások, árfolyamveszteségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX19(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX19(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    20.", "    Fizetendő (fizetett) kamatok és kamatjellegű ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX20(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX20(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    21.", "    Részesedések, értékpapírok, tartósan adott kölcsönök, bankbetétek értékvesztése", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX21(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX21(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "    22.", "    Pénzügyi műveletek egyéb ráfordításai", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX22(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX22(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "  IX.", "  Pénzügyi műveletek ráfordításai", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "B.", "Pénzügyi műveletek erredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEB(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EB(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "C.", "Adózás előtti eredmény", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEC(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EC(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "  X.", "  Adófizetési kötelezettség", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEDX(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EDX(Convert.ToInt32(evTxb.Text)) / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "D.", "Adózott eredmény", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoED(Convert.ToInt32(evTxb.Text)) / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.ED(Convert.ToInt32(evTxb.Text)) / 1000f) });

            csvExportBtn.Visible = true;
            excelExportBtn.Visible = true;
            lekerDatumLbl.Visible = true;
        }
    }
}
