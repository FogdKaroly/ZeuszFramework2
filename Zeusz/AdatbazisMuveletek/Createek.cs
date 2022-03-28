using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Zeusz.AdatbazisMuveletek
{
    static class Createek
    {
        static SqlConnection connection;

        public static void UjKonyveltCeg(string schema)
        {
			string elozoEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) - 1).ToString());

			connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

			string cegadatok = $"CREATE TABLE {schema}.cegadatok(" +
				"cegnev VARCHAR(150) NOT NULL," +
				"rovid_cegnev VARCHAR(50)," +
				"szekhely_iranyitoszam VARCHAR(4) NOT NULL," +
				"szekhely_varos VARCHAR(50) NOT NULL," +
				"szekhely_kozterulet VARCHAR(100) NOT NULL," +
				"szekhely_kozterulet_jellege VARCHAR(10) NOT NULL," +
				"szekhely_hazszam VARCHAR(3) NOT NULL," +
				"szekhely_lepcsohaz VARCHAR(3)," +
				"szekhely_ajto VARCHAR(3)," +
				"adoszam VARCHAR(15) NOT NULL," +
				"EU_adoszam VARCHAR(10)," +
				"cegjegyzekszam VARCHAR(12) NOT NULL," +
				"bankszamlaszam VARCHAR(26) NOT NULL," +
				"bankszamlaszam2 VARCHAR(26)," +
				"bankszamlaszam3 VARCHAR(26)," +
				"email VARCHAR(320)," +
				"telefon VARCHAR(12)," +
				"osszkoltseg BIT," +
				"forgalmikoltseg BIT" +
			");";

			string szalmatukor = $"CREATE TABLE {schema}.szamlatukor(" +
					"szamlaszam VARCHAR(6) PRIMARY KEY NOT NULL," +
					"szamla_neve VARCHAR(150) NOT NULL," +
					"kapcsolodik_ide VARCHAR(6)," +
					"konyvelheto BIT," +
					"beszamolo VARCHAR(10)" +
				");" +
				$"INSERT INTO {schema}.szamlatukor SELECT * FROM szamlatukor;";

			string partnertorzs = $"CREATE TABLE {schema}.partnertorzs(" +
					"partnerkod INT NOT NULL PRIMARY KEY IDENTITY(1, 1)," +
					"cegnev VARCHAR(150) NOT NULL," +
					"szamlazasi_nev VARCHAR(150) NOT NULL," +
					"szamlazasi_cim_iranyitoszam VARCHAR(4) NOT NULL," +
					"szamlazasi_cim_varos VARCHAR(50) NOT NULL," +
					"szamlazasi_cim_kozterulet VARCHAR(100) NOT NULL," +
					"szamlazasi_cim_kozterulet_jellege VARCHAR(10) NOT NULL," +
					"szamlazasi_cim_hazszam VARCHAR(3) NOT NULL," +
					"szamlazasi_cim_lepcsohaz VARCHAR(3)," +
					"szamlazasi_cim_ajto VARCHAR(3)," +
					"szallitasi_cim_iranyitoszam VARCHAR(4)," +
					"szallitasi_cim_varos VARCHAR(50)," +
					"szallitasi_cim_kozterulet VARCHAR(100)," +
					"szallitasi_cim_kozterulet_jellege VARCHAR(10)," +
					"szallitasi_cim_hazszam VARCHAR(3)," +
					"szallitasi_cim_lepcsohaz VARCHAR(3)," +
					"szallitasi_cim_ajto VARCHAR(3)," +
					"adoszam VARCHAR(15) NOT NULL," +
					"EU_adoszam VARCHAR(10)," +
					"cegjegyzekszam VARCHAR(12) NOT NULL," +
					"bankszamlaszam VARCHAR(26) NOT NULL," +
					"email VARCHAR(320)," +
					"telefon VARCHAR(12)" +
				");";

			string fokonyv = $"CREATE TABLE {schema}.fokonyv (" +
					"id INT PRIMARY KEY NOT NULL IDENTITY(1, 1)," +
					"partnerkod INT," +
					"szamlaszam VARCHAR(50)," +
					"Tszamla INT NOT NULL," +
					"Kszamla INT NOT NULL," +
					"Tosszeg FLOAT(53) NOT NULL," +
					"Kosszeg FLOAT(53) NOT NULL," +
					"gazdasagi_esemeny VARCHAR(300) NOT NULL," +
					"fizetesimod CHAR(12)," +
					"teljesites DATE," +
                    "afa_teljesites DATE," +
					"kelt DATE," +
					"esedekesseg DATE," +
					"konyveles_datuma DATETIME," +
					"konyvelte VARCHAR(50) NOT NULL," +
					"nyitott_vevo BIT," +
					"nyitott_szallito BIT," +
					"teljesitve DATE," +
					"lezarva BIT," +
                    "nyito BIT," +
					$"CONSTRAINT FK_fokonyv_partnertorzs FOREIGN KEY(partnerkod) REFERENCES {schema}.partnertorzs(partnerkod)" +
				");";

			string afaTabla = $"CREATE TABLE {schema}.afa (" +
					"id INT PRIMARY KEY NOT NULL IDENTITY(1, 1)," +
					"fokonyv_id INT NOT NULL," +
					"Tszamla INT NOT NULL," +
					"Kszamla INT NOT NULL," +
					"Tosszeg FLOAT(53) NOT NULL," +
					"Kosszeg FLOAT(53) NOT NULL," +
					"afakulcs INT," +
                    "teljesites, DATE" +
					$"CONSTRAINT FK_afa_fokonyv FOREIGN KEY(fokonyv_id) REFERENCES {schema}.fokonyv(id)" +
				");";

			string beszamoloSorok = $"CREATE TABLE {schema}.beszamolo_sorok(" +
					"sorszam VARCHAR(10) PRIMARY KEY NOT NULL," +
					"megnevezes VARCHAR(150) NOT NULL" +
				");";

			string lezart_e = $"INSERT INTO lezart_schemak VALUES('{schema}', 0)";


			try
            {
				SqlCommand cegadat = new SqlCommand(cegadatok, connection);
				cegadat.ExecuteNonQuery();

				SqlCommand szlatukor = new SqlCommand(szalmatukor, connection);
				szlatukor.ExecuteNonQuery();

				SqlCommand partner = new SqlCommand(partnertorzs, connection);
				partner.ExecuteNonQuery();

				SqlCommand fok = new SqlCommand(fokonyv, connection);
				fok.ExecuteNonQuery();

				SqlCommand afa = new SqlCommand(afaTabla, connection);
				afa.ExecuteNonQuery();

				SqlCommand beszamolo = new SqlCommand(beszamoloSorok, connection);
				beszamolo.ExecuteNonQuery();

				SqlCommand lezart = new SqlCommand(lezart_e, connection);
				lezart.ExecuteNonQuery();
			}
            catch (Exception ex)
            {
                throw new Exception("Hiba az új cég táblák létrehozásánál -> " + ex.Message);
            }

			string elozoCegadatok = $"CREATE TABLE {elozoEvSchema}.cegadatok(" +
				"cegnev VARCHAR(150) NOT NULL," +
				"rovid_cegnev VARCHAR(50)," +
				"szekhely_iranyitoszam VARCHAR(4) NOT NULL," +
				"szekhely_varos VARCHAR(50) NOT NULL," +
				"szekhely_kozterulet VARCHAR(100) NOT NULL," +
				"szekhely_kozterulet_jellege VARCHAR(10) NOT NULL," +
				"szekhely_hazszam VARCHAR(3) NOT NULL," +
				"szekhely_lepcsohaz VARCHAR(3)," +
				"szekhely_ajto VARCHAR(3)," +
				"adoszam VARCHAR(15) NOT NULL," +
				"EU_adoszam VARCHAR(10)," +
				"cegjegyzekszam VARCHAR(12) NOT NULL," +
				"bankszamlaszam VARCHAR(26) NOT NULL," +
				"bankszamlaszam2 VARCHAR(26)," +
				"bankszamlaszam3 VARCHAR(26)," +
				"email VARCHAR(320)," +
				"telefon VARCHAR(12)," +
				"osszkoltseg BIT," +
				"forgalmikoltseg BIT" +
			");";

			string elozoSzalmatukor = $"CREATE TABLE {elozoEvSchema}.szamlatukor(" +
					"szamlaszam VARCHAR(6) PRIMARY KEY NOT NULL," +
					"szamla_neve VARCHAR(150) NOT NULL," +
					"kapcsolodik_ide VARCHAR(6)," +
					"konyvelheto BIT," +
					"beszamolo VARCHAR(10)" +
				");" +
				$"INSERT INTO {elozoEvSchema}.szamlatukor SELECT * FROM szamlatukor;";

			string elozoPartnertorzs = $"CREATE TABLE {elozoEvSchema}.partnertorzs(" +
					"partnerkod INT NOT NULL PRIMARY KEY IDENTITY(1, 1)," +
					"cegnev VARCHAR(150) NOT NULL," +
					"szamlazasi_nev VARCHAR(150) NOT NULL," +
					"szamlazasi_cim_iranyitoszam VARCHAR(4) NOT NULL," +
					"szamlazasi_cim_varos VARCHAR(50) NOT NULL," +
					"szamlazasi_cim_kozterulet VARCHAR(100) NOT NULL," +
					"szamlazasi_cim_kozterulet_jellege VARCHAR(10) NOT NULL," +
					"szamlazasi_cim_hazszam VARCHAR(3) NOT NULL," +
					"szamlazasi_cim_lepcsohaz VARCHAR(3)," +
					"szamlazasi_cim_ajto VARCHAR(3)," +
					"szallitasi_cim_iranyitoszam VARCHAR(4)," +
					"szallitasi_cim_varos VARCHAR(50)," +
					"szallitasi_cim_kozterulet VARCHAR(100)," +
					"szallitasi_cim_kozterulet_jellege VARCHAR(10)," +
					"szallitasi_cim_hazszam VARCHAR(3)," +
					"szallitasi_cim_lepcsohaz VARCHAR(3)," +
					"szallitasi_cim_ajto VARCHAR(3)," +
					"adoszam VARCHAR(15) NOT NULL," +
					"EU_adoszam VARCHAR(10)," +
					"cegjegyzekszam VARCHAR(12) NOT NULL," +
					"bankszamlaszam VARCHAR(26) NOT NULL," +
					"email VARCHAR(320)," +
					"telefon VARCHAR(12)" +
				");";

			string elozoFokonyv = $"CREATE TABLE {elozoEvSchema}.fokonyv (" +
					"id INT PRIMARY KEY NOT NULL IDENTITY(1, 1)," +
					"partnerkod INT," +
					"szamlaszam VARCHAR(50)," +
					"Tszamla INT NOT NULL," +
					"Kszamla INT NOT NULL," +
					"Tosszeg FLOAT(53) NOT NULL," +
					"Kosszeg FLOAT(53) NOT NULL," +
					"gazdasagi_esemeny VARCHAR(300) NOT NULL," +
					"fizetesimod CHAR(12)," +
					"teljesites DATE," +
                    "afa_teljesites DATE," +
					"kelt DATE," +
					"esedekesseg DATE," +
					"konyveles_datuma DATETIME," +
					"konyvelte VARCHAR(50) NOT NULL," +
					"nyitott_vevo BIT," +
					"nyitott_szallito BIT," +
					"teljesitve DATE," +
					"lezarva BIT," +
                    "nyito BIT," +
					$"CONSTRAINT FK_fokonyv_partnertorzs FOREIGN KEY(partnerkod) REFERENCES {schema}.partnertorzs(partnerkod)" +
				");";

			string elozoAfaTabla = $"CREATE TABLE {elozoEvSchema}.afa (" +
					"id INT PRIMARY KEY NOT NULL IDENTITY(1, 1)," +
					"fokonyv_id INT NOT NULL," +
					"Tszamla INT NOT NULL," +
					"Kszamla INT NOT NULL," +
					"Tosszeg FLOAT(53) NOT NULL," +
					"Kosszeg FLOAT(53) NOT NULL," +
					"afakulcs INT," +
                    "teljesites DATE" +
					$"CONSTRAINT FK_afa_fokonyv FOREIGN KEY(fokonyv_id) REFERENCES {schema}.fokonyv(id)" +
				");";

			string elozoBeszamoloSorok = $"CREATE TABLE {elozoEvSchema}.beszamolo_sorok(" +
					"sorszam VARCHAR(10) PRIMARY KEY NOT NULL," +
					"megnevezes VARCHAR(150) NOT NULL" +
				");";

			string elozoLezart_e = $"INSERT INTO lezart_schemak VALUES('{schema}', 1)";


			try
			{
				SqlCommand cegadat = new SqlCommand(elozoCegadatok, connection);
				cegadat.ExecuteNonQuery();

				SqlCommand szlatukor = new SqlCommand(elozoSzalmatukor, connection);
				szlatukor.ExecuteNonQuery();

				SqlCommand partner = new SqlCommand(elozoPartnertorzs, connection);
				partner.ExecuteNonQuery();

				SqlCommand fok = new SqlCommand(elozoFokonyv, connection);
				fok.ExecuteNonQuery();

				SqlCommand afa = new SqlCommand(elozoAfaTabla, connection);
				afa.ExecuteNonQuery();

				SqlCommand beszamolo = new SqlCommand(elozoBeszamoloSorok, connection);
				beszamolo.ExecuteNonQuery();

				SqlCommand lezart = new SqlCommand(elozoLezart_e, connection);
				lezart.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception("Hiba az új cég előző évi táblák létrehozásánál -> " + ex.Message);
			}

			connection.Close();
        }

		public static void UjEvLetrehozas(string schema)
        {
			string ujEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) + 1).ToString());

			connection = AdatbazisKapcsolodas.Kapcsolodas();
			connection.Open();

			string schemaLetrehozas = $"CREATE SCHEMA {ujEvSchema}";

			string cegadatok = $"CREATE TABLE {ujEvSchema}.cegadatok(" +
				"cegnev VARCHAR(150) NOT NULL," +
				"rovid_cegnev VARCHAR(50)," +
				"szekhely_iranyitoszam VARCHAR(4) NOT NULL," +
				"szekhely_varos VARCHAR(50) NOT NULL," +
				"szekhely_kozterulet VARCHAR(100) NOT NULL," +
				"szekhely_kozterulet_jellege VARCHAR(10) NOT NULL," +
				"szekhely_hazszam VARCHAR(3) NOT NULL," +
				"szekhely_lepcsohaz VARCHAR(3)," +
				"szekhely_ajto VARCHAR(3)," +
				"adoszam VARCHAR(15) NOT NULL," +
				"EU_adoszam VARCHAR(10)," +
				"cegjegyzekszam VARCHAR(12) NOT NULL," +
				"bankszamlaszam VARCHAR(26) NOT NULL," +
				"bankszamlaszam2 VARCHAR(26)," +
				"bankszamlaszam3 VARCHAR(26)," +
				"email VARCHAR(320)," +
				"telefon VARCHAR(12)," +
				"osszkoltseg BIT," +
				"forgalmikoltseg BIT" +
			");" +
			$"INSERT INTO {ujEvSchema}.cegadatok SELECT * FROM {schema}.cegadatok";

			string szalmatukor = $"CREATE TABLE {ujEvSchema}.szamlatukor(" +
					"szamlaszam VARCHAR(6) PRIMARY KEY NOT NULL," +
					"szamla_neve VARCHAR(150) NOT NULL," +
					"kapcsolodik_ide VARCHAR(6)," +
					"konyvelheto BIT," +
					"beszamolo VARCHAR(10)" +
				");" +
				$"INSERT INTO {ujEvSchema}.szamlatukor SELECT * FROM {schema}.szamlatukor;";

			string partnertorzs = $"CREATE TABLE {ujEvSchema}.partnertorzs(" +
					"partnerkod INT NOT NULL PRIMARY KEY IDENTITY(1, 1)," +
					"cegnev VARCHAR(150) NOT NULL," +
					"szamlazasi_nev VARCHAR(150) NOT NULL," +
					"szamlazasi_cim_iranyitoszam VARCHAR(4) NOT NULL," +
					"szamlazasi_cim_varos VARCHAR(50) NOT NULL," +
					"szamlazasi_cim_kozterulet VARCHAR(100) NOT NULL," +
					"szamlazasi_cim_kozterulet_jellege VARCHAR(10) NOT NULL," +
					"szamlazasi_cim_hazszam VARCHAR(3) NOT NULL," +
					"szamlazasi_cim_lepcsohaz VARCHAR(3)," +
					"szamlazasi_cim_ajto VARCHAR(3)," +
					"szallitasi_cim_iranyitoszam VARCHAR(4)," +
					"szallitasi_cim_varos VARCHAR(50)," +
					"szallitasi_cim_kozterulet VARCHAR(100)," +
					"szallitasi_cim_kozterulet_jellege VARCHAR(10)," +
					"szallitasi_cim_hazszam VARCHAR(3)," +
					"szallitasi_cim_lepcsohaz VARCHAR(3)," +
					"szallitasi_cim_ajto VARCHAR(3)," +
					"adoszam VARCHAR(15) NOT NULL," +
					"EU_adoszam VARCHAR(10)," +
					"cegjegyzekszam VARCHAR(12) NOT NULL," +
					"bankszamlaszam VARCHAR(26) NOT NULL," +
					"email VARCHAR(320)," +
					"telefon VARCHAR(12)" +
				");" +
				$"SET IDENTITY_INSERT {ujEvSchema}.partnertorzs ON; INSERT INTO {ujEvSchema}.partnertorzs(partnerkod, cegnev, szamlazasi_nev, szamlazasi_cim_iranyitoszam, szamlazasi_cim_varos, szamlazasi_cim_kozterulet, szamlazasi_cim_kozterulet_jellege, szamlazasi_cim_hazszam, szamlazasi_cim_lepcsohaz, szamlazasi_cim_ajto, szallitasi_cim_iranyitoszam, szallitasi_cim_varos, szallitasi_cim_kozterulet, szallitasi_cim_kozterulet_jellege, szallitasi_cim_hazszam, szallitasi_cim_lepcsohaz, szallitasi_cim_ajto, adoszam, EU_adoszam, cegjegyzekszam, bankszamlaszam, email, telefon) SELECT partnerkod, cegnev, szamlazasi_nev, szamlazasi_cim_iranyitoszam, szamlazasi_cim_varos, szamlazasi_cim_kozterulet, szamlazasi_cim_kozterulet_jellege, szamlazasi_cim_hazszam, szamlazasi_cim_lepcsohaz, szamlazasi_cim_ajto, szallitasi_cim_iranyitoszam, szallitasi_cim_varos, szallitasi_cim_kozterulet, szallitasi_cim_kozterulet_jellege, szallitasi_cim_hazszam, szallitasi_cim_lepcsohaz, szallitasi_cim_ajto, adoszam, EU_adoszam, cegjegyzekszam, bankszamlaszam, email, telefon FROM {schema}.partnertorzs; SET IDENTITY_INSERT {ujEvSchema}.partnertorzs OFF;";

			string fokonyv = $"CREATE TABLE {ujEvSchema}.fokonyv (" +
					"id INT PRIMARY KEY NOT NULL IDENTITY(1, 1)," +
					"partnerkod INT," +
					"szamlaszam VARCHAR(50)," +
					"Tszamla INT NOT NULL," +
					"Kszamla INT NOT NULL," +
					"Tosszeg FLOAT(53) NOT NULL," +
					"Kosszeg FLOAT(53) NOT NULL," +
					"gazdasagi_esemeny VARCHAR(300) NOT NULL," +
					"fizetesimod CHAR(12)," +
					"teljesites DATE," +
                    "afa_teljesites DATE," +
					"kelt DATE," +
					"esedekesseg DATE," +
					"konyveles_datuma DATETIME," +
					"konyvelte VARCHAR(50) NOT NULL," +
					"nyitott_vevo BIT," +
					"nyitott_szallito BIT," +
					"teljesitve DATE," +
					"lezarva BIT," +
                    "nyito BIT," +
					$"CONSTRAINT FK_fokonyv_partnertorzs FOREIGN KEY(partnerkod) REFERENCES {ujEvSchema}.partnertorzs(partnerkod)" +
				");";

			string afaTabla = $"CREATE TABLE {ujEvSchema}.afa (" +
					"id INT PRIMARY KEY NOT NULL IDENTITY(1, 1)," +
					"fokonyv_id INT NOT NULL," +
					"Tszamla INT NOT NULL," +
					"Kszamla INT NOT NULL," +
					"Tosszeg FLOAT(53) NOT NULL," +
					"Kosszeg FLOAT(53) NOT NULL," +
					"afakulcs INT," +
                    "teljesites DATE," +
					$"CONSTRAINT FK_afa_fokonyv FOREIGN KEY(fokonyv_id) REFERENCES {ujEvSchema}.fokonyv(id)" +
				");";

			string beszamoloSorok = $"CREATE TABLE {ujEvSchema}.beszamolo_sorok(" +
					$"sorszam VARCHAR(10) PRIMARY KEY NOT NULL," +
					$"megnevezes VARCHAR(150) NOT NULL" +
				$");" +
				$"INSERT INTO {ujEvSchema}.beszamolo_sorok SELECT * FROM {schema}.beszamolo_sorok;";

			string lezart_e = $"INSERT INTO lezart_schemak VALUES('{ujEvSchema}', 0)";


			try
			{
				SqlCommand schemaCreate = new SqlCommand(schemaLetrehozas, connection);
				schemaCreate.ExecuteNonQuery();

				SqlCommand cegadat = new SqlCommand(cegadatok, connection);
				cegadat.ExecuteNonQuery();

				SqlCommand szlatukor = new SqlCommand(szalmatukor, connection);
				szlatukor.ExecuteNonQuery();

				SqlCommand partner = new SqlCommand(partnertorzs, connection);
				partner.ExecuteNonQuery();

				SqlCommand fok = new SqlCommand(fokonyv, connection);
				fok.ExecuteNonQuery();

				SqlCommand afa = new SqlCommand(afaTabla, connection);
				afa.ExecuteNonQuery();

				SqlCommand beszamolo = new SqlCommand(beszamoloSorok, connection);
				beszamolo.ExecuteNonQuery();

				SqlCommand lezart = new SqlCommand(lezart_e, connection);
				lezart.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception("Hiba az új cég táblák létrehozásánál -> " + ex.Message);
			}
		}
    }
}
