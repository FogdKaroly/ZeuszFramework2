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
    public partial class VezetoiInfoFrm : Form
    {
        public VezetoiInfoFrm()
        {
            InitializeComponent();
            evTxb.Text = DateTime.Now.Year.ToString();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void osszesKtsgBtn_Click(object sender, EventArgs e)
        {
            OsszesKtsgFrm osszesKtsgFrm = new OsszesKtsgFrm(Convert.ToInt32(evTxb.Text));
            osszesKtsgFrm.ShowDialog();
        }

        private void mutatoszamokBtn_Click(object sender, EventArgs e)
        {
            MutatoszamokFrm mutatoszamokFrm = new MutatoszamokFrm(Convert.ToInt32(evTxb.Text));
            mutatoszamokFrm.ShowDialog();
        }

        private void egyeniLekerdezes_Click(object sender, EventArgs e)
        {
            EgyeniLekerdezesFrm egyeniLekerdezesFrm = new EgyeniLekerdezesFrm();
            egyeniLekerdezesFrm.ShowDialog();
        }

        private void bevetelKtsgAranyBtn_Click(object sender, EventArgs e)
        {
            BevetelKtsgAranyFrm bevetelKtsgAranyFrm = new BevetelKtsgAranyFrm(Convert.ToInt32(evTxb.Text));
            bevetelKtsgAranyFrm.ShowDialog();
        }
    }
}
