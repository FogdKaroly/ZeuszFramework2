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
    public partial class PartenrtorzsFrm : Form
    {
        SqlConnection connection;
        //List<PartnercegAdatai> partnerek;

        public PartenrtorzsFrm()
        {
            InitializeComponent();
            PartnerekLekerdezese();
            szallitasiKozteruletJellegCbx.DataSource = Enum.GetValues(typeof(KozteruletJellege));
            szamlazasiKozteruletJellegCbx.DataSource = Enum.GetValues(typeof(KozteruletJellege));
            partnerkodLbl.Text = "0";
            partnerkodLbl.Visible = false;

        }

        private void PartnerekLekerdezese()
        {
            List<string> partnerNevek = new List<string>();
            string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();
            string nevekLekerese = $"SELECT partnerkod, cegnev FROM {schema}.partnertorzs ORDER BY cegnev";

            try
            {
                SqlCommand cmd = new SqlCommand(nevekLekerese, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    partnerNevek.Add(reader[1].ToString() + " (" + reader[0].ToString() + ")");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Nem sikerült a partnerek lekérdezése! -> " + ex.Message);
            }
            connection.Close();

            foreach (var partner in partnerNevek)
            {
                cegvalasztoCbx.Items.Add(partner);
            }
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void szamlazasiIranyitoszamTxb_Leave(object sender, EventArgs e)
        {
            szamlazasiVarosTxb.Text = "";
            szamlazasiVarosTxb.Text = AdatbazisMuveletek.Lekerdezesek.VarosLekeres(szamlazasiIranyitoszamTxb.Text);
        }

        private void szallitasiIranyitoszamTxb_Leave(object sender, EventArgs e)
        {
            szallitasiVarosTxb.Text = "";
            szallitasiVarosTxb.Text = AdatbazisMuveletek.Lekerdezesek.VarosLekeres(szallitasiIranyitoszamTxb.Text);
        }

        private void cegvalasztoCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ptkod = "";
            
            for (int i = 0; i < cegvalasztoCbx.Text.Length; i++)
            {
                if (cegvalasztoCbx.Text[i] == 40)
                {
                    if (cegvalasztoCbx.Text[i + 1] >= 48 && cegvalasztoCbx.Text[i + 1] <= 57 )
                    {
                        ptkod += cegvalasztoCbx.Text[i + 1];
                    }
                }
            }

            List<PartnercegAdatai> partnerek = AdatbazisMuveletek.Lekerdezesek.PartnerLekerdezes(Convert.ToInt32(ptkod));

            foreach (var partner in partnerek)
            {
                partnerkodLbl.Text = partner.Partnerkod.ToString();
                cegnevTxb.Text = partner.RovidCegnev;
                szamlazasiNevTxb.Text = partner.SzamlazasiNev;
                szamlazasiIranyitoszamTxb.Text = partner.Iranyitoszam;
                szamlazasiVarosTxb.Text = partner.Varos;
                szamlazasiKozteruletNeveTxb.Text = partner.KozteruletNeve;
                szamlazasiKozteruletJellegCbx.SelectedItem = partner.KozteruletJellege;
                szamlazasiHazszamTxb.Text = partner.Hazszam;
                szamlazasiLepcsohazTxb.Text = partner.Lepcsohaz;
                szamlazasiAjtoTxb.Text = partner.Ajto;
                szallitasiIranyitoszamTxb.Text = partner.SzallitasiIranyitoszam;
                szallitasiVarosTxb.Text = partner.SzallitasiVaros;
                szallitasiKozteruletNeveTxb.Text = partner.SzallitasiKozteruletNeve;
                szallitasiKozteruletJellegCbx.SelectedItem = partner.SzallitasiKozteruletJellege;
                szallitasiHazszamTxb.Text = partner.SzallitasiHazszam;
                szallitasiLepcsohazTxb.Text = partner.SzallitasiLepcsohaz;
                szallitasiAjtoTxb.Text = partner.SzallitasiAjto;
                adoszamTxb.Text = partner.Adoszam;
                euAdoszamTxb.Text = partner.EuAdoszam;
                cegjegyzekszamTxb.Text = partner.Cegjegyzekszam;
                bankszamlaszamTxb.Text = partner.Bankszamlaszam;
                emailTxb.Text = partner.Email;
                telefonTxb.Text = partner.Telefon; 
            }
        }

        private void szamlazasiAdatMasolBtn_Click(object sender, EventArgs e)
        {
            szallitasiIranyitoszamTxb.Text = "";
            szallitasiIranyitoszamTxb.Text = szamlazasiIranyitoszamTxb.Text;
            szallitasiVarosTxb.Text = "";
            szallitasiVarosTxb.Text = szamlazasiVarosTxb.Text;
            szallitasiKozteruletNeveTxb.Text = "";
            szallitasiKozteruletNeveTxb.Text = szamlazasiKozteruletNeveTxb.Text;
            szallitasiKozteruletJellegCbx.SelectedItem = szamlazasiKozteruletJellegCbx.SelectedItem;
            szallitasiHazszamTxb.Text = "";
            szallitasiHazszamTxb.Text = szamlazasiHazszamTxb.Text;
            szallitasiLepcsohazTxb.Text = "";
            szallitasiLepcsohazTxb.Text = szamlazasiLepcsohazTxb.Text;
            szallitasiAjtoTxb.Text = "";
            szallitasiAjtoTxb.Text = szamlazasiAjtoTxb.Text;
        }

        private void rogzitesUjkentBtn_Click(object sender, EventArgs e)
        {
            PartnercegAdatai partnercegAdatai = new PartnercegAdatai(
                    Convert.ToInt32(partnerkodLbl.Text),
                    szamlazasiNevTxb.Text,
                    szallitasiIranyitoszamTxb.Text,
                    szallitasiVarosTxb.Text,
                    szallitasiKozteruletNeveTxb.Text,
                    szallitasiHazszamTxb.Text,
                    szallitasiLepcsohazTxb.Text,
                    szallitasiAjtoTxb.Text,
                    (KozteruletJellege)szallitasiKozteruletJellegCbx.SelectedItem,
                    cegnevTxb.Text,
                    szamlazasiIranyitoszamTxb.Text,
                    szamlazasiVarosTxb.Text,
                    szamlazasiKozteruletNeveTxb.Text,
                    (KozteruletJellege)szamlazasiKozteruletJellegCbx.SelectedItem,
                    szamlazasiHazszamTxb.Text,
                    szamlazasiLepcsohazTxb.Text,
                    szamlazasiAjtoTxb.Text,
                    adoszamTxb.Text,
                    euAdoszamTxb.Text,
                    cegjegyzekszamTxb.Text,
                    bankszamlaszamTxb.Text,
                    emailTxb.Text,
                    telefonTxb.Text
                );
            AdatbazisMuveletek.Insertek.UjPartner(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, partnercegAdatai);

            MessageBox.Show("A partner feltöltése sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void rogzitesBtn_Click(object sender, EventArgs e)
        {
            PartnercegAdatai partnercegAdatai = new PartnercegAdatai(
                    Convert.ToInt32(partnerkodLbl.Text),
                    szamlazasiNevTxb.Text,
                    szallitasiIranyitoszamTxb.Text,
                    szallitasiVarosTxb.Text,
                    szallitasiKozteruletNeveTxb.Text,
                    szallitasiHazszamTxb.Text,
                    szallitasiLepcsohazTxb.Text,
                    szallitasiAjtoTxb.Text,
                    (KozteruletJellege)szallitasiKozteruletJellegCbx.SelectedItem,
                    cegnevTxb.Text,
                    szamlazasiIranyitoszamTxb.Text,
                    szamlazasiVarosTxb.Text,
                    szamlazasiKozteruletNeveTxb.Text,
                    (KozteruletJellege)szamlazasiKozteruletJellegCbx.SelectedItem,
                    szamlazasiHazszamTxb.Text,
                    szamlazasiLepcsohazTxb.Text,
                    szamlazasiAjtoTxb.Text,
                    adoszamTxb.Text,
                    euAdoszamTxb.Text,
                    cegjegyzekszamTxb.Text,
                    bankszamlaszamTxb.Text,
                    emailTxb.Text,
                    telefonTxb.Text
                );
            AdatbazisMuveletek.Insertek.PartnerModositas(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, partnercegAdatai);

            MessageBox.Show("A partner módosítása sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
