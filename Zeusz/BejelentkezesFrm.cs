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
    public partial class BejelentkezesFrm : Form
    {
        SqlConnection connection;

        static Jogosultsag felhasznalo;
        internal static Jogosultsag Felhasznalo { get => felhasznalo; /*set => felhasznalo = value;*/ }

        public BejelentkezesFrm()
        {
            InitializeComponent();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();

            datumLbl.Text = DateTime.Now.ToShortDateString();

            connection.Open();

            // A ComboBox feltöltése:
            string query = "SELECT * FROM felhasznalok";

            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    felhasznaloCbx.Items.Add($"{reader["felhasznalonev"]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Felhasználó lekérdezés hiba (ComboBox) -> " + ex.Message);
            }

            connection.Close();
        }

        private void bejelentkezesBtn_Click(object sender, EventArgs e)
        {
            if (AdatbazisMuveletek.Lekerdezesek.Belepes(felhasznaloCbx.SelectedItem.ToString(), jelszoTxb.Text))
            {
                felhasznalo = new Jogosultsag(felhasznaloCbx.SelectedItem.ToString(), AdatbazisMuveletek.Lekerdezesek.JogosultsagLekerdezes(felhasznaloCbx.SelectedItem.ToString()));
                CegvalasztoFrm cegvalasztoFrm = new CegvalasztoFrm();
                if (cegvalasztoFrm.ShowDialog() == DialogResult.OK)
                {
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
                //jelszoTxb.Text = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
