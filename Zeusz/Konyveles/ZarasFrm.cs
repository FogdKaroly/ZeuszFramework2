using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Konyveles
{
    public partial class ZarasFrm : Form
    {
        public ZarasFrm()
        {
            InitializeComponent();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdatbazisMuveletek.Insertek.ZarasVisszavonasa(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            MessageBox.Show("A zárás sikeresen visszavonásra került!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zarasBtn_Click(object sender, EventArgs e)
        {
            AdatbazisMuveletek.Insertek.EredmenyZaras(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            AdatbazisMuveletek.Insertek.EredmenyKonyveles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            AdatbazisMuveletek.Insertek.AfaZaras(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            AdatbazisMuveletek.Insertek.MerlegZaras(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            AdatbazisMuveletek.Insertek.EvLezarasa(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            MessageBox.Show("A zárás sikeresen befejeződött!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
