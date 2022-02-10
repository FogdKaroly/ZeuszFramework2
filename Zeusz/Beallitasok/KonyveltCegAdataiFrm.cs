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
    public partial class KonyveltCegAdataiFrm : Form
    {
        SqlConnection connection;
        List<KonyveltCegAdatai> konyveltcegAdatok;

        public KonyveltCegAdataiFrm()
        {
            InitializeComponent();
            SchemaLekerdezes();
            kozteruletJellegeCbx.DataSource = Enum.GetValues(typeof(KozteruletJellege));
        }

        private void SchemaLekerdezes()
        {
            List<string> schemak = new List<string>();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();

            connection.Open();

            string query = "SELECT name FROM sys.schemas WHERE principal_id = 1 and name <> 'dbo'";
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    schemak.Add(reader[0].ToString());
                }
                reader.Close();
                foreach (var ceg in schemak)
                {
                    cegvalasztoCbx.Items.Add(ceg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a cégek lekérdezésénél -> " + ex.Message);
            }

            connection.Close();
        }

        private void cegvalasztoCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            Ceglekeres();
        }

        private void Ceglekeres()
        {
            konyveltcegAdatok = AdatbazisMuveletek.Lekerdezesek.KönyveltcegAdataiLekerdezes(cegvalasztoCbx.SelectedItem.ToString());

            if (konyveltcegAdatok.Count > 0)
            {
                foreach (KonyveltCegAdatai adat in konyveltcegAdatok)
                {
                    teljesCegnevTxb.Text = adat.Cegnev;
                    rovidCegnevTxb.Text = adat.RovidCegnev;
                    iranyitoszamTxb.Text = adat.Iranyitoszam;
                    varosTxb.Text = adat.Varos;
                    kozteruletNeveTbx.Text = adat.KozteruletNeve;
                    kozteruletJellegeCbx.SelectedItem = adat.KozteruletJellege;
                    hazszamTxb.Text = adat.Hazszam;
                    lepcsohazTxb.Text = adat.Lepcsohaz;
                    ajtoTxb.Text = adat.Ajto;
                    adoszamTxb.Text = adat.Adoszam;
                    euAdoszamtxb.Text = adat.EuAdoszam;
                    cegjegyzekszamTxb.Text = adat.Cegjegyzekszam;
                    bankszamlaszam1Txb.Text = adat.Bankszamlaszam;
                    bankszamlaszam2Txb.Text = adat.Bankszamlaszam2;
                    bankszamlaszam3Txb.Text = adat.Bankszamlaszam3;
                    emailTxb.Text = adat.Email;
                    telefonTxb.Text = adat.Telefon;
                    osszktsgCbx.Checked = adat.Osszkoltseg;
                    forgalmiktsgCbx.Checked = adat.Forgalmikoltseg;
                }
            }
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modositasBtn_Click(object sender, EventArgs e)
        {
            KonyveltCegAdatai konyveltcegAdatai = new KonyveltCegAdatai(osszktsgCbx.Checked, forgalmiktsgCbx.Checked, teljesCegnevTxb.Text, bankszamlaszam2Txb.Text, bankszamlaszam3Txb.Text, rovidCegnevTxb.Text, iranyitoszamTxb.Text, varosTxb.Text, kozteruletNeveTbx.Text, (KozteruletJellege)kozteruletJellegeCbx.SelectedItem, hazszamTxb.Text, lepcsohazTxb.Text, ajtoTxb.Text, adoszamTxb.Text, euAdoszamtxb.Text, cegjegyzekszamTxb.Text, bankszamlaszam1Txb.Text, emailTxb.Text, telefonTxb.Text);

            AdatbazisMuveletek.Insertek.CegAdatFeltoltes(konyveltcegAdatai);
            this.Close();
        }

        private void rogzitesUjkentBtn_Click(object sender, EventArgs e)
        {
            string[] teljesCegnev = teljesCegnevTxb.Text.Split(' ');
            string schema = "".Trim();
            foreach (var szo in teljesCegnev)
            {
                schema += szo;
            }
            schema += ("_" + DateTime.Now.Year);

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) - 1).ToString());

            string schemaLetrehozas = $"CREATE SCHEMA {schema};";
            string elozoSchemaLetrehozas = $"CREATE SCHEMA {elozoEvSchema};";

            // Összköltség, vagy forgalmiköltség? Ha nem összköltség, akkor forgalmiköltség
            string osszktsg = osszktsgCbx.Checked ? $"INSERT INTO {schema}.szamlatukor SELECT * FROM osszkoltseg;" : $"INSERT INTO {schema}.szamlatukor SELECT * FROM forgalmikoltseg;";
            string elozoOsszktsg = osszktsgCbx.Checked ? $"INSERT INTO {elozoEvSchema}.szamlatukor SELECT * FROM osszkoltseg;" : $"INSERT INTO {elozoEvSchema}.szamlatukor SELECT * FROM forgalmikoltseg;";

            string beszamoloSorok = osszktsgCbx.Checked ? $"INSERT INTO {schema}.beszamolo_sorok SELECT * FROM osszktsg_eredmeny_sorok;" : $"INSERT INTO {schema}.beszamolo_sorok SELECT * FROM forglamiktsg_eredmeny_sorok;";

            string elozoBeszamoloSorok = osszktsgCbx.Checked ? $"INSERT INTO {elozoEvSchema}.beszamolo_sorok SELECT * FROM osszktsg_eredmeny_sorok;" : $"INSERT INTO {elozoEvSchema}.beszamolo_sorok SELECT * FROM forglamiktsg_eredmeny_sorok;";

            try
            {
                SqlCommand cegadatok = new SqlCommand(schemaLetrehozas, connection);
                cegadatok.ExecuteNonQuery();

                cegadatok.Parameters.Clear();
                cegadatok.CommandText = elozoSchemaLetrehozas;
                cegadatok.ExecuteNonQuery();

                AdatbazisMuveletek.Createek.UjKonyveltCeg(schema);

                SqlCommand koltseg = new SqlCommand(osszktsg, connection);
                koltseg.ExecuteNonQuery();

                koltseg.Parameters.Clear();
                koltseg.CommandText = elozoOsszktsg;
                koltseg.ExecuteNonQuery();

                SqlCommand beszamolo = new SqlCommand(beszamoloSorok, connection);
                beszamolo.ExecuteNonQuery();
                
                beszamolo.Parameters.Clear();
                beszamolo.CommandText = elozoBeszamoloSorok;
                beszamolo.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a schema létrehozásánál -> " + ex.Message);
            }
            connection.Close();

            KonyveltCegAdatai konyvelocegAdatai = new KonyveltCegAdatai(osszktsgCbx.Checked, forgalmiktsgCbx.Checked, teljesCegnevTxb.Text, bankszamlaszam2Txb.Text, bankszamlaszam3Txb.Text, rovidCegnevTxb.Text, iranyitoszamTxb.Text, varosTxb.Text, kozteruletNeveTbx.Text, (KozteruletJellege)kozteruletJellegeCbx.SelectedItem, hazszamTxb.Text, lepcsohazTxb.Text, ajtoTxb.Text, adoszamTxb.Text, euAdoszamtxb.Text, cegjegyzekszamTxb.Text, bankszamlaszam1Txb.Text, emailTxb.Text, telefonTxb.Text);
            
            AdatbazisMuveletek.Insertek.UjCegFeltoltes(schema, konyvelocegAdatai);
            MessageBox.Show("A feltöltés sikeres!", "Feltöltés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();


        }

        private void iranyitoszamTxb_Leave(object sender, EventArgs e)
        {
            varosTxb.Text = "";
            varosTxb.Text = AdatbazisMuveletek.Lekerdezesek.VarosLekeres(iranyitoszamTxb.Text.Trim());
        }
    }
}
