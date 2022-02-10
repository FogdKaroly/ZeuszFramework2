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
    public partial class NyitottVevoFrm : Form
    {
        List<Konyveles.KonyvelesiTetel> nyitottVevok;

        public NyitottVevoFrm()
        {
            InitializeComponent();
            NyitottVevoFrissites();
        }

        private void NyitottVevoFrissites()
        {
            nyitottVevok = AdatbazisMuveletek.Lekerdezesek.NyitottVevokLekerdezese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            nyitottVevokLbx.DataSource = null;
            nyitottVevokLbx.DataSource = nyitottVevok;
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nyitottVevokLbx_DoubleClick(object sender, EventArgs e)
        {
            if (nyitottVevokLbx.SelectedIndex != -1)
            {
                NyitottVevoLezarasaFrm nyitottVevoLezarasaFrm = new NyitottVevoLezarasaFrm((Konyveles.KonyvelesiTetel)nyitottVevokLbx.SelectedItem);
                if (nyitottVevoLezarasaFrm.ShowDialog() == DialogResult.OK)
                {
                    NyitottVevoFrissites();
                }
            }
        }
    }
}
