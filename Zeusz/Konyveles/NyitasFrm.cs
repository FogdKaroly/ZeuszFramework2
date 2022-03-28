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
    public partial class NyitasFrm : Form
    {
        public NyitasFrm()
        {
            InitializeComponent();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void nyitasBtn_Click(object sender, EventArgs e)
        {
            AdatbazisMuveletek.Insertek.Nyitas(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            AdatbazisMuveletek.Insertek.AfaRendezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            MessageBox.Show("A nyitás sikeresen megtörtént!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
