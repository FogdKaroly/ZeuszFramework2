using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Lekerdezesek
{
    public partial class EgyeniLekerdezesFrm : Form
    {
        public EgyeniLekerdezesFrm()
        {
            InitializeComponent();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //https://stackoverflow.com/questions/35744549/stacked-column-chart-in-c-sharp
        private void lekerdezesBtn_Click(object sender, EventArgs e)
        {
            foreach (var series in koltsegekChrt.Series)
            {
                series.Points.Clear();
            }

            List<Lekerdezesek.KoltsegEgyenleg> targyEgyenlegek = AdatbazisMuveletek.Lekerdezesek.OsszesKoltsegLekerese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            List<Lekerdezesek.KoltsegEgyenleg> bazisEgyenlegek = AdatbazisMuveletek.Lekerdezesek.BazisOsszesKoltsegLekerese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            if (anyagktsgCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Anyagköltség"));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Anyagköltség"));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }

            if (igenybeVettSzolgCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Igénybe vett szolgáltatások"));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Igénybe vett szolgáltatások"));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }

            if (egyekSzolgCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Egyéb szolgáltatások"));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Egyéb szolgáltatások"));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }

            if (berktsgCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Bérköltség"));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Bérköltség"));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }

            if (szemJellEgyebCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Szem. jellegű e. kifiz."));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Szem. jellegű e. kifiz."));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }

            if (jarulekCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Bérjárulékok"));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("Bérjárulékok"));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }

            if (ertekcsokkenesCbx.Checked)
            {
                int targyfound = targyEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("ÉCS"));
                int bazisfound = bazisEgyenlegek.FindIndex(x => x.FokonyviSzam.Equals("ÉCS"));
                if (targyfound != -1)
                {
                    koltsegekChrt.Series["targy"].Points.AddXY(targyEgyenlegek[targyfound].FokonyviSzam, targyEgyenlegek[targyfound].Egyenleg);
                }
                if (bazisfound != -1)
                {
                    koltsegekChrt.Series["bazis"].Points.AddXY(bazisEgyenlegek[bazisfound].FokonyviSzam, bazisEgyenlegek[bazisfound].Egyenleg);
                }
            }
        }
    }
}
