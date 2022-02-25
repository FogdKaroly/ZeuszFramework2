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
    public partial class OsszesKtsgFrm : Form
    {
        public OsszesKtsgFrm(int ev)
        {
            InitializeComponent();
            Megjelenites(ev);
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Megjelenites(int ev)
        {
            List<Lekerdezesek.KoltsegEgyenleg> egyenlegek = AdatbazisMuveletek.Lekerdezesek.OsszesKoltsegLekerese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev);

            osszesKtsgChrt.DataSource = egyenlegek;
            osszesKtsgChrt.Series["OsszesKtsg"].XValueMember = "FokonyviSzam";
            osszesKtsgChrt.Series["OsszesKtsg"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            osszesKtsgChrt.Series["OsszesKtsg"].YValueMembers = "Egyenleg";
            osszesKtsgChrt.Series["OsszesKtsg"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            osszesKtsgChrt.Series["OsszesKtsg"].IsValueShownAsLabel = true;
        }   
    }
}
