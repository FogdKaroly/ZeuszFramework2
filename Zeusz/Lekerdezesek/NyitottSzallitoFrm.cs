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
    public partial class NyitottSzallitoFrm : Form
    {
        List<Konyveles.KonyvelesiTetel> nyitottSzallitok;

        public NyitottSzallitoFrm()
        {
            InitializeComponent();
            NyitottSzallitoFrissites();
        }

        private void NyitottSzallitoFrissites()
        {
            nyitottSzallitok = AdatbazisMuveletek.Lekerdezesek.NyitottSzallitokLekerdezese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            nyitottSzallitokLbx.DataSource = null;
            nyitottSzallitokLbx.DataSource = nyitottSzallitok;
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nyitottSzallitokLbx_DoubleClick(object sender, EventArgs e)
        {
            if (nyitottSzallitokLbx.SelectedIndex != -1)
            {
                NyitottSzallitoLezarasaFrm nyitottSzallitoLezarasaFrm = new NyitottSzallitoLezarasaFrm((Konyveles.KonyvelesiTetel)nyitottSzallitokLbx.SelectedItem);
                if (nyitottSzallitoLezarasaFrm.ShowDialog() == DialogResult.OK)
                {
                    NyitottSzallitoFrissites();
                }
            }
        }
    }
}
