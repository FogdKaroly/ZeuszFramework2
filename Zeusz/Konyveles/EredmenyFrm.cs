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
                eredmenyDgv.Rows.Add(new Object[] { "    01.", "    Belföldi értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEAI01(), "", AdatbazisMuveletek.Eredmeny.EAI01() });

                eredmenyDgv.Rows.Add(new Object[] { "    02.", "    Export értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEAI02(), "", AdatbazisMuveletek.Eredmeny.EAI02() });

                eredmenyDgv.Rows.Add(new object[] { "  I.", "  Értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEAI(), "", AdatbazisMuveletek.Eredmeny.EAI() });

                eredmenyDgv.Rows.Add(new Object[] { "    03.", "    Saját termelésű készletek állományváltozása", AdatbazisMuveletek.Eredmeny.ElozoEAII03(), "", AdatbazisMuveletek.Eredmeny.EAII03() });

                eredmenyDgv.Rows.Add(new Object[] { "    04.", "    Saját előállítású eszközök aktivált értéke", AdatbazisMuveletek.Eredmeny.ElozoEAII04(), "", AdatbazisMuveletek.Eredmeny.EAII04() });

                eredmenyDgv.Rows.Add(new object[] { "  II.", "  Aktivált saját teljesítmények értéke", AdatbazisMuveletek.Eredmeny.ElozoEAII(), "", AdatbazisMuveletek.Eredmeny.EAII() });

                eredmenyDgv.Rows.Add(new object[] { "  III.", "  Egyéb bevételek", AdatbazisMuveletek.Eredmeny.ElozoEAIII(), "", AdatbazisMuveletek.Eredmeny.EAIII() });

                eredmenyDgv.Rows.Add(new Object[] { "    05.", "    Anyagköltség", AdatbazisMuveletek.Eredmeny.ElozoEAIV05(), "", AdatbazisMuveletek.Eredmeny.EAIV05() });

                eredmenyDgv.Rows.Add(new Object[] { "    06.", "    Igénybe vett szolgáltatások értéke", AdatbazisMuveletek.Eredmeny.ElozoEAIV06(), "", AdatbazisMuveletek.Eredmeny.EAIV06() });

                eredmenyDgv.Rows.Add(new Object[] { "    07.", "    Egyéb szolgáltatások értéke", AdatbazisMuveletek.Eredmeny.ElozoEAIV07(), "", AdatbazisMuveletek.Eredmeny.EAIV07() });

                eredmenyDgv.Rows.Add(new Object[] { "    08.", "    Eladott áruk beszerzési értéke", AdatbazisMuveletek.Eredmeny.ElozoEAIV08(), "", AdatbazisMuveletek.Eredmeny.EAIV08() });

                eredmenyDgv.Rows.Add(new Object[] { "    09.", "    Eladott (közvetített) szolgáltatások értéke", AdatbazisMuveletek.Eredmeny.ElozoEAIV09(), "", AdatbazisMuveletek.Eredmeny.EAIV09() });

                eredmenyDgv.Rows.Add(new object[] { "  IV.", "  Anyagjellegű ráfordítások", AdatbazisMuveletek.Eredmeny.ElozoEAIV(), "", AdatbazisMuveletek.Eredmeny.EAIV() });

                eredmenyDgv.Rows.Add(new Object[] { "    10.", "    Bérköltség", AdatbazisMuveletek.Eredmeny.ElozoEAV10(), "", AdatbazisMuveletek.Eredmeny.EAV10() });

                eredmenyDgv.Rows.Add(new Object[] { "    11.", "    Személyi jellegű egyéb kifizetések", AdatbazisMuveletek.Eredmeny.ElozoEAV11(), "", AdatbazisMuveletek.Eredmeny.EAV11() });

                eredmenyDgv.Rows.Add(new Object[] { "    12.", "    Bérjárulékok", AdatbazisMuveletek.Eredmeny.ElozoEAV12(), "", AdatbazisMuveletek.Eredmeny.EAV12() });

                eredmenyDgv.Rows.Add(new object[] { "  V.", "  Személyi jellegű ráfordítások", AdatbazisMuveletek.Eredmeny.ElozoEAV(), "", AdatbazisMuveletek.Eredmeny.EAV() });

                eredmenyDgv.Rows.Add(new object[] { "  VI.", "  Értékcsökkenési leírás", AdatbazisMuveletek.Eredmeny.ElozoEAVI(), "", AdatbazisMuveletek.Eredmeny.EAVI() });

                eredmenyDgv.Rows.Add(new object[] { "  VII.", "  Egyéb ráfordítások", AdatbazisMuveletek.Eredmeny.ElozoEAVII(), "", AdatbazisMuveletek.Eredmeny.EAVII() });

                eredmenyDgv.Rows.Add(new object[] { "A.", "Üzemi (üzleti) tevékenység eredménye", AdatbazisMuveletek.Eredmeny.ElozoEA(), "", AdatbazisMuveletek.Eredmeny.EA() });
            }
            else
            {
                eredmenyDgv.Rows.Add(new Object[] { "    01.", "    Belföldi értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEAI01(), "", AdatbazisMuveletek.Eredmeny.EAI01() });

                eredmenyDgv.Rows.Add(new Object[] { "    02.", "    Export értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEAI02(), "", AdatbazisMuveletek.Eredmeny.EAI02() });

                eredmenyDgv.Rows.Add(new object[] { "  I.", "  Értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEAI(), "", AdatbazisMuveletek.Eredmeny.EAI() });

                eredmenyDgv.Rows.Add(new Object[] { "    03.", "    Értékesítés elszámolt közvetlen önköltsége", AdatbazisMuveletek.Eredmeny.ElozoEFAII03(), "", AdatbazisMuveletek.Eredmeny.EFAII03() });

                eredmenyDgv.Rows.Add(new Object[] { "    04.", "    Eladott áruk beszerzési értéke", AdatbazisMuveletek.Eredmeny.ElozoEFAII04(), "", AdatbazisMuveletek.Eredmeny.EFAII04() });

                eredmenyDgv.Rows.Add(new Object[] { "    05.", "    Eladott (közvetített) szolgáltatások értéke", AdatbazisMuveletek.Eredmeny.ElozoEFAII05(), "", AdatbazisMuveletek.Eredmeny.EFAII05() });

                eredmenyDgv.Rows.Add(new object[] { "  II.", "  Értékesítés nettó árbevétele", AdatbazisMuveletek.Eredmeny.ElozoEFAII(), "", AdatbazisMuveletek.Eredmeny.EFAII() });

                eredmenyDgv.Rows.Add(new object[] { "  III.", "  Értékesítés bruttó eredménye", AdatbazisMuveletek.Eredmeny.ElozoEFAIII(), "", AdatbazisMuveletek.Eredmeny.EFAIII() });

                eredmenyDgv.Rows.Add(new Object[] { "    06.", "    Értékesítési, foorgalmazási költségek", AdatbazisMuveletek.Eredmeny.ElozoEFAIV06(), "", AdatbazisMuveletek.Eredmeny.EFAIV06() });

                eredmenyDgv.Rows.Add(new Object[] { "    07.", "    Igazgatási költségek", AdatbazisMuveletek.Eredmeny.ElozoEFAIV07(), "", AdatbazisMuveletek.Eredmeny.EFAIV07() });

                eredmenyDgv.Rows.Add(new Object[] { "    08.", "    Egyéb általános költségek", AdatbazisMuveletek.Eredmeny.ElozoEFAIV08(), "", AdatbazisMuveletek.Eredmeny.EFAIV08() });

                eredmenyDgv.Rows.Add(new object[] { "  IV.", "  Értékesítés közvetett költségei", AdatbazisMuveletek.Eredmeny.ElozoEFAIV(), "", AdatbazisMuveletek.Eredmeny.EFAIV() });

                eredmenyDgv.Rows.Add(new object[] { "  V.", "  Egyéb bevételek", AdatbazisMuveletek.Eredmeny.ElozoEFAV(), "", AdatbazisMuveletek.Eredmeny.EFAV() });

                eredmenyDgv.Rows.Add(new object[] { "  VI.", "  Egyéb ráfordítások", AdatbazisMuveletek.Eredmeny.ElozoEFAVI(), "", AdatbazisMuveletek.Eredmeny.EFAVI() });

                eredmenyDgv.Rows.Add(new object[] { "A.", "Üzemi (üzleti) tevékenység eredménye", AdatbazisMuveletek.Eredmeny.ElozoEFA(), "", AdatbazisMuveletek.Eredmeny.EFA() });
            }

            eredmenyDgv.Rows.Add(new Object[] { "    13.", "    Kapott (járó) osztalék és részesedés", AdatbazisMuveletek.Eredmeny.ElozoEBVIII13(), "", AdatbazisMuveletek.Eredmeny.EBVIII13() });

            eredmenyDgv.Rows.Add(new Object[] { "    14.", "    Részesedésekből származó bevételek, árfolyamnyereségek", AdatbazisMuveletek.Eredmeny.ElozoEBVIII14(), "", AdatbazisMuveletek.Eredmeny.EBVIII14() });

            eredmenyDgv.Rows.Add(new Object[] { "    15.", "    Befektetett pénzügyi eszközökből (értékpapírokból, kölcsönökből) származó bevételek, árfolyamnyereségek", AdatbazisMuveletek.Eredmeny.ElozoEBVIII15(), "", AdatbazisMuveletek.Eredmeny.EBVIII15() });

            eredmenyDgv.Rows.Add(new Object[] { "    16.", "    Egyéb kapott (járó) kamatok és kamatjellegű bevételek", AdatbazisMuveletek.Eredmeny.ElozoEBVIII16(), "", AdatbazisMuveletek.Eredmeny.EBVIII16() });

            eredmenyDgv.Rows.Add(new Object[] { "    17.", "    Pénzügyi műveletek egyéb bevételei", AdatbazisMuveletek.Eredmeny.ElozoEBVIII17(), "", AdatbazisMuveletek.Eredmeny.EBVIII17() });

            eredmenyDgv.Rows.Add(new object[] { "  VIII.", "  Pénzügyi műveletek bevételei", AdatbazisMuveletek.Eredmeny.ElozoEBVIII(), "", AdatbazisMuveletek.Eredmeny.EBVIII() });

            eredmenyDgv.Rows.Add(new Object[] { "    18.", "    Részesedésekből származó ráfordítások, árfolyamveszteségek", AdatbazisMuveletek.Eredmeny.ElozoEBIX18(), "", AdatbazisMuveletek.Eredmeny.EBIX18() });

            eredmenyDgv.Rows.Add(new Object[] { "    19.", "    Befektetett pénzügyi eszközökből (értékpapírokból, kölcsönökből) származó ráfordítások, árfolyamveszteségek", AdatbazisMuveletek.Eredmeny.ElozoEBIX19(), "", AdatbazisMuveletek.Eredmeny.EBIX19() });

            eredmenyDgv.Rows.Add(new Object[] { "    20.", "    Fizetendő (fizetett) kamatok és kamatjellegű ráfordítások", AdatbazisMuveletek.Eredmeny.ElozoEBIX20(), "", AdatbazisMuveletek.Eredmeny.EBIX20() });

            eredmenyDgv.Rows.Add(new Object[] { "    21.", "    Részesedések, értékpapírok, tartósan adott kölcsönök, bankbetétek értékvesztése", AdatbazisMuveletek.Eredmeny.ElozoEBIX21(), "", AdatbazisMuveletek.Eredmeny.EBIX21() });

            eredmenyDgv.Rows.Add(new Object[] { "    22.", "    Pénzügyi műveletek egyéb ráfordításai", AdatbazisMuveletek.Eredmeny.ElozoEBIX22(), "", AdatbazisMuveletek.Eredmeny.EBIX22() });

            eredmenyDgv.Rows.Add(new object[] { "  IX.", "  Pénzügyi műveletek ráfordításai", AdatbazisMuveletek.Eredmeny.ElozoEBIX(), "", AdatbazisMuveletek.Eredmeny.EBIX() });

            eredmenyDgv.Rows.Add(new object[] { "B.", "Pénzügyi műveletek erredménye", AdatbazisMuveletek.Eredmeny.ElozoEB(), "", AdatbazisMuveletek.Eredmeny.EB() });

            eredmenyDgv.Rows.Add(new object[] { "C.", "Adózás előtti eredmény", AdatbazisMuveletek.Eredmeny.ElozoEC(), "", AdatbazisMuveletek.Eredmeny.EC() });

            eredmenyDgv.Rows.Add(new object[] { "  X.", "  Adófizetési kötelezettség", AdatbazisMuveletek.Eredmeny.ElozoEDX(), "", AdatbazisMuveletek.Eredmeny.EDX() });

            eredmenyDgv.Rows.Add(new object[] { "D.", "Adózott eredmény", AdatbazisMuveletek.Eredmeny.ElozoED(), "", AdatbazisMuveletek.Eredmeny.ED() });

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
