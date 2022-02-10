using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz
{
    public partial class KonyvelocegAdataiFrm : Form
    {
        List<KonyvelocegAdatai> konyvelocegAdatok;

        public KonyvelocegAdataiFrm()
        {
            InitializeComponent();
            kozteruletJellegeCbx.DataSource = Enum.GetValues(typeof(KozteruletJellege));
            Ceglekeres();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ceglekeres()
        {
            konyvelocegAdatok = AdatbazisMuveletek.Lekerdezesek.KönyvelocegAdataiLekerdezes();

            if (konyvelocegAdatok.Count > 0)
            {
                foreach (KonyvelocegAdatai adat in konyvelocegAdatok)
                {
                    teljesCegnevTxb.Text = adat.Cegnev;
                    rovidCegnevTxb.Text = adat.RovidCegnev;
                    iranyitoszamTxb.Text = adat.Iranyitoszam;
                    varosTxb.Text = adat.Varos;
                    kozteruletNeveTbx.Text = adat.KozteruletNeve;
                    kozteruletJellegeCbx.SelectedItem = adat.KozteruletJellege;
                    hazszamTxb.Text = adat.Hazszam;
                    lepcsohazTxb.Text = adat.Lepcsohaz;
                    ajtoTxb.Text = adat.Ajto;
                    adoszamTxb.Text = adat.Adoszam;
                    euAdoszamtxb.Text = adat.EuAdoszam;
                    cegjegyzekszamTxb.Text = adat.Cegjegyzekszam;
                    bankszamlaszam1Txb.Text = adat.Bankszamlaszam;
                    bankszamlaszam2Txb.Text = adat.Bankszamlaszam2;
                    bankszamlaszam3Txb.Text = adat.Bankszamlaszam3;
                    emailTxb.Text = adat.Email;
                    telefonTxb.Text = adat.Telefon;
                }
            }
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            KonyvelocegAdatai konyvelocegAdatai = new KonyvelocegAdatai(teljesCegnevTxb.Text, bankszamlaszam2Txb.Text, bankszamlaszam3Txb.Text, rovidCegnevTxb.Text, iranyitoszamTxb.Text, varosTxb.Text, kozteruletNeveTbx.Text, (KozteruletJellege)kozteruletJellegeCbx.SelectedItem, hazszamTxb.Text, lepcsohazTxb.Text, ajtoTxb.Text, adoszamTxb.Text, euAdoszamtxb.Text, cegjegyzekszamTxb.Text, bankszamlaszam1Txb.Text, emailTxb.Text, telefonTxb.Text);

            AdatbazisMuveletek.Insertek.CegAdatFeltoltes(konyvelocegAdatai);
            this.Close();
        }

        private void iranyitoszamTxb_Leave(object sender, EventArgs e)
        {
            varosTxb.Text = "";
            varosTxb.Text = AdatbazisMuveletek.Lekerdezesek.VarosLekeres(iranyitoszamTxb.Text.Trim());
        }
    }
}
