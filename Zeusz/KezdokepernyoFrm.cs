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
    public partial class KezdokepernyoFrm : Form
    {
        SqlConnection connection;

        public KezdokepernyoFrm()
        {
            InitializeComponent();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            legutobbiTetelekDgv.Rows.Clear();

            connection.Open();

            string query = $"SELECT id, partnerkod, szamlaszam, Tosszeg, Kosszeg, gazdasagi_esemeny FROM {schema}.fokonyv ORDER BY konyveles_datuma DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                legutobbiTetelekDgv.Rows.Add(
                    new object[]
                    {
                        reader["id"].ToString(),
                        reader["partnerkod"].ToString(),
                        reader["szamlaszam"].ToString(),
                        reader["Tosszeg"].ToString(),
                        reader["Kosszeg"].ToString(),
                        reader["gazdasagi_esemeny"].ToString(),
                    }
                    );
            }

            reader.Close();
            connection.Close();
        }
    }
}
