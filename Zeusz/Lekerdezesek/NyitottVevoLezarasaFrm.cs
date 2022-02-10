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
    public partial class NyitottVevoLezarasaFrm : Form
    {
        Konyveles.KonyvelesiTetel nyitottVevo;
        internal Konyveles.KonyvelesiTetel NyitottVevo { get => nyitottVevo; set => nyitottVevo = value; }

        internal NyitottVevoLezarasaFrm(Konyveles.KonyvelesiTetel konyvelesiTetel)
        {
            InitializeComponent();
            tSzamlaCbx.DataSource = AdatbazisMuveletek.Lekerdezesek.SzamlakLekerese();
            partnerNeveLbl.Text = AdatbazisMuveletek.Lekerdezesek.PartnerNevLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, konyvelesiTetel.Partnerkod);
            szamlaszamLbl.Text = konyvelesiTetel.Szamlaszam;
            kovetelSzamlaLbl.Text = konyvelesiTetel.TSzamla;
            kovetelOsszegLbl.Text = AdatbazisMuveletek.Lekerdezesek.NyitottOsszegLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, konyvelesiTetel.Id).ToString();
            gazdasagiEsemenyLbl.Text = konyvelesiTetel.Gazdasagi_esemeny;
            idLbl.Text = konyvelesiTetel.Id.ToString();
            partnerkodLbl.Text = konyvelesiTetel.Partnerkod;
            teljesitesDtp.Value = konyvelesiTetel.Teljesites;

        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSzamlaTxb_Leave(object sender, EventArgs e)
        {
            if (AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, tSzamlaTxb.Text) != null)
            {
                Konyveles.Szamla kivalasztottSzamla = AdatbazisMuveletek.Lekerdezesek.EgySzamla(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, tSzamlaTxb.Text);

                foreach (Konyveles.Szamla szamla in tSzamlaCbx.Items)
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

        private void tSzamlaCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Konyveles.Szamla kivalasztottTSzamla = (Konyveles.Szamla)tSzamlaCbx.SelectedItem;
            tSzamlaTxb.Text = kivalasztottTSzamla.Szamlaszam;
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            nyitottVevo = new Konyveles.KonyvelesiTetel(
                    Convert.ToInt32(idLbl.Text),
                    partnerkodLbl.Text,
                    szamlaszamLbl.Text,
                    tSzamlaTxb.Text,
                    kovetelSzamlaLbl.Text,
                    Convert.ToDouble(kovetelOsszegLbl.Text),
                    Convert.ToDouble(kovetelOsszegLbl.Text),
                    szamlaszamLbl.Text + " kiegyenlítése",
                    teljesitesDtp.Value,
                    DateTime.Now,
                    BejelentkezesFrm.Felhasznalo.Felhasznalonev
                );
            AdatbazisMuveletek.Insertek.NyitottVevoLezaras(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, nyitottVevo);

            MessageBox.Show("A tétel lezárása sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void tSzamlaTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
