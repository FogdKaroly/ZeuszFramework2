using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.AdatbazisMuveletek
{
    internal static class Merleg
    {
        static SqlConnection connection;
        
        static string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;
        

        public static int MA(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString());
            string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString());

            int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read()) 
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoMA(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int MAI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static int ElozoMAI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }
        
        public static int MAI1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAI2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAI3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAI4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAI5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAI6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAI7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAI7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAII7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII8')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII8')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII8')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII8')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII8')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII8')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII9(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII9')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII9')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII9')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII9(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII9')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII9')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII9')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MAIII10(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII10')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAIII10')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII10')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMAIII10(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII10')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII10')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII10')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MB(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMB(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBI6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBI6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBI6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBI6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBI6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII8')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBII8')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII8')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII8')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII8')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII8')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1', 'MBIV2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző immat javak lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIV1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIV1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIV1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIV1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIV1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIV1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MBIV2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIV2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MBIV2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIV2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MBIV2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMBIV2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MBIV2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MC(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMC(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1', 'MC2', 'MC3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MC1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMC1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MC2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMC2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MC3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MC3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MC3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMC3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MC3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MOsszesEszkoz(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMOsszesEszkoz(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MAI1', 'MAI2', 'MAI3', 'MAI4', 'MAI5', 'MAI6', 'MAI7', 'MAII1', 'MAII2', 'MAII3', 'MAII4', 'MAII5', 'MAII6', 'MAII7', 'MAIII1', 'MAIII2', 'MAIII3', 'MAIII4', 'MAIII5', 'MAIII6', 'MAIII7', 'MAIII8', 'MAIII9', 'MAIII10', 'MBI1', 'MBI2', 'MBI3', 'MBI4', 'MBI5', 'MBI6', 'MBII1', 'MBII2', 'MBII3', 'MBII4', 'MBII5', 'MBII6', 'MBII7', 'MBII8', 'MBIII1', 'MBIII2', 'MBIII3', 'MBIII4', 'MBIII5', 'MBIII6', 'MBIV1', 'MBIV2', 'MC1', 'MC2', 'MC3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg += Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg -= Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MD(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMD(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDI')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDI')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDI')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDI')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDII')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDII')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDII')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDII')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDIII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDIII')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDIII')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDIII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIII')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIII')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDIV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDIV')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDIV')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDIV')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDIV')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDIV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIV')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIV')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIV')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDIV')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDV')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDV')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDV')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDV')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDV(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDV')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDV')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDV')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDV')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDVI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDVI')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDVI')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDVI')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDVI')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDVI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVI')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVI')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVI')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVI')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MDVII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDVII')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDVII')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDVII')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDVII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMDVII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVII')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVII')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVII')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDVII')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ME(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoME(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1', 'ME2', 'ME3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ME1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoME1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ME2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoME2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ME3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('ME3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('ME3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoME3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('ME3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MF(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMF(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFI(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1', 'MFI2', 'MFI3', 'MFI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFI1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFI1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFI2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFI2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFI3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFI3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFI4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFI4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFI4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFI4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII8')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII8')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII8')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII8')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII8')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII8')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFII9(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII9')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFII9')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII9')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFII9(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII9')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII9')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII9')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII4')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII4')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII4')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII4(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII4')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII4')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII4')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII4')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII5')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII5')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII5')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII5(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII5')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII5')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII5')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII5')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII6')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII6')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII6')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII6(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII6')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII6')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII6')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII6')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII7')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII7')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII7')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII7(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII7')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII7')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII7')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII7')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII8')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII8')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII8')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII8(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII8')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII8')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII8')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII8')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII9(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII9')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII9')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII9')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII9(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII9')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII9')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII9')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII9')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII10(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII10')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII10')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII10')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII10(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII10')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII10')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII10')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII10')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MFIII11(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII11')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MFIII11')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII11')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MFIII11')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMFIII11(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII11')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII11')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII11')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MFIII11')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MG(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMG(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1', 'MG2', 'MG3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MG1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG1')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG1')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG1')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMG1(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG1')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MG2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG2')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG2')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG2')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMG2(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG2')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG2')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG2')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG2')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MG3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MG3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MG3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMG3(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MG3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int MOsszesForras(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

            string Koldal = $"SELECT ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE (YEAR({schema}.fokonyv.teljesites) = {ev} OR {schema}.fokonyv.nyito = 1) AND {schema}.fokonyv.lezarva <> 1 AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

            string afaToldal = $"SELECT ISNULL({schema}.afa.Tosszeg, 0) AS 'afa_t' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Tszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

            string afaKoldal = $"SELECT ISNULL({schema}.afa.Kosszeg, 0) AS 'afa_k' FROM {schema}.afa FULL JOIN {schema}.szamlatukor ON {schema}.afa.Kszamla = {schema}.szamlatukor.szamlaszam  WHERE {schema}.afa.teljesites LIKE '{ev}%' AND {schema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lekérésnél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }

        public static int ElozoMOsszesForras(int ev)
        {
            schema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev)).ToString()); string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(ev) - 1).ToString()); int egyenleg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string Toldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Tosszeg, 0) AS 'fokonyv_t' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

            string Koldal = $"SELECT ISNULL({elozoEvSchema}.fokonyv.Kosszeg, 0) AS 'fokonyv_k' FROM {elozoEvSchema}.fokonyv FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.fokonyv.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE (YEAR({elozoEvSchema}.fokonyv.teljesites) = {ev} - 1  OR {elozoEvSchema}.fokonyv.nyito = 1) AND {elozoEvSchema}.fokonyv.lezarva <> 1 AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

            string afaToldal = $"SELECT ISNULL({elozoEvSchema}.afa.Tosszeg, 0) AS 'afa_t' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Tszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

            string afaKoldal = $"SELECT ISNULL({elozoEvSchema}.afa.Kosszeg, 0) AS 'afa_k' FROM {elozoEvSchema}.afa FULL JOIN {elozoEvSchema}.szamlatukor ON {elozoEvSchema}.afa.Kszamla = {elozoEvSchema}.szamlatukor.szamlaszam WHERE {elozoEvSchema}.afa.teljesites LIKE '{ev - 1}%' AND {elozoEvSchema}.szamlatukor.beszamolo IN('MDI', 'MDII', 'MDIII', 'MDIV', 'MDV', 'MDVI', 'MDVII', 'ME1', 'ME2', 'ME3', 'MFI1', 'MFI2', 'MFI3', 'MFI4', 'MFII1', 'MFII2', 'MFII3', 'MFII4', 'MFII5', 'MFII6', 'MFII7', 'MFII8', 'MFII9', 'MFIII1', 'MFIII2', 'MFIII3', 'MFIII4', 'MFIII5', 'MFIII6', 'MFIII7', 'MFIII8', 'MFIII9', 'MFIII10', 'MFIII11', 'MG1', 'MG2', 'MG3')";

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
                
                command.Parameters.Clear();
                command.CommandText = afaToldal;

                SqlDataReader reader2 = command.ExecuteReader();

                while (reader2.Read())
                {
                    egyenleg -= Convert.ToInt32(reader2["afa_t"]);
                }

                reader2.Close();

                command.Parameters.Clear();
                command.CommandText = afaKoldal;

                SqlDataReader reader3 = command.ExecuteReader();

                while (reader3.Read())
                {
                    egyenleg += Convert.ToInt32(reader3["afa_k"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az előző évi befektetett eszközök lekérésénél! -> " + ex.Message);
            }
            connection.Close();

            return (egyenleg);
        }
    }
}
