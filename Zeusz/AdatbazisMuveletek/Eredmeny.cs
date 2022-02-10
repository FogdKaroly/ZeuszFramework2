using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz.AdatbazisMuveletek
{
    internal static class Eredmeny
    {
        static SqlConnection connection;
        static string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;
        static string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) - 1).ToString());

        // Összköltség típus
        public static int EAI01()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01')";

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

        public static int ElozoEAI01()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

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

        public static int EAI02()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI02') AND (({schema}.fokonyv.Tszamla <> '493') OR ({schema}.fokonyv.Kszamla <> '493'))";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI02') AND (({schema}.fokonyv.Tszamla <> '493') OR ({schema}.fokonyv.Kszamla <> '493'))";

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

        public static int ElozoEAI02()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI02') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI02') AND (({elozoEvSchema}.fokonyv.Tszamla <> '493') OR ({elozoEvSchema}.fokonyv.Kszamla <> '493'))";

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

        public static int EAI()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

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

        public static int ElozoEAI()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAI01', 'EAI02')";

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

        public static int EAII03()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03')";

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

        public static int ElozoEAII03()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03')";

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

        public static int EAII04()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII04')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII04')";

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

        public static int ElozoEAII04()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII04')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII04')";

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

        public static int EAII()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

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

        public static int ElozoEAII()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAII03', 'EAII04')";

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

        public static int EAIII()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIII')";

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

        public static int ElozoEAIII()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIII')";

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

        public static int EAIV05()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05')";

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

        public static int ElozoEAIV05()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05')";

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

        public static int EAIV06()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV06')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV06')";

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

        public static int ElozoEAIV06()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV06')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV06')";

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

        public static int EAIV07()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV07')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV07')";

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

        public static int ElozoEAIV07()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV07')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV07')";

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

        public static int EAIV08()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV08')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV08')";

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

        public static int ElozoEAIV08()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV08')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV08')";

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

        public static int EAIV09()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV09')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV09')";

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

        public static int ElozoEAIV09()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV09')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV09')";

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

        public static int EAIV()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

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

        public static int ElozoEAIV()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09')";

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

        public static int EAV10()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10')";

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

        public static int ElozoEAV10()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10')";

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

        public static int EAV11()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV11')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV11')";

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

        public static int ElozoEAV11()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV11')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV11')";

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

        public static int EAV12()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV12')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV12')";

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

        public static int ElozoEAV12()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV12')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV12')";

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

        public static int EAV()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

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

        public static int ElozoEAV()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAV10', 'EAV11', 'EAV12')";

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

        public static int EAVI()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVI')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVI')";

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

        public static int ElozoEAVI()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVI')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVI')";

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

        public static int EAVII()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAVII')";

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

        public static int ElozoEAVII()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

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

        public static int EA()
        {
            int egyenleg = EAI() + EAII() + EAIII() -EAIV() - EAV() - EAVI() - EAVII();

            /*
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02', 'EAII03', 'EAII04', 'EAIII', 'EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09', 'EAV10', 'EAV11', 'EAV12', 'EAVI', 'EAVII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EAI01', 'EAI02', 'EAII03', 'EAII04', 'EAIII', 'EAIV05', 'EAIV06', 'EAIV07', 'EAIV08', 'EAIV09', 'EAV10', 'EAV11', 'EAV12', 'EAVI', 'EAVII')";

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

        public static int ElozoEA()
        {
            int egyenleg = ElozoEAI() + ElozoEAII() + ElozoEAIII() - ElozoEAIV() - ElozoEAV() - ElozoEAVI() - ElozoEAVII();
            /*
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EAVII')";

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
        public static int EFAII03()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII03')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII03')";

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

        public static int ElozoEFAII03()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII03')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII03')";

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

        public static int EFAII04()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII04')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII04')";

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

        public static int ElozoEFAII04()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII04')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII04')";

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

        public static int EFAII05()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII05')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAII05')";

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

        public static int ElozoEFAII05()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII05')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAII05')";

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

        public static int EFAII()
        {
            int egyenleg = EFAII03() + EFAII04() + EFAII05();
            
            return egyenleg;
        }

        public static int ElozoEFAII()
        {
            int egyenleg = ElozoEFAII03() + ElozoEFAII04() + ElozoEFAII05();
            
            return egyenleg;
        }

        public static int EFAIII()
        {
            int egyenleg = EAI() + EFAII();

            return egyenleg;
        }

        public static int ElozoEFAIII()
        {
            int egyenleg = ElozoEAI() + ElozoEFAII();

            return egyenleg;
        }

        public static int EFAIV06()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV06')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV06')";

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

        public static int ElozoEFAIV06()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV06')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV06')";

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

        public static int EFAIV07()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV07')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV07')";

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

        public static int ElozoEFAIV07()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV07')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV07')";

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

        public static int EFAIV08()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV08')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAIV08')";

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

        public static int ElozoEFAIV08()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV08')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAIV08')";

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

        public static int EFAIV()
        {
            int egyenleg = EAIV06() + EFAIV07() + EFAIV08();

            return egyenleg;
        }

        public static int ElozoEFAIV()
        {
            int egyenleg = ElozoEAIV06() + ElozoEFAIV07() + ElozoEFAIV08();

            return egyenleg;
        }

        public static int EFAV()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAV')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAV')";

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

        public static int ElozoEFAV()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAV')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAV')";

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

        public static int EFAVI()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAVI')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EFAVI')";

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

        public static int ElozoEFAVI()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAVI')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EFAVI')";

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

        public static int EFA()
        {
            int egyenleg = EAI() + EAII() + EAIII() - EAIV() + EAV() - EAVI();

            return egyenleg;
        }

        public static int ElozoEFA()
        {
            int egyenleg = ElozoEAI() + ElozoEAII() + ElozoEAIII() - ElozoEAIV() + ElozoEAV() - ElozoEAVI();

            return egyenleg;
        }

        // Közös eredmény sorok
        public static int EBVIII13()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII13')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII13')";

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

        public static int ElozoEBVIII13()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII13')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII13')";

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

        public static int EBVIII14()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII14')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII14')";

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

        public static int ElozoEBVIII14()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII14')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII14')";

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

        public static int EBVIII15()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII15')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII15')";

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

        public static int ElozoEBVIII15()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII15')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII15')";

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

        public static int EBVIII16()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII16')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII16')";

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

        public static int ElozoEBVIII16()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII16')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII16')";

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

        public static int EBVIII17()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII17')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBVIII17')";

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

        public static int ElozoEBVIII17()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII17')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBVIII17')";

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

        public static int EBVIII()
        {
            int egyenleg = EBVIII13() + EBVIII14() + EBVIII15()+ EBVIII16() + EBVIII17();

            return egyenleg;
        }

        public static int ElozoEBVIII()
        {
            int egyenleg = ElozoEBVIII13() + ElozoEBVIII14() + ElozoEBVIII15() + ElozoEBVIII16() + ElozoEBVIII17();

            return egyenleg;
        }

        public static int EBIX18()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX18')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX18')";

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

        public static int ElozoEBIX18()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX18')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX18')";

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

        public static int EBIX19()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX19')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX19')";

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

        public static int ElozoEBIX19()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX19')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX19')";

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

        public static int EBIX20()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX20')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX20')";

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

        public static int ElozoEBIX20()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX20')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX20')";

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

        public static int EBIX21()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX21')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX21')";

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

        public static int ElozoEBIX21()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX21')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX21')";

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

        public static int EBIX22()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX22')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EBIX22')";

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

        public static int ElozoEBIX22()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX22')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EBIX22')";

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

        public static int EBIX()
        {
            int egyenleg = EBIX18() + EBIX19() + EBIX20() + EBIX21() + EBIX22();

            return egyenleg;
        }

        public static int ElozoEBIX()
        {
            int egyenleg = ElozoEBIX18() + ElozoEBIX19() + ElozoEBIX20() + ElozoEBIX21() + ElozoEBIX22();

            return egyenleg;
        }

        public static int EB()
        {
            int egyenleg = EBVIII() - EBIX();

            return egyenleg;
        }

        public static int ElozoEB()
        {
            int egyenleg = ElozoEBVIII() - ElozoEBIX();

            return egyenleg;
        }

        public static int EC()
        {
            int egyenleg = EA() + EB();

            return egyenleg;
        }

        public static int ElozoEC()
        {
            int egyenleg = ElozoEA() + ElozoEB();

            return egyenleg;
        }

        public static int EDX()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EDX')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('EDX')";

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

        public static int ElozoEDX()
        {
            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EDX')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('EDX')";

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

        public static int ED()
        {
            int egyenleg = EC() - EDX();

            return egyenleg;
        }

        public static int ElozoED()
        {
            int egyenleg = ElozoEC() - ElozoEDX();

            return egyenleg;
        }
    }
}
