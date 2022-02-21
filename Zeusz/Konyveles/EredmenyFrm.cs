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
            EredmenyKeszites();
            lekerDatumLbl.Text = DateTime.Now.ToShortDateString();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void EredmenyKeszites()
        {
            eredmenyDgv.Rows.Clear();

            bool osszktsg = AdatbazisMuveletek.Lekerdezesek.OsszkoltsegesE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            
            if (osszktsg)
            {
                eredmenyDgv.Rows.Add(new Object[] { "    01.", "    Belföldi értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI01() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI01() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    02.", "    Export értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI02() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI02() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  I.", "  Értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    03.", "    Saját termelésű készletek állományváltozása", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAII03() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAII03() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    04.", "    Saját előállítású eszközök aktivált értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAII04() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAII04() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  II.", "  Aktivált saját teljesítmények értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAII() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAII() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  III.", "  Egyéb bevételek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIII() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    05.", "    Anyagköltség", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV05() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV05() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    06.", "    Igénybe vett szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV06() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV06() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    07.", "    Egyéb szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV07() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV07() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    08.", "    Eladott áruk beszerzési értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV08() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV08() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    09.", "    Eladott (közvetített) szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV09() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV09() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  IV.", "  Anyagjellegű ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAIV() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAIV() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    10.", "    Bérköltség", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV10() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV10() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    11.", "    Személyi jellegű egyéb kifizetések", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV11() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV11() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    12.", "    Bérjárulékok", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV12() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV12() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  V.", "  Személyi jellegű ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAV() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAV() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  VI.", "  Értékcsökkenési leírás", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAVI() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAVI() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  VII.", "  Egyéb ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAVII() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAVII() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "A.", "Üzemi (üzleti) tevékenység eredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEA() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EA() / 1000f) });
            }
            else
            {
                eredmenyDgv.Rows.Add(new Object[] { "    01.", "    Belföldi értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI01() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI01() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    02.", "    Export értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI02() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI02() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  I.", "  Értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEAI() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EAI() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    03.", "    Értékesítés elszámolt közvetlen önköltsége", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII03() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII03() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    04.", "    Eladott áruk beszerzési értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII04() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII04() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    05.", "    Eladott (közvetített) szolgáltatások értéke", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII05() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII05() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  II.", "  Értékesítés nettó árbevétele", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAII() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAII() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  III.", "  Értékesítés bruttó eredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIII() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    06.", "    Értékesítési, foorgalmazási költségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV06() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV06() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    07.", "    Igazgatási költségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV07() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV07() / 1000f) });

                eredmenyDgv.Rows.Add(new Object[] { "    08.", "    Egyéb általános költségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV08() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV08() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  IV.", "  Értékesítés közvetett költségei", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAIV() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAIV() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  V.", "  Egyéb bevételek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAV() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAV() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "  VI.", "  Egyéb ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFAVI() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFAVI() / 1000f) });

                eredmenyDgv.Rows.Add(new object[] { "A.", "Üzemi (üzleti) tevékenység eredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEFA() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EFA() / 1000f) });
            }

            eredmenyDgv.Rows.Add(new Object[] { "    13.", "    Kapott (járó) osztalék és részesedés", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII13() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII13() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    14.", "    Részesedésekből származó bevételek, árfolyamnyereségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII14() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII14() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    15.", "    Befektetett pénzügyi eszközökből (értékpapírokból, kölcsönökből) származó bevételek, árfolyamnyereségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII15() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII15() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    16.", "    Egyéb kapott (járó) kamatok és kamatjellegű bevételek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII16() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII16() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    17.", "    Pénzügyi műveletek egyéb bevételei", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII17() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII17() / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "  VIII.", "  Pénzügyi műveletek bevételei", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBVIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBVIII() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    18.", "    Részesedésekből származó ráfordítások, árfolyamveszteségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX18() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX18() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    19.", "    Befektetett pénzügyi eszközökből (értékpapírokból, kölcsönökből) származó ráfordítások, árfolyamveszteségek", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX19() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX19() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    20.", "    Fizetendő (fizetett) kamatok és kamatjellegű ráfordítások", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX20() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX20() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    21.", "    Részesedések, értékpapírok, tartósan adott kölcsönök, bankbetétek értékvesztése", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX21() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX21() / 1000f) });

            eredmenyDgv.Rows.Add(new Object[] { "    22.", "    Pénzügyi műveletek egyéb ráfordításai", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX22() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX22() / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "  IX.", "  Pénzügyi műveletek ráfordításai", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEBIX() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EBIX() / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "B.", "Pénzügyi műveletek erredménye", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEB() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EB() / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "C.", "Adózás előtti eredmény", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEC() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EC() / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "  X.", "  Adófizetési kötelezettség", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoEDX() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.EDX() / 1000f) });

            eredmenyDgv.Rows.Add(new object[] { "D.", "Adózott eredmény", Math.Round(AdatbazisMuveletek.Eredmeny.ElozoED() / 1000f), "", Math.Round(AdatbazisMuveletek.Eredmeny.ED() / 1000f) });

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
    }
}
