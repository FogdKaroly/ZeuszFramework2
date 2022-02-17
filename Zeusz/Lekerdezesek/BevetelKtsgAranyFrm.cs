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
    public partial class BevetelKtsgAranyFrm : Form
    {
        public BevetelKtsgAranyFrm()
        {
            InitializeComponent();
            Megjelenites();
        }

        private void Megjelenites()
        {
            List<Zeusz.Lekerdezesek.KoltsegEgyenleg> egyenlegek = AdatbazisMuveletek.Lekerdezesek.BevetelKtsgArany(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            

            foreach (var egyenleg in egyenlegek)
            {
                if (egyenleg.FokonyviSzam.Equals("Bevételek"))
                {
                    bevetelKtsgChrt.Series["bevetel"].Points.AddXY(egyenleg.Honap, egyenleg.Egyenleg);
                }
                if (egyenleg.FokonyviSzam.Equals("Költésgek, ráfordítások"))
                {
                    bevetelKtsgChrt.Series["koltsegRaford"].Points.AddXY(egyenleg.Honap, egyenleg.Egyenleg);
                }
            }
            

        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
