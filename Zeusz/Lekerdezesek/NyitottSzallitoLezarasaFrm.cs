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
    public partial class NyitottSzallitoLezarasaFrm : Form
    {
        Konyveles.KonyvelesiTetel nyitottSzallito;
        internal Konyveles.KonyvelesiTetel NyitottSzallito { get => nyitottSzallito; set => nyitottSzallito = value; }

        internal NyitottSzallitoLezarasaFrm(Konyveles.KonyvelesiTetel konyvelesiTetel)
        {
            InitializeComponent();
            kSzamlaCbx.DataSource = AdatbazisMuveletek.Lekerdezesek.SzamlakLekerese();
            partnerNeveLbl.Text = AdatbazisMuveletek.Lekerdezesek.PartnerNevLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, konyvelesiTetel.Partnerkod);
            szamlaszamLbl.Text = konyvelesiTetel.Szamlaszam;
            tartozikSzamlaLbl.Text = konyvelesiTetel.KSzamla;
            tartozikOsszegLbl.Text = AdatbazisMuveletek.Lekerdezesek.NyitottOsszegLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, konyvelesiTetel.Id).ToString();
            gazdasagiEsemenyLbl.Text = konyvelesiTetel.Gazdasagi_esemeny;
            idLbl.Text = konyvelesiTetel.Id.ToString();
            partnerkodLbl.Text = konyvelesiTetel.Partnerkod;
            teljesitesDtp.Value = konyvelesiTetel.Teljesites;
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kSzamlaTxb_Leave(object sender, EventArgs e)
        {
            if (AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, kSzamlaTxb.Text) != null)
            {
                Konyveles.Szamla kivalasztottSzamla = AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, kSzamlaTxb.Text);

                foreach (Konyveles.Szamla szamla in kSzamlaCbx.Items)
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

        private void kSzamlaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Konyveles.Szamla kivalasztottTSzamla = (Konyveles.Szamla)kSzamlaCbx.SelectedItem;
            kSzamlaTxb.Text = kivalasztottTSzamla.Szamlaszam;
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            nyitottSzallito = new Konyveles.KonyvelesiTetel(
                    Convert.ToInt32(idLbl.Text),
                    partnerkodLbl.Text,
                    szamlaszamLbl.Text,
                    tartozikSzamlaLbl.Text,
                    kSzamlaTxb.Text,
                    Convert.ToDouble(tartozikOsszegLbl.Text),
                    Convert.ToDouble(tartozikOsszegLbl.Text),
                    szamlaszamLbl.Text + " kiegyenlítése",
                    teljesitesDtp.Value,
                    DateTime.Now,
                    BejelentkezesFrm.Felhasznalo.Felhasznalonev
                );
            AdatbazisMuveletek.Insertek.NyitottSzallitoLezaras(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, nyitottSzallito);

            MessageBox.Show("A tétel lezárása sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void kSzamlaTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
