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
    public partial class UjSzallitoKonyveleseFrm : Form
    {
        List<PartnercegAdatai> partnerek = AdatbazisMuveletek.Lekerdezesek.OsszesPartnerLekerdezes();
        List<Szamla> szamlak = AdatbazisMuveletek.Lekerdezesek.SzamlakLekerese();

        public UjSzallitoKonyveleseFrm()
        {
            InitializeComponent();
            PartnerLista();
            tSzamlaCbx.DataSource = AdatbazisMuveletek.Lekerdezesek.SzamlakLekerese();
            kSzamlaCbx.DataSource = AdatbazisMuveletek.Lekerdezesek.SzamlakLekerese();
            fizetesiModCbx.DataSource = Enum.GetValues(typeof(FizetesiMod));
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PartnerLista()
        {
            foreach (PartnercegAdatai partner in partnerek)
            {
                partnerCbx.Items.Add(partner);
            }
        }

        private void tSzamlaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Szamla kivalasztottTSzamla = (Szamla)tSzamlaCbx.SelectedItem;
            tSzamlaTxb.Text = kivalasztottTSzamla.Szamlaszam;
        }

        private void kSzamlaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Szamla kivalasztottKSzamla = (Szamla)kSzamlaCbx.SelectedItem;
            kSzamlaTxb.Text = kivalasztottKSzamla.Szamlaszam;
        }

        private void tSzamlaTxb_Leave(object sender, EventArgs e)
        {
            if (AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, tSzamlaTxb.Text) != null)
            {
                Szamla kivalasztottSzamla = AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, tSzamlaTxb.Text);

                foreach (Szamla szamla in tSzamlaCbx.Items)
                {
                    if (szamla.Szamlaszam == kivalasztottSzamla.Szamlaszam)
                    {
                        tSzamlaCbx.SelectedItem = szamla;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("A beírt számlaszám nem létezik!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //DialogResult = DialogResult.None;
            }
        }

        private void kSzamlaTxb_Leave(object sender, EventArgs e)
        {
            if (AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, kSzamlaTxb.Text) != null)
            {
                Szamla kivalasztottSzamla = AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, kSzamlaTxb.Text);

                foreach (Szamla szamla in kSzamlaCbx.Items)
                {
                    if (szamla.Szamlaszam == kivalasztottSzamla.Szamlaszam)
                    {
                        kSzamlaCbx.SelectedItem = szamla;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("A beírt számlaszám nem létezik!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //DialogResult = DialogResult.None;
            }
        }

        private void tOsszegTxb_Leave(object sender, EventArgs e)
        {
            kOsszegTxb.Text = "";
            kOsszegTxb.Text = tOsszegTxb.Text;
        }

        private void kOsszegTxb_Leave(object sender, EventArgs e)
        {
            tOsszegTxb.Text = "";
            tOsszegTxb.Text = kOsszegTxb.Text;
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            PartnercegAdatai kivalasztottPartner = (PartnercegAdatai)partnerCbx.SelectedItem;
            KonyvelesiTetel konyvelesiTetel = new KonyvelesiTetel(
                0,
                kivalasztottPartner.Partnerkod.ToString(),
                szamlaszamTxb.Text,
                tSzamlaTxb.Text,
                kSzamlaTxb.Text,
                Convert.ToDouble(tOsszegTxb.Text),
                Convert.ToDouble(kOsszegTxb.Text),
                gazdasagiEsemenyTxb.Text,
                (FizetesiMod)fizetesiModCbx.SelectedItem,
                Convert.ToDouble(afakulcsCbx.SelectedItem),
                teljesitesDtp.Value,
                afaTeljesitesDtp.Value,
                szamlaKelteDtp.Value,
                esedekessegDtp.Value,
                DateTime.Now,
                BejelentkezesFrm.Felhasznalo.Felhasznalonev
                );

            AdatbazisMuveletek.Insertek.UjSzallitoTetelFelvitele(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, konyvelesiTetel);

            MessageBox.Show("A könyvelés sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tSzamlaTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void kSzamlaTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void tOsszegTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void kOsszegTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
