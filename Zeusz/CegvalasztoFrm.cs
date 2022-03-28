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
    public partial class CegvalasztoFrm : Form
    {
        SqlConnection connection;

        List<string> cegek;

        public CegvalasztoFrm()
        {
            InitializeComponent();
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            cegek = new List<string>();

            connection.Open();

            string query = "SELECT name FROM sys.schemas WHERE principal_id = 1 and name <> 'dbo' ORDER BY name desc";
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cegek.Add(reader[0].ToString());
                }
                reader.Close();
                foreach (var ceg in cegek)
                {
                    cegekCbx.Items.Add(ceg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a cégek lekérdezésénél -> " + ex.Message);
            }

            connection.Close();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kivalasztBtn_Click(object sender, EventArgs e)
        {
            if (cegekCbx.SelectedIndex != -1)
            {
                AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis = cegekCbx.SelectedItem.ToString();

                this.Close();
            }
            else
            {
                MessageBox.Show("Válasszon ki egy céget!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
