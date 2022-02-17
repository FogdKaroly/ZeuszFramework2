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
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void osszesKtsgBtn_Click(object sender, EventArgs e)
        {
            OsszesKtsgFrm osszesKtsgFrm = new OsszesKtsgFrm();
            osszesKtsgFrm.ShowDialog();
        }

        private void mutatoszamokBtn_Click(object sender, EventArgs e)
        {
            MutatoszamokFrm mutatoszamokFrm = new MutatoszamokFrm();
            mutatoszamokFrm.ShowDialog();
        }

        private void egyeniLekerdezes_Click(object sender, EventArgs e)
        {
            EgyeniLekerdezesFrm egyeniLekerdezesFrm = new EgyeniLekerdezesFrm();
            egyeniLekerdezesFrm.ShowDialog();
        }

        private void bevetelKtsgAranyBtn_Click(object sender, EventArgs e)
        {
            BevetelKtsgAranyFrm bevetelKtsgAranyFrm = new BevetelKtsgAranyFrm();
            bevetelKtsgAranyFrm.ShowDialog();
        }
    }
}
