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
    public partial class JogosultsagKezelesFrm : Form
    {
        List<Felhasznalo> felhasznalok = AdatbazisMuveletek.Lekerdezesek.FelhasznaloLekerdezes();
        

        public JogosultsagKezelesFrm()
        {
            InitializeComponent();
            foreach (var felhasznalo in felhasznalok)
            {
                felhasznaloCbx.Items.Add(felhasznalo.Felhasznalonev.ToString());
            }
        }

        private void felhasznaloCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            jogosultsagokDgv.Rows.Clear();
            Dictionary<string, byte> jogosultsagok = AdatbazisMuveletek.Lekerdezesek.JogosultsagLekerdezesNevvel(felhasznaloCbx.SelectedItem.ToString());
            foreach (var jog in jogosultsagok)
            {
                jogosultsagokDgv.Rows.Add(
                    new object[]
                    {
                        jog.Key.ToString(),
                        jog.Value.ToString()
                    });
            }
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            bool sikeres = false;

            foreach (DataGridViewRow sor in jogosultsagokDgv.Rows)
            {
                if (Convert.ToByte(sor.Cells["jogosultsag"].Value) > 1 || Convert.ToByte(sor.Cells["jogosultsag"].Value) < 0)
                {
                    MessageBox.Show("A jogosultság mező értéke 0, vagy 1 lehet, a feltöltés sikertelen", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    sikeres = false;
                    return;
                }
                else
                {
                    AdatbazisMuveletek.Insertek.JogosultsagFeltoltes(felhasznaloCbx.SelectedItem.ToString(), sor.Cells["menupont_neve"].Value.ToString(), Convert.ToByte(sor.Cells["jogosultsag"].Value));
                    sikeres = true;
                }
            }
            if (sikeres)
            {
                MessageBox.Show("A jogosultságok feltöltése sikeres!\n A módosítások életbe lépéséhez újra kell indítani a programot!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1.megnyitasFoablakban(new KezdokepernyoFrm());
            }
        }
    }
}
