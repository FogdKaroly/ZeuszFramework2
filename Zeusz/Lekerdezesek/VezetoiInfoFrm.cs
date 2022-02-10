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

        private void osszesKtsgBtn_Click(object sender, EventArgs e)
        {
            OsszesKtsgFrm osszesKtsgFrm = new OsszesKtsgFrm();
            osszesKtsgFrm.ShowDialog();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
