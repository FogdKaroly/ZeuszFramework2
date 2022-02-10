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
        public OsszesKtsgFrm()
        {
            InitializeComponent();
            Megjelenites();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Megjelenites()
        {
            List<Konyveles.KonyvelesiTetel> tetelek = AdatbazisMuveletek.Lekerdezesek.OsszesKoltsegLekerese(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            BindingList<Lekerdezesek.KoltsegEgyenleg> egyenlegek = new BindingList<KoltsegEgyenleg>();

            foreach (var tetel in tetelek)
            {
                egyenlegek.Add(new KoltsegEgyenleg(tetel.TSzamla, tetel.TOsszeg - tetel.KOsszeg));
            }
            
        }   
    }
}
