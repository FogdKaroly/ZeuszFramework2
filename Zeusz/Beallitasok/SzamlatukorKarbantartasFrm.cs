using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Beallitasok
{
    public partial class SzamlatukorKarbantartasFrm : Form
    {
        Konyveles.Szamla szamla;
        List<Konyveles.Szamla> szamlak = AdatbazisMuveletek.Lekerdezesek.OsszesSzamlaLekerese();
        List<Beallitasok.BeszamoloSor> beszamoloSorok = AdatbazisMuveletek.Lekerdezesek.BeszámolSorokLekerese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
     
        public SzamlatukorKarbantartasFrm()
        {
            InitializeComponent();
            szamlaKivalasztasCbx.DataSource = szamlak;
            helyeABeszamolobanCbx.DataSource = beszamoloSorok;
            /*
            foreach (var sor in beszamoloSorok)
            {
                helyeABeszamolobanCbx.Items.Add(sor);
            }
            */
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void szamlaKivalasztasCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Konyveles.Szamla kivalasztottSzamla = (Konyveles.Szamla)szamlaKivalasztasCbx.SelectedItem;
            szamlaszamTxb.Text = kivalasztottSzamla.Szamlaszam;
            szamlaNevTxb.Text = kivalasztottSzamla.SzamlaNeve;
            kapcsolodikIdeTxb.Text = kivalasztottSzamla.KapcsolodikIde;
            konyvelhetoEChbx.Checked = kivalasztottSzamla.Konyvelheto;
            foreach (var sor in beszamoloSorok)
            {
                if (sor.Sorszam == kivalasztottSzamla.HelyeABeszamoloban)
                {
                    helyeABeszamolobanCbx.SelectedItem = sor;
                }
                else if (kivalasztottSzamla.HelyeABeszamoloban == "")
                {
                    helyeABeszamolobanCbx.SelectedItem = "";
                }
            }
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            Beallitasok.BeszamoloSor beszamoloSor = (Beallitasok.BeszamoloSor)helyeABeszamolobanCbx.SelectedItem;

            szamla = new Konyveles.Szamla(szamlaszamTxb.Text, szamlaNevTxb.Text, kapcsolodikIdeTxb.Text, konyvelhetoEChbx.Checked, beszamoloSor.Sorszam);
            AdatbazisMuveletek.Insertek.SzamlatukorModositas(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, szamla);

            MessageBox.Show("A számla módosítása sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void rogzitesUjkentBtn_Click(object sender, EventArgs e)
        {
            Beallitasok.BeszamoloSor beszamoloSor = (Beallitasok.BeszamoloSor)helyeABeszamolobanCbx.SelectedItem;

            szamla = new Konyveles.Szamla(szamlaszamTxb.Text, szamlaNevTxb.Text, kapcsolodikIdeTxb.Text, konyvelhetoEChbx.Checked, beszamoloSor.Sorszam);
            AdatbazisMuveletek.Insertek.UjSzamlaFelvitele(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, szamla);

            MessageBox.Show("A számla létrehozása sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void szamlaszamTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
