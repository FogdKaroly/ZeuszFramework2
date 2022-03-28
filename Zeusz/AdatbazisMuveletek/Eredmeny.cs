using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.AdatbazisMuveletek
{
    internal static class Eredmeny
    {
        static SqlConnection connection;
        static string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;
        //string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) - 1).ToString());

        // Összköltség típus
        public static int EAI01(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString());
            string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString());

            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAI01(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); 
            string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString());

            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAI02(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI02') AND (({schema}.fokonyv.Tszamla <> '493') OR ({schema}.fokonyv.Kszamla <> '493'))";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI02') AND (({schema}.fokonyv.Tszamla <> '493') OR ({schema}.fokonyv.Kszamla <> '493'))";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAI02(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI02') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI02') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAII03(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAII03(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAII04(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII04')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII04')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAII04(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII04')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII04')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIII')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIII')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIV05(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIV05(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIV06(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV06')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV06')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIV06(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV06')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV06')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIV07(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV07')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV07')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIV07(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV07')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV07')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIV08(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV08')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV08')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIV08(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV08')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV08')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIV09(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV09')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV09')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIV09(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV09')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV09')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAIV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAIV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAV10(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAV10(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAV11(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV11')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV11')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAV11(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV11')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV11')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAV12(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV12')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV12')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAV12(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV12')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV12')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAVI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVI')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVI')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAVI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVI')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVI')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EAVII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVII')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEAVII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EA(int ev)
        {
            int egyenleg = EAI(ev) + EAII(ev) + EAIII(ev) -EAIV(ev) - EAV(ev) - EAVI(ev) - EAVII(ev);

            /*
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02', 'EAII03', 'EAII04', 'EAIII', 'EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09', 'EAV10', 'EAV11', 'EAV12', 'EAVI', 'EAVII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02', 'EAII03', 'EAII04', 'EAIII', 'EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09', 'EAV10', 'EAV11', 'EAV12', 'EAVI', 'EAVII')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();
            */
            return egyenleg;
        }

        public static int ElozoEA(int ev)
        {
            int egyenleg = ElozoEAI(ev) + ElozoEAII(ev) + ElozoEAIII(ev) - ElozoEAIV(ev) - ElozoEAV(ev) - ElozoEAVI(ev) - ElozoEAVII(ev);
            /*
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();
            */
            return egyenleg;
        }

        // Forgalmi költség típus
        public static int EFAII03(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII03')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII03')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAII03(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII03')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII03')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAII04(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII04')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII04')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAII04(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII04')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII04')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAII05(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII05')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII05')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAII05(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII05')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII05')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAII(int ev)
        {
            int egyenleg = EFAII03(ev) + EFAII04(ev) + EFAII05(ev);
            
            return egyenleg;
        }

        public static int ElozoEFAII(int ev)
        {
            int egyenleg = ElozoEFAII03(ev) + ElozoEFAII04(ev) + ElozoEFAII05(ev);
            
            return egyenleg;
        }

        public static int EFAIII(int ev)
        {
            int egyenleg = EAI(ev) + EFAII(ev);

            return egyenleg;
        }

        public static int ElozoEFAIII(int ev)
        {
            int egyenleg = ElozoEAI(ev) + ElozoEFAII(ev);

            return egyenleg;
        }

        public static int EFAIV06(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV06')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV06')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAIV06(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV06')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV06')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAIV07(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV07')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV07')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAIV07(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV07')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV07')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAIV08(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV08')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV08')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAIV08(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV08')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV08')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAIV(int ev)
        {
            int egyenleg = EAIV06(ev) + EFAIV07(ev) + EFAIV08(ev);

            return egyenleg;
        }

        public static int ElozoEFAIV(int ev)
        {
            int egyenleg = ElozoEAIV06(ev) + ElozoEFAIV07(ev) + ElozoEFAIV08(ev);

            return egyenleg;
        }

        public static int EFAV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAV')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAV')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAV')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAV')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFAVI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAVI')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAVI')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEFAVI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAVI')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAVI')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EFA(int ev)
        {
            int egyenleg = EAI(ev) + EAII(ev) + EAIII(ev) - EAIV(ev) + EAV(ev) - EAVI(ev);

            return egyenleg;
        }

        public static int ElozoEFA(int ev)
        {
            int egyenleg = ElozoEAI(ev) + ElozoEAII(ev) + ElozoEAIII(ev) - ElozoEAIV(ev) + ElozoEAV(ev) - ElozoEAVI(ev);

            return egyenleg;
        }

        // Közös eredmény sorok
        public static int EBVIII13(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII13')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII13')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBVIII13(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII13')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII13')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBVIII14(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII14')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII14')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBVIII14(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII14')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII14')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBVIII15(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII15')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII15')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBVIII15(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII15')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII15')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBVIII16(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII16')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII16')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBVIII16(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII16')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII16')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBVIII17(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII17')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII17')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBVIII17(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII17')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII17')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg -= Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg += Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBVIII(int ev)
        {
            int egyenleg = EBVIII13(ev) + EBVIII14(ev) + EBVIII15(ev)+ EBVIII16(ev) + EBVIII17(ev);

            return egyenleg;
        }

        public static int ElozoEBVIII(int ev)
        {
            int egyenleg = ElozoEBVIII13(ev) + ElozoEBVIII14(ev) + ElozoEBVIII15(ev) + ElozoEBVIII16(ev) + ElozoEBVIII17(ev);

            return egyenleg;
        }

        public static int EBIX18(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX18')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX18')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBIX18(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX18')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX18')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBIX19(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX19')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX19')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBIX19(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX19')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX19')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBIX20(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX20')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX20')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBIX20(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX20')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX20')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBIX21(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX21')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX21')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBIX21(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX21')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX21')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBIX22(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX22')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX22')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEBIX22(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX22')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX22')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int EBIX(int ev)
        {
            int egyenleg = EBIX18(ev) + EBIX19(ev) + EBIX20(ev) + EBIX21(ev) + EBIX22(ev);

            return egyenleg;
        }

        public static int ElozoEBIX(int ev)
        {
            int egyenleg = ElozoEBIX18(ev) + ElozoEBIX19(ev) + ElozoEBIX20(ev) + ElozoEBIX21(ev) + ElozoEBIX22(ev);

            return egyenleg;
        }

        public static int EB(int ev)
        {
            int egyenleg = EBVIII(ev) - EBIX(ev);

            return egyenleg;
        }

        public static int ElozoEB(int ev)
        {
            int egyenleg = ElozoEBVIII(ev) - ElozoEBIX(ev);

            return egyenleg;
        }

        public static int EC(int ev)
        {
            int egyenleg = EA(ev) + EB(ev);

            return egyenleg;
        }

        public static int ElozoEC(int ev)
        {
            int egyenleg = ElozoEA(ev) + ElozoEB(ev);

            return egyenleg;
        }

        public static int EDX(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EDX')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE YEAR({schema}.fokonyv.teljesites) = {ev} AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EDX')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoEDX(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EDX')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EDX')";

            try
            {
                SqlCommand command = new SqlCommand(Toldal, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    egyenleg += Convert.ToInt32(reader["fokonyv_t"]);
                }

                reader.Close();

                command.Parameters.Clear();
                command.CommandText = Koldal;

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    egyenleg -= Convert.ToInt32(reader1["fokonyv_k"]);
                }

                reader1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ED(int ev)
        {
            int egyenleg = EC(ev) - EDX(ev);

            return egyenleg;
        }

        public static int ElozoED(int ev)
        {
            int egyenleg = ElozoEC(ev) - ElozoEDX(ev);

            return egyenleg;
        }
    }
}
