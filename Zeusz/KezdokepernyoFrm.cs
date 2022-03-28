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
        string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

        public KezdokepernyoFrm()
        {
            InitializeComponent();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            

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

        private void legutobbiTetelekDgv_DoubleClick(object sender, EventArgs e)
        {
            int kivalasztott = Convert.ToInt32(legutobbiTetelekDgv.CurrentRow.Cells[0].Value);
            string lekeres = $"SELECT * FROM {schema}.fokonyv WHERE id = {kivalasztott}";

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            SqlCommand command = new SqlCommand(lekeres, connection);
            SqlDataReader r = command.ExecuteReader();

            while (r.Read())
            {
                if (!DBNull.Value.Equals(r["nyitott_vevo"]) && DBNull.Value.Equals(r["nyitott_szallito"]))
                {
                    MessageBox.Show("Számlaszám: " + r["szamlaszam"] + "\n" +
                            "Tartozik: " + r["Tszamla"] + " - " + r["Tosszeg"] + "\n" + 
                            "Követel: " + r["Kszamla"] + " - " + r["Kosszeg"] + "\n" + 
                            r["gazdasagi_esemeny"] + "\n" + 
                            "Könyvelte: " + r["konyvelte"] + "\n" + 
                            "Teljesítés: " + r["teljesites"] + "\n" +
                            "Könyvelés dátuma: " + r["konyveles_datuma"],
                            "Vevő könyvelés"
                        );
                    //Konyveles.UjVevoKonyveleseFrm vevo = new Konyveles.UjVevoKonyveleseFrm(new Konyveles.KonyvelesiTetel(Convert.ToInt32(r["id"]), r["partnerkod"].ToString(), r["szamlaszam"].ToString(), r["Tszamla"].ToString(), r["Kszamla"].ToString(), Convert.ToDouble(r["Tosszeg"]), Convert.ToDouble(r["Kosszeg"]), r["gazdasagi_esemeny"].ToString(), (Konyveles.FizetesiMod)Enum.Parse(typeof(Konyveles.KonyvelesiTetel), r["fizetesimod"].ToString(), true), Convert.ToDouble(r["afakulcs"]), Convert.ToDateTime(r["teljesites"]), Convert.ToDateTime(r["afa_teljesites"]), Convert.ToDateTime(r["kelt"]), Convert.ToDateTime(r["esedekesseg"]), Convert.ToDateTime(r["konyveles_datuma"]), r["konyvelte"].ToString()));

                    //vevo.ShowDialog();
                }
                else if (DBNull.Value.Equals(r["nyitott_vevo"]) && !DBNull.Value.Equals(r["nyitott_szallito"]))
                {
                    MessageBox.Show("Számlaszám: " + r["szamlaszam"] + "\n" +
                            "Tartozik: " + r["Tszamla"] + " - " + r["Tosszeg"] + "\n" +
                            "Követel: " + r["Kszamla"] + " - " + r["Kosszeg"] + "\n" +
                            r["gazdasagi_esemeny"] + "\n" +
                            "Könyvelte: " + r["konyvelte"] + "\n" +
                            "Teljesítés: " + r["teljesites"] + "\n" +
                            "Könyvelés dátuma: " + r["konyveles_datuma"],
                            "Szállító könyvelés"
                        );
                }
                else
                {
                    MessageBox.Show("Számlaszám: " + r["szamlaszam"] + "\n" +
                            "Tartozik: " + r["Tszamla"] + " - " + r["Tosszeg"] + "\n" +
                            "Követel: " + r["Kszamla"] + " - " + r["Kosszeg"] + "\n" +
                            r["gazdasagi_esemeny"] + "\n" +
                            "Könyvelte: " + r["konyvelte"] + "\n" +
                            "Teljesítés: " + r["teljesites"] + "\n" +
                            "Könyvelés dátuma: " + r["konyveles_datuma"],
                            "Vegyes könyvelés"
                        );
                }
                
            }

            connection.Close();
        }
    }
}
