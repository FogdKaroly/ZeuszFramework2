using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz
{
    public partial class FelhasznalokKezeleseFrm : Form
    {
        //SqlConnection connection;
        List<Felhasznalo> felhasznalok;

        public FelhasznalokKezeleseFrm()
        {
            InitializeComponent();
            felhasznalok = AdatbazisMuveletek.Lekerdezesek.FelhasznaloLekerdezes();
            foreach (Felhasznalo felhasznalo in felhasznalok)
            {
                felhasznalokCbx.Items.Add(felhasznalo.Felhasznalonev);
            }
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void felhasznalokCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Felhasznalo felhasznalo in felhasznalok)
            {
                if (felhasznalo.Felhasznalonev.Equals(felhasznalokCbx.SelectedItem))
                {
                    felhasznalonevTxb.Text = felhasznalo.Felhasznalonev;
                    jelszoTxb.Text = "********";
                    beosztasTxb.Text = felhasznalo.Beosztas;
                    emailTxb.Text = felhasznalo.Email;
                }
            }
        }

        private void rogzitesUjkentBtn_Click(object sender, EventArgs e)
        {
            Felhasznalo felhasznalo = new Felhasznalo(felhasznalonevTxb.Text, AdatbazisMuveletek.Lekerdezesek.JelszoTitkositas(jelszoTxb.Text), beosztasTxb.Text, emailTxb.Text);
            AdatbazisMuveletek.Insertek.UjFelhasznalo(felhasznalo);
            MessageBox.Show("Sikeres feltöltés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void modositasBtn_Click(object sender, EventArgs e)
        {
            Felhasznalo felhasznalo = new Felhasznalo(felhasznalokCbx.SelectedItem.ToString(), AdatbazisMuveletek.Lekerdezesek.JelszoTitkositas(jelszoTxb.Text), beosztasTxb.Text, emailTxb.Text);

            AdatbazisMuveletek.Insertek.FelhasznaloModositas(felhasznalo);

            MessageBox.Show("A felhasználó módosítása sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
