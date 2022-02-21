using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Zeusz.AdatbazisMuveletek
{
    static class Lekerdezesek
    {
        static SqlConnection connection;

        static KonyvelocegAdatai konyvelocegAdatai;

        internal static KonyvelocegAdatai KonyvelocegAdatai { get => konyvelocegAdatai; set => konyvelocegAdatai = value; }

        public static string JelszoTitkositas(string jelszo)
        {
            byte[] szovegBajtban = Encoding.UTF8.GetBytes(jelszo);
            SHA256CryptoServiceProvider titkosito = new SHA256CryptoServiceProvider();
            byte[] titkositottSzovegBajtban = titkosito.ComputeHash(szovegBajtban);
            string titkositottSzoveg = BitConverter.ToString(titkositottSzovegBajtban).Replace("-", "").ToLower();
            return titkositottSzoveg;
        }

        public static bool Belepes(string nev, string jelszo)
        {
            bool belepes = false;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();

            connection.Open();

            string query = $"SELECT felhasznalonev, jelszo FROM felhasznalok WHERE felhasznalonev = '{nev}'";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                if (reader["jelszo"].Equals(JelszoTitkositas(jelszo)))
                {
                    belepes = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a belépésnél! -> " + ex.Message);
            }

            connection.Close();

            return belepes;
        }

        public static Dictionary<string, byte> JogosultsagLekerdezes(string felhasznalo)
        {
            Dictionary<string, byte> jogosultsagok = new Dictionary<string, byte>();
            connection.Open();

            string query = "SELECT * FROM jogosultsagok WHERE felhasznalonev = '" + felhasznalo + "'";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jogosultsagok.Add(reader["menupont"].ToString(), Convert.ToByte(reader["jogosultsag"]));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a jogosultságok lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();

            return jogosultsagok;
        }

        public static Dictionary<string, byte> JogosultsagLekerdezesNevvel(string felhasznalo)
        {
            Dictionary<string, byte> jogosultsagok = new Dictionary<string, byte>();
            connection.Open();

            string query = "SELECT * FROM jogosultsagok WHERE felhasznalonev = '" + felhasznalo + "'";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jogosultsagok.Add(reader["menupont_neve"].ToString(), Convert.ToByte(reader["jogosultsag"]));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a jogosultságok lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();

            return jogosultsagok;
        }

        public static List<KonyvelocegAdatai> KönyvelocegAdataiLekerdezes()
        {
            List<KonyvelocegAdatai> konyvelocegAdatok = new List<KonyvelocegAdatai>();

            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string cegadatLekeres = "SELECT * FROM cegadatok";
            SqlCommand cmd = new SqlCommand(cegadatLekeres, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                konyvelocegAdatok.Add(new KonyvelocegAdatai(
                        reader["cegnev"].ToString(),
                        reader["bankszamlaszam2"].ToString(),
                        reader["bankszamlaszam3"].ToString(),
                        reader["rovid_cegnev"].ToString(),
                        reader["szekhely_iranyitoszam"].ToString(),
                        reader["szekhely_varos"].ToString(),
                        reader["szekhely_kozterulet"].ToString(),
                        (KozteruletJellege)Enum.Parse(typeof(KozteruletJellege), reader["szekhely_kozterulet_jellege"].ToString(), true),
                        reader["szekhely_hazszam"].ToString(),
                        reader["szekhely_lepcsohaz"].ToString(),
                        reader["szekhely_ajto"].ToString(),
                        reader["adoszam"].ToString(),
                        reader["EU_adoszam"].ToString(),
                        reader["cegjegyzekszam"].ToString(),
                        reader["bankszamlaszam"].ToString(),
                        reader["email"].ToString(),
                        reader["telefon"].ToString()
                    ));
            }
            reader.Close();

            connection.Close();

            return konyvelocegAdatok;
        }

        public static List<KonyveltCegAdatai> KönyveltcegAdataiLekerdezes(string schema)
        {
            List<KonyveltCegAdatai> konyveltcegAdatok = new List<KonyveltCegAdatai>();

            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string cegadatLekeres = $"SELECT * FROM {schema}.cegadatok";
            SqlCommand cmd = new SqlCommand(cegadatLekeres, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                konyveltcegAdatok.Add(new KonyveltCegAdatai(
                        Convert.ToBoolean(reader["osszkoltseg"]),
                        Convert.ToBoolean(reader["forgalmikoltseg"]),
                        reader["cegnev"].ToString(),
                        reader["bankszamlaszam2"].ToString(),
                        reader["bankszamlaszam3"].ToString(),
                        reader["rovid_cegnev"].ToString(),
                        reader["szekhely_iranyitoszam"].ToString(),
                        reader["szekhely_varos"].ToString(),
                        reader["szekhely_kozterulet"].ToString(),
                        (KozteruletJellege)Enum.Parse(typeof(KozteruletJellege), reader["szekhely_kozterulet_jellege"].ToString(), true),
                        reader["szekhely_hazszam"].ToString(),
                        reader["szekhely_lepcsohaz"].ToString(),
                        reader["szekhely_ajto"].ToString(),
                        reader["adoszam"].ToString(),
                        reader["EU_adoszam"].ToString(),
                        reader["cegjegyzekszam"].ToString(),
                        reader["bankszamlaszam"].ToString(),
                        reader["email"].ToString(),
                        reader["telefon"].ToString()
                    ));
            }
            reader.Close();

            connection.Close();

            return konyveltcegAdatok;
        }

        public static List<Felhasznalo> FelhasznaloLekerdezes()
        {
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();

            SqlConnection connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string query = "SELECT * FROM felhasznalok ORDER BY felhasznalonev";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    felhasznalok.Add(new Felhasznalo(
                            reader["felhasznalonev"].ToString(),
                            reader["jelszo"].ToString(),
                            reader["beosztas"].ToString(),
                            reader["email"].ToString()
                        ));
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a felhasználók lekérdezésénél! -> " + ex.Message);
            }

            return felhasznalok;
        }

        public static string VarosLekeres(string iranyitoszam)
        {
            SqlConnection connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();

            connection.Open();

            string varos = "SELECT varos FROM iranyitoszamok WHERE iranyitoszam = @iranyitoszam";

            try
            {
                SqlCommand command = new SqlCommand(varos, connection);
                command.Parameters.AddWithValue("@iranyitoszam", iranyitoszam);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return reader[0].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("A város lekérdezése sikertelen! -> " + ex.Message);
            }
            connection.Close();
            return "";
        }

        public static List<PartnercegAdatai> PartnerLekerdezes(int partnerkod)
        {
            List<PartnercegAdatai> partnerek = new List<PartnercegAdatai>();
            string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string partnerLekeres = $"SELECT * FROM {schema}.partnertorzs WHERE partnerkod = {partnerkod}";

            try
            {
                SqlCommand command = new SqlCommand(partnerLekeres, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    partnerek.Add(new PartnercegAdatai(
                        (int)reader["partnerkod"],
                        reader["szamlazasi_nev"].ToString(),
                        reader["szallitasi_cim_iranyitoszam"].ToString(),
                        reader["szallitasi_cim_varos"].ToString(),
                        reader["szallitasi_cim_kozterulet"].ToString(),
                        reader["szallitasi_cim_hazszam"].ToString(),
                        reader["szallitasi_cim_lepcsohaz"].ToString(),
                        reader["szallitasi_cim_ajto"].ToString(),
                        (KozteruletJellege)Enum.Parse(typeof(KozteruletJellege), reader["szallitasi_cim_kozterulet_jellege"].ToString(), true),
                        reader["cegnev"].ToString(),
                        reader["szamlazasi_cim_iranyitoszam"].ToString(),
                        reader["szamlazasi_cim_varos"].ToString(),
                        reader["szamlazasi_cim_kozterulet"].ToString(),
                        (KozteruletJellege)Enum.Parse(typeof(KozteruletJellege), reader["szamlazasi_cim_kozterulet_jellege"].ToString(), true),
                        reader["szamlazasi_cim_hazszam"].ToString(),
                        reader["szamlazasi_cim_lepcsohaz"].ToString(),
                        reader["szamlazasi_cim_ajto"].ToString(),
                        reader["adoszam"].ToString(),
                        reader["EU_adoszam"].ToString(),
                        reader["cegjegyzekszam"].ToString(),
                        reader["bankszamlaszam"].ToString(),
                        reader["email"].ToString(),
                        reader["telefon"].ToString()
                     ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a partnercég lekérdezése közben! -> " + ex.Message);
            }

            connection.Close();
            return partnerek;
        }

        public static List<PartnercegAdatai> OsszesPartnerLekerdezes()
        {
            List<PartnercegAdatai> partnerek = new List<PartnercegAdatai>();
            string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string partnerLekeres = $"SELECT * FROM {schema}.partnertorzs";

            try
            {
                SqlCommand command = new SqlCommand(partnerLekeres, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    partnerek.Add(new PartnercegAdatai(
                        (int)reader["partnerkod"],
                        reader["szamlazasi_nev"].ToString(),
                        reader["szallitasi_cim_iranyitoszam"].ToString(),
                        reader["szallitasi_cim_varos"].ToString(),
                        reader["szallitasi_cim_kozterulet"].ToString(),
                        reader["szallitasi_cim_hazszam"].ToString(),
                        reader["szallitasi_cim_lepcsohaz"].ToString(),
                        reader["szallitasi_cim_ajto"].ToString(),
                        (KozteruletJellege)Enum.Parse(typeof(KozteruletJellege), reader["szallitasi_cim_kozterulet_jellege"].ToString(), true),
                        reader["cegnev"].ToString(),
                        reader["szamlazasi_cim_iranyitoszam"].ToString(),
                        reader["szamlazasi_cim_varos"].ToString(),
                        reader["szamlazasi_cim_kozterulet"].ToString(),
                        (KozteruletJellege)Enum.Parse(typeof(KozteruletJellege), reader["szamlazasi_cim_kozterulet_jellege"].ToString(), true),
                        reader["szamlazasi_cim_hazszam"].ToString(),
                        reader["szamlazasi_cim_lepcsohaz"].ToString(),
                        reader["szamlazasi_cim_ajto"].ToString(),
                        reader["adoszam"].ToString(),
                        reader["EU_adoszam"].ToString(),
                        reader["cegjegyzekszam"].ToString(),
                        reader["bankszamlaszam"].ToString(),
                        reader["email"].ToString(),
                        reader["telefon"].ToString()
                     ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a partnercég lekérdezése közben! -> " + ex.Message);
            }

            connection.Close();
            return partnerek;
        }

        public static List<Konyveles.Szamla> SzamlakLekerese()
        {
            List<Konyveles.Szamla> szamlak = new List<Konyveles.Szamla>();
            string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string szamlaLekeres = $"SELECT * FROM {schema}.szamlatukor";

            try
            {
                SqlCommand command = new SqlCommand(szamlaLekeres, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["konyvelheto"] is true)
                    {
                        szamlak.Add(new Konyveles.Szamla(reader["szamlaszam"].ToString(), reader["szamla_neve"].ToString(), reader["kapcsolodik_ide"].ToString(), (bool)reader["konyvelheto"], reader["beszamolo"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("A számlák lekérdezése nem sikerült! -> " + ex.Message);
            }
            connection.Close();

            return szamlak;
        }

        public static List<Konyveles.Szamla> OsszesSzamlaLekerese()
        {
            List<Konyveles.Szamla> szamlak = new List<Konyveles.Szamla>();
            string schema = AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string szamLekeres = $"SELECT * FROM {schema}.szamlatukor";

            try
            {
                SqlCommand command = new SqlCommand(szamLekeres, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    szamlak.Add(new Konyveles.Szamla(reader["szamlaszam"].ToString(), reader["szamla_neve"].ToString(), reader["kapcsolodik_ide"].ToString(), (bool)reader["konyvelheto"], reader["beszamolo"].ToString()));
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Hibás számlaszám lekérdezés! -> " + ex.Message);
            }
            return szamlak;

        }

        public static Konyveles.Szamla EgySzamla(string schema, string szamlaszam)
        {
            Konyveles.Szamla szamla;
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string szamlaLekeres = $"SELECT * FROM {schema}.szamlatukor WHERE szamlaszam = {szamlaszam}";

            try
            {
                SqlCommand command = new SqlCommand(szamlaLekeres, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    szamla = new Konyveles.Szamla(reader["szamlaszam"].ToString(), reader["szamla_neve"].ToString(), reader["kapcsolodik_ide"].ToString(), (bool)reader["konyvelheto"], reader["beszamolo"].ToString());
                    return szamla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a számla lekérdezésénél! -> "  + ex.Message);
            }
            connection.Close();
            return null;
        }

        public static string PartnerNevLekeres(string schema, string partnerkod)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string partnerLekeres = $"SELECT cegnev FROM {schema}.partnertorzs WHERE partnerkod = {partnerkod}";

            try
            {
                SqlCommand command = new SqlCommand(partnerLekeres, connection);
                string nev = command.ExecuteScalar().ToString();
                connection.Close();
                return nev;
            }
            catch (Exception ex)
            {
                throw new Exception("Nem sikerült a partner nevének lekérdezése! -> " + ex.Message);
            }
        }

        public static List<Konyveles.KonyvelesiTetel> NyitottVevokLekerdezese(string schema)
        {
            List<Konyveles.KonyvelesiTetel> konyvelesiTetelek = new List<Konyveles.KonyvelesiTetel>();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string nyitottVevok = $"SELECT * FROM {schema}.fokonyv WHERE nyitott_vevo = 1";

            try
            {
                SqlCommand command = new SqlCommand(nyitottVevok, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    konyvelesiTetelek.Add(
                        new Konyveles.KonyvelesiTetel(
                            (int?)reader["id"], 
                            reader["partnerkod"].ToString(), 
                            reader["szamlaszam"].ToString(), 
                            reader["Tszamla"].ToString(),
                            reader["Kszamla"].ToString(), 
                            (double)reader["Tosszeg"],
                            (double)reader["Kosszeg"],
                            reader["gazdasagi_esemeny"].ToString(),
                            (Konyveles.FizetesiMod)Enum.Parse(typeof(Konyveles.FizetesiMod), reader["fizetesimod"].ToString(), true), 
                            0,
                            (DateTime)reader["teljesites"],
                            (DateTime)reader["afa_teljesites"],
                            (DateTime)reader["kelt"],
                            (DateTime)reader["esedekesseg"],
                            (DateTime)reader["konyveles_datuma"],
                            reader["konyvelte"].ToString()
                         )
                     );
                }
                connection.Close();
                
                return konyvelesiTetelek;
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a nyitott vevők lekérdezésénél! -> " + ex.Message);
            }
        }

        public static double NyitottOsszegLekeres(string schema, int? id)
        {
            //double osszeg = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            //string osszegLekeres = $"SELECT {schema}.fokonyv.Tosszeg as fokonyv, {schema}.afa.Tosszeg as afa FROM {schema}.fokonyv INNER JOIN {schema}.afa on {schema}.fokonyv.id = {schema}.afa.fokonyv_id WHERE {schema}.fokonyv.id = {id}";

            string osszegLekeres = $"SELECT Tosszeg, Kosszeg FROM {schema}.fokonyv WHERE id = {id}";

            try
            {
                SqlCommand command = new SqlCommand(osszegLekeres, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToDouble(reader["Tosszeg"]) > Convert.ToDouble(reader["Kosszeg"]))
                    {
                        return Convert.ToDouble(reader["Tosszeg"]);
                    }
                    else if (Convert.ToDouble(reader["Tosszeg"]) < Convert.ToDouble(reader["Kosszeg"]))
                    {
                        return Convert.ToDouble(reader["Kosszeg"]);
                    }
                    //osszeg = Convert.ToDouble(reader["fokonyv"]);
                    //osszeg += Convert.ToDouble(reader["afa"]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a kiegyenlítés összeg lekérésénél! -> " + ex.Message);
            }
            return 0;
        }

        public static List<Konyveles.KonyvelesiTetel> NyitottSzallitokLekerdezese(string schema)
        {
            List<Konyveles.KonyvelesiTetel> konyvelesiTetelek = new List<Konyveles.KonyvelesiTetel>();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string nyitottSzallitok = $"SELECT * FROM {schema}.fokonyv WHERE nyitott_szallito = 1";

            try
            {
                SqlCommand command = new SqlCommand(nyitottSzallitok, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    konyvelesiTetelek.Add(
                        new Konyveles.KonyvelesiTetel(
                            (int?)reader["id"],
                            reader["partnerkod"].ToString(),
                            reader["szamlaszam"].ToString(),
                            reader["Tszamla"].ToString(),
                            reader["Kszamla"].ToString(),
                            Math.Floor((double)reader["Tosszeg"]),
                            Math.Floor((double)reader["Kosszeg"]),
                            reader["gazdasagi_esemeny"].ToString(),
                            (Konyveles.FizetesiMod)Enum.Parse(typeof(Konyveles.FizetesiMod), reader["fizetesimod"].ToString(), true),
                            0,
                            (DateTime)reader["teljesites"],
                            (DateTime)reader["afa_teljesites"],
                            (DateTime)reader["kelt"],
                            (DateTime)reader["esedekesseg"],
                            (DateTime)reader["konyveles_datuma"],
                            reader["konyvelte"].ToString()
                         )
                     );
                }
                connection.Close();

                return konyvelesiTetelek;
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a nyitott szállítók lekérdezésénél! -> " + ex.Message);
            }
        }

        public static List<Konyveles.KonyvelesiTetel> KivonatLekeres(int ev, string schema, int tol, int ig, string fokonyviSzam)
        {
            List<Konyveles.KonyvelesiTetel> konyvelesek = new List<Konyveles.KonyvelesiTetel>();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            // Létrehozok egy átmeneti táblát
            string tablaLetrehozas = $"CREATE TABLE {schema}.kivonat(" +
                $"szamlaszam VARCHAR(5)," +
                $"Tosszeg FLOAT," +
                $"Kosszeg FLOAT" +
                $")";

            try
            {
                SqlCommand cmd = new SqlCommand(tablaLetrehozas, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a kivonat tábla létrehozásánál! -> " + ex.Message);
            }

            // Berakom a főkönyvi számot a tartozik összeggel
            string tOldal = $"INSERT INTO {schema}.kivonat(szamlaszam, Tosszeg) SELECT {schema}.fokonyv.Tszamla, SUM(ISNULL({schema}.fokonyv.Tosszeg, 0)) AS 'tartozik' FROM {schema}.fokonyv WHERE MONTH({schema}.fokonyv.teljesites) BETWEEN {tol} AND {ig} AND {schema}.fokonyv.Tszamla LIKE '{fokonyviSzam}%' AND {schema}.fokonyv.lezarva <> 1 AND YEAR({schema}.fokonyv.teljesites) = {ev} GROUP BY {schema}.fokonyv.Tszamla ";

            string kOldal = $"INSERT INTO {schema}.kivonat(szamlaszam, Kosszeg) SELECT {schema}.fokonyv.Kszamla, SUM(ISNULL({schema}.fokonyv.Kosszeg, 0)) AS 'kovetel' FROM {schema}.fokonyv WHERE MONTH({schema}.fokonyv.teljesites) BETWEEN {tol} AND {ig} AND {schema}.fokonyv.Kszamla LIKE '{fokonyviSzam}%' AND {schema}.fokonyv.lezarva <> 1 AND YEAR({schema}.fokonyv.teljesites) = {ev} GROUP BY {schema}.fokonyv.Kszamla";

            try
            {
                SqlCommand cmd = new SqlCommand(tOldal, connection);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = kOldal;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a kivonat tábla feltöltésnél! -> " + ex.Message);
            }

            // Az objektum az átmeneti táblából készül, le kell kérni az átmeneti táblát is.
            string osszesites = $"SELECT szamlaszam, SUM(ISNULL(Tosszeg, 0)) as 'tartozik', SUM(ISNULL(Kosszeg, 0)) as 'kovetel' FROM {schema}.kivonat GROUP BY szamlaszam HAVING szamlaszam <> '491' OR szamlaszam <> '492' OR szamlaszam <> '493' ORDER BY szamlaszam";

            try
            {
                SqlCommand cmd = new SqlCommand(osszesites, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    konyvelesek.Add(new Konyveles.KonyvelesiTetel(reader["szamlaszam"].ToString(), (double)reader["tartozik"], (double)reader["kovetel"]));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a kivonat lekérdezésnél! -> " + ex.Message);
            }
            

            connection.Close();

            return konyvelesek;
        }

        public static void KivonatTorles(string schema)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string torles = $"DROP TABLE {schema}.kivonat";

            try
            {
                SqlCommand cmd = new SqlCommand(torles, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a kivonat tábla törlésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static List<Konyveles.KonyvelesiTetel> KartonLekeres(string schema, int tol, int ig, string fokonyviSzamTol, string fokonyviSzamIg)
        {
            List<Konyveles.KonyvelesiTetel> tetelek = new List<Konyveles.KonyvelesiTetel>();

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string atmenetiTablaLetrehozas = $"CREATE TABLE {schema}.karton(" +
                $"honap INT," +
                $"teljesites DATE," +
                $"szamlaszam VARCHAR(5)," +
                $"ellenszamla VARCHAR(5)," +
                $"Tosszeg FLOAT," +
                $"Kosszeg FLOAT," +
                $"gazdasagi_esemeny VARCHAR(150)" +
                $")";

            try
            {
                SqlCommand cmd = new SqlCommand(atmenetiTablaLetrehozas, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a karton tábla létrehozásánál! -> " + ex.Message);
            }
            //AND {schema}.fokonyv.lezarva <> 1
            string tOldal = $"INSERT INTO {schema}.karton(honap, teljesites, szamlaszam, ellenszamla, Tosszeg, gazdasagi_esemeny) SELECT MONTH({schema}.fokonyv.teljesites) AS 'honap', {schema}.fokonyv.teljesites, {schema}.fokonyv.Tszamla, {schema}.fokonyv.Kszamla, ISNULL({schema}.fokonyv.Tosszeg, 0) AS 'tartozik', {schema}.fokonyv.gazdasagi_esemeny FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam WHERE MONTH({schema}.fokonyv.teljesites) BETWEEN {tol} AND {ig} AND {schema}.fokonyv.Tszamla BETWEEN {fokonyviSzamTol} AND {fokonyviSzamIg}  ORDER BY teljesites";

            string kOldal = $"INSERT INTO {schema}.karton(honap, teljesites, szamlaszam, ellenszamla, Kosszeg, gazdasagi_esemeny) SELECT MONTH({schema}.fokonyv.teljesites) AS 'honap', {schema}.fokonyv.teljesites, {schema}.fokonyv.Kszamla, {schema}.fokonyv.Tszamla, ISNULL({schema}.fokonyv.Kosszeg, 0) AS 'kovetel', {schema}.fokonyv.gazdasagi_esemeny FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam WHERE MONTH({schema}.fokonyv.teljesites) BETWEEN {tol} AND {ig} AND {schema}.fokonyv.Kszamla BETWEEN {fokonyviSzamTol} AND {fokonyviSzamIg}  ORDER BY teljesites";

            string afaT = $"INSERT INTO {schema}.karton(honap, teljesites, szamlaszam, ellenszamla, Tosszeg, gazdasagi_esemeny) SELECT MONTH({schema}.fokonyv.teljesites) AS 'honap', {schema}.fokonyv.teljesites, {schema}.afa.Tszamla, {schema}.afa.Kszamla, ISNULL({schema}.afa.Tosszeg, 0) AS 'tartozik', {schema}.fokonyv.gazdasagi_esemeny + ' ÁFA' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Tszamla = {schema}.szamlatukor.szamlaszam FULL JOIN {schema}.afa ON {schema}.fokonyv.id = {schema}.afa.fokonyv_id WHERE MONTH({schema}.fokonyv.teljesites) BETWEEN {tol} AND {ig} AND {schema}.afa.Tszamla BETWEEN {fokonyviSzamTol} AND {fokonyviSzamIg} ORDER BY teljesites";

            string afaK = $"INSERT INTO {schema}.karton(honap, teljesites, szamlaszam, ellenszamla, Kosszeg, gazdasagi_esemeny) SELECT MONTH({schema}.fokonyv.teljesites) AS 'honap', {schema}.fokonyv.teljesites, {schema}.afa.Kszamla, {schema}.afa.Tszamla, ISNULL({schema}.afa.Kosszeg, 0) AS 'kovetel', {schema}.fokonyv.gazdasagi_esemeny + ' ÁFA' FROM {schema}.fokonyv FULL JOIN {schema}.szamlatukor ON {schema}.fokonyv.Kszamla = {schema}.szamlatukor.szamlaszam FULL JOIN {schema}.afa ON {schema}.fokonyv.id = {schema}.afa.fokonyv_id WHERE MONTH({schema}.fokonyv.teljesites) BETWEEN {tol} AND {ig} AND {schema}.afa.Kszamla BETWEEN {fokonyviSzamTol} AND {fokonyviSzamIg} ORDER BY teljesites";

            try
            {
                SqlCommand cmd = new SqlCommand(tOldal, connection);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                cmd.CommandText = kOldal;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                cmd.CommandText = afaT;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                cmd.CommandText = afaK;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a karton tábla feltöltésénél! -> " + ex.Message);
            }

            string kartonLeker = $"SELECT honap, teljesites, szamlaszam, ellenszamla, ISNULL(Tosszeg, 0) AS 'Tosszeg', -1 * (ISNULL(Kosszeg, 0)) AS 'Kosszeg', gazdasagi_esemeny FROM {schema}.karton WHERE Tosszeg <> 0 OR Kosszeg <> 0 ORDER BY honap, szamlaszam, teljesites";

            try
            {
                SqlCommand cmd = new SqlCommand(kartonLeker, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tetelek.Add(new Konyveles.KonyvelesiTetel((int)reader["honap"], (DateTime)reader["teljesites"], reader["szamlaszam"].ToString(), reader["ellenszamla"].ToString(), (double)reader["Tosszeg"], (double)reader["Kosszeg"], reader["gazdasagi_esemeny"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a karton lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();

            return tetelek;
        }

        public static void KartonTorles(string schema)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string torles = $"DROP TABLE {schema}.karton";

            try
            {
                SqlCommand cmd = new SqlCommand(torles, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a karton tábla törlésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static List<Konyveles.KonyvelesiTetel> AfaAnalitikaLekeres(string schema, int tol, int ig)
        {
            List<Konyveles.KonyvelesiTetel> tetelek = new List<Konyveles.KonyvelesiTetel>();

            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string afaAtmenetiTabla = $"CREATE TABLE {schema}.afaPuffer(" +
                $"honap INT," +
                $"afakulcs FLOAT," +
                $"afa_osszeg FLOAT," +
                $"szamlaszam VARCHAR(10)," +
                $"partnerkod VARCHAR(4)," +
                $"afa_teljesites DATE," +
                $"netto FLOAT" +
                $")";

            try
            {
                SqlCommand cmd = new SqlCommand(afaAtmenetiTabla, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az áfa átmeneti tábla létrehozásánál! -> " + ex.Message);
            }

            string visszaigenyelheto = $"INSERT INTO {schema}.afaPuffer SELECT MONTH({schema}.fokonyv.afa_teljesites), {schema}.afa.afakulcs, {schema}.afa.Tosszeg, {schema}.fokonyv.szamlaszam, {schema}.fokonyv.partnerkod, {schema}.fokonyv.afa_teljesites, {schema}.fokonyv.Kosszeg FROM {schema}.afa FULL JOIN {schema}.fokonyv ON {schema}.afa.fokonyv_id = {schema}.fokonyv.id WHERE {schema}.afa.Tszamla = '466' AND MONTH(afa_teljesites) BETWEEN {tol} AND {ig} ORDER BY MONTH({schema}.fokonyv.afa_teljesites), {schema}.afa.afakulcs";
            
            string fizetendo = $"INSERT INTO {schema}.afaPuffer SELECT MONTH({schema}.fokonyv.afa_teljesites), {schema}.afa.afakulcs, (-1 * ({schema}.afa.Kosszeg)), {schema}.fokonyv.szamlaszam, {schema}.fokonyv.partnerkod, {schema}.fokonyv.afa_teljesites, {schema}.fokonyv.Tosszeg FROM {schema}.afa FULL JOIN {schema}.fokonyv ON {schema}.afa.fokonyv_id = {schema}.fokonyv.id WHERE {schema}.afa.Kszamla = '467' AND MONTH(afa_teljesites) BETWEEN {tol} AND {ig} ORDER BY MONTH({schema}.fokonyv.afa_teljesites), {schema}.afa.afakulcs";

            try
            {
                SqlCommand feltoltes = new SqlCommand(visszaigenyelheto, connection);
                feltoltes.ExecuteNonQuery();

                feltoltes.Parameters.Clear();
                feltoltes.CommandText = fizetendo;
                feltoltes.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az átmeneti áfa tábla feltöltésénél! -> " + ex.Message);
            }

            string lekerdez = $"SELECT * FROM {schema}.afaPuffer ORDER BY honap, partnerkod, afakulcs";

            try
            {
                SqlCommand leker = new SqlCommand(lekerdez, connection);
                SqlDataReader reader = leker.ExecuteReader();

                while (reader.Read())
                {
                    tetelek.Add(new Konyveles.KonyvelesiTetel(
                        Convert.ToInt32(reader["honap"]),
                        Convert.ToDouble(reader["afakulcs"]),
                        Convert.ToDouble(reader["afa_osszeg"]),
                        reader["szamlaszam"].ToString(),
                        reader["partnerkod"].ToString(),
                        (DateTime)reader["afa_teljesites"],
                        Convert.ToDouble(reader["netto"]) / 1.27
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a puffer tábla lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();

            return tetelek;
        }

        public static void AfaTorles(string schema)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string torles = $"DROP TABLE {schema}.afaPuffer";

            try
            {
                SqlCommand cmd = new SqlCommand(torles, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a Áfa tábla törlésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static List<Beallitasok.BeszamoloSor> BeszámolSorokLekerese(string schema)
        {
            List<Beallitasok.BeszamoloSor> beszamoloSorok = new List<Beallitasok.BeszamoloSor>();

            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string leker = $"SELECT * FROM {schema}.beszamolo_sorok";

            try
            {
                SqlCommand cmd = new SqlCommand(leker, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    beszamoloSorok.Add(new Beallitasok.BeszamoloSor(reader["sorszam"].ToString(), reader["megnevezes"].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a beszámoló sorok lekérésénél! -> " + ex.Message);
            }

            connection.Close();

            return beszamoloSorok;
        }

        public static int EredmenyLekeres(string schema)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            int egyenleg;
            
            string lekeresT = $"SELECT SUM(ISNULL(Tosszeg, 0)) FROM {schema}.fokonyv WHERE Tszamla = '493'";
            string lekeresK = $"SELECT SUM(ISNULL(Kosszeg, 0)) FROM {schema}.fokonyv WHERE Kszamla = '493'";
            
            try
            {
                SqlCommand cmd = new SqlCommand(lekeresT, connection);
                egyenleg = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Parameters.Clear();

                cmd.CommandText = lekeresK;
                egyenleg -= Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az eredmény lekérdezésekor! -> " + ex.Message);
            }
            connection.Close();

            return egyenleg;
        }

        public static bool LezartE(string schema)
        {
            bool lezart;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string lekeres = $"SELECT lezarva FROM lezart_schemak WHERE schema_neve = '{schema}'";

            try
            {
                SqlCommand cmd = new SqlCommand(lekeres, connection);
                lezart = (bool)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lezárt schema lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();

            return lezart;
        }

        public static List<Konyveles.KonyvelesiTetel> LezartMerlegSzamlak(string schema)
        {
            List<Konyveles.KonyvelesiTetel> tetelek = new List<Konyveles.KonyvelesiTetel>();

            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string lekeres = $"SELECT * FROM {schema}.fokonyv WHERE Tszamla = '492' OR Kszamla = 492";

            try
            {
                SqlCommand cmd = new SqlCommand(lekeres, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tetelek.Add(new Konyveles.KonyvelesiTetel(1, Convert.ToDateTime(DateTime.Now.ToShortDateString()), reader["Tszamla"].ToString(), reader["Kszamla"].ToString(), (double)reader["Tosszeg"], (double)reader["Kosszeg"], "Számla nyitás"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a lezárt mérlegszámlák lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();

            return tetelek;
        }

        public static bool OsszkoltsegesE(string schema)
        {
            bool osszktsg;
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string lekeres = $"SELECT osszkoltseg FROM {schema}.cegadatok;";

            try
            {
                SqlCommand cmd = new SqlCommand(lekeres, connection);
                
                osszktsg = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az összköltség adatok lekérésénél! -> " + ex.Message);
            }

            connection.Close();

            return osszktsg;
        }

        //
        //Költségek chart-hoz
        //
        public static List<Zeusz.Lekerdezesek.KoltsegEgyenleg> OsszesKoltsegLekerese(string schema)
        {
            List<Zeusz.Lekerdezesek.KoltsegEgyenleg> egyenlegek = new List<Zeusz.Lekerdezesek.KoltsegEgyenleg>();

            int egyenleg51 = AdatbazisMuveletek.Eredmeny.EAIV05();
            int egyenleg52 = AdatbazisMuveletek.Eredmeny.EAIV06();
            int egyenleg53 = AdatbazisMuveletek.Eredmeny.EAIV07();
            int egyenleg54 = AdatbazisMuveletek.Eredmeny.EAV10();
            int egyenleg55 = AdatbazisMuveletek.Eredmeny.EAV11();
            int egyenleg56 = AdatbazisMuveletek.Eredmeny.EAV12();
            int egyenleg57 = AdatbazisMuveletek.Eredmeny.EAVI();

            if (egyenleg51 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Anyagköltség", egyenleg51));
            }

            if (egyenleg52 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Igénybe vett szolgáltatások", egyenleg52));
            }

            if (egyenleg53 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Egyéb szolgáltatások", egyenleg53));
            }

            if (egyenleg54 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Bérköltség", egyenleg54));
            }

            if (egyenleg55 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Szem. jellegű e. kifiz.", egyenleg55));
            }

            if (egyenleg56 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Bérjárulékok", egyenleg56));
            }

            if (egyenleg57 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("ÉCS", egyenleg57));
            }

            return egyenlegek;
        }

        public static List<Zeusz.Lekerdezesek.KoltsegEgyenleg> BazisOsszesKoltsegLekerese(string schema)
        {
            List<Zeusz.Lekerdezesek.KoltsegEgyenleg> egyenlegek = new List<Zeusz.Lekerdezesek.KoltsegEgyenleg>();

            int egyenleg51 = AdatbazisMuveletek.Eredmeny.ElozoEAIV05();
            int egyenleg52 = AdatbazisMuveletek.Eredmeny.ElozoEAIV06();
            int egyenleg53 = AdatbazisMuveletek.Eredmeny.ElozoEAIV07();
            int egyenleg54 = AdatbazisMuveletek.Eredmeny.ElozoEAV10();
            int egyenleg55 = AdatbazisMuveletek.Eredmeny.ElozoEAV11();
            int egyenleg56 = AdatbazisMuveletek.Eredmeny.ElozoEAV12();
            int egyenleg57 = AdatbazisMuveletek.Eredmeny.ElozoEAVI();

            if (egyenleg51 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Anyagköltség", egyenleg51));
            }

            if (egyenleg52 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Igénybe vett szolgáltatások", egyenleg52));
            }

            if (egyenleg53 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Egyéb szolgáltatások", egyenleg53));
            }

            if (egyenleg54 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Bérköltség", egyenleg54));
            }

            if (egyenleg55 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Szem. jellegű e. kifiz.", egyenleg55));
            }

            if (egyenleg56 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Bérjárulékok", egyenleg56));
            }

            if (egyenleg57 != 0)
            {
                egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("ÉCS", egyenleg57));
            }

            return egyenlegek;
        }

        //
        //Mutatószámok / pénzügyi helyzet
        //
        public static double AdossagallomanyAranyaLekerdezes(string schema)
        {
            double arany;
            double adossagallomany = AdatbazisMuveletek.Merleg.MFI() + AdatbazisMuveletek.Merleg.MFII();
            double sajatToke = AdatbazisMuveletek.Merleg.MD();

            arany = adossagallomany / (adossagallomany + sajatToke) * 100;

            return arany;
        }

        public static double LikviditasiMutatoLekeres(string schema)
        {
            double arany = 0;
            double forgoeszkoz = AdatbazisMuveletek.Merleg.MB();
            double rlk = AdatbazisMuveletek.Merleg.MFIII();

            arany = (forgoeszkoz / rlk);

            return arany;
        }

        public static double LikviditasiGyorsrataLekerdezes(string schema)
        {
            double arany = 0;
            double penzeszkErtekpapKoveteles = AdatbazisMuveletek.Merleg.MBII() + AdatbazisMuveletek.Merleg.MBIII() + AdatbazisMuveletek.Merleg.MBIV();
            double rlk = AdatbazisMuveletek.Merleg.MFIII();
            /*
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            //31,32,34,36,37,38
            string lekeres31T = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '31%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres31K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '31%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres32T = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '32%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres32K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '32%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres34T = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '34%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres34K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '34%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres36T = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '36%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres36K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '36%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres37T = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '37%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres37K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '37%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres38T = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '38%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres38K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '38%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres45K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '45%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres45T = $"SELECT ISNULL(SUM(Tosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '45%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres46K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '46%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres46T = $"SELECT ISNULL(SUM(Tosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '46%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            string lekeres47K = $"SELECT ISNULL(SUM(Kosszeg), 0) AS 'kovetel' FROM {schema}.fokonyv WHERE Kszamla LIKE '47%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";
            string lekeres47T = $"SELECT ISNULL(SUM(Tosszeg), 0) AS 'tartozik' FROM {schema}.fokonyv WHERE Tszamla LIKE '47%' AND YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4))} AND lezarva = 0";

            try
            {
                //31,32,34,36,37,38
                SqlCommand cmd = new SqlCommand(lekeres31T, connection);
                szamlalo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres31K;
                szamlalo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres32T;
                szamlalo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres32K;
                szamlalo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres34T;
                szamlalo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres34K;
                szamlalo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres36T;
                szamlalo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres36K;
                szamlalo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres37T;
                szamlalo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres37K;
                szamlalo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres38T;
                szamlalo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres38K;
                szamlalo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres45K;
                nevezo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres45T;
                nevezo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres46K;
                nevezo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres46T;
                nevezo -= Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres47K;
                nevezo += Convert.ToDouble(cmd.ExecuteScalar());

                cmd.Parameters.Clear();
                cmd.CommandText = lekeres47T;
                nevezo -= Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az likviditási gyorsráta lekérdezésénél! -> " + ex.Message);
            }

            connection.Close();
            */
            arany = (penzeszkErtekpapKoveteles / rlk);

            return arany;
        }

        public static double NettoMukodoTokeLekerdezes(string schema)
        {
            double forgoeszkozok = AdatbazisMuveletek.Merleg.MB();
            double rlk = AdatbazisMuveletek.Merleg.MFIII();

            return forgoeszkozok - rlk;
        }

        //
        //Mutatószámok / vagyoni helyzet
        //
        public static double TokeszerkezetiMutatoLekerdezes(string schema)
        {
            double arany = 0;
            double sajatToke = AdatbazisMuveletek.Merleg.MD();
            double kotelezettsegek = AdatbazisMuveletek.Merleg.MF();

            arany = (sajatToke / kotelezettsegek) * 100;

            return arany;
        }

        public static double BefektetettEszkozFedezetettsegLekerdezes(string schema)
        {
            double arany = 0;
            double sajatToke = AdatbazisMuveletek.Merleg.MD();
            double befEszk = AdatbazisMuveletek.Merleg.MA();

            arany = (sajatToke / befEszk) * 100;

            return arany;
        }

        public static double VagyonszerkezetLekeres(string schema)
        {
            double arany = 0;
            double befEszk = AdatbazisMuveletek.Merleg.MA();
            double forgoeszk = AdatbazisMuveletek.Merleg.MB();

            arany = (befEszk / forgoeszk) * 100;

            return arany;
        }

        public static double BefektetettEszkozokAranyaLekerdezes(string schema)
        {
            double arany = 0;
            double befEszk = AdatbazisMuveletek.Merleg.MA();
            double osszesEszk = AdatbazisMuveletek.Merleg.MA() + AdatbazisMuveletek.Merleg.MB() + AdatbazisMuveletek.Merleg.MC();

            arany = (befEszk / osszesEszk) * 100;

            return arany;
        }

        //
        //Bevétel-költség arány
        //
        public static List<Zeusz.Lekerdezesek.KoltsegEgyenleg> BevetelKtsgArany(string schema)
        {
            List<Zeusz.Lekerdezesek.KoltsegEgyenleg> egyenlegek = new List<Zeusz.Lekerdezesek.KoltsegEgyenleg>();
            double puffer = 0;

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            for (int i = 1; i < 12; i++)
            {
                string bevetelLekeresT = $"SELECT ISNULL(SUM(Tosszeg), 0) FROM {schema}.fokonyv WHERE Tszamla LIKE '9%' AND lezarva = 0 AND MONTH(teljesites) = {i}";
                string bevetelLekeresK = $"SELECT ISNULL(SUM(Kosszeg), 0) FROM {schema}.fokonyv WHERE Kszamla LIKE '9%' AND lezarva = 0 AND MONTH(teljesites) = {i}";
                string koltsegRafordT = $"SELECT ISNULL(SUM(Tosszeg), 0) FROM {schema}.fokonyv WHERE (Tszamla LIKE '5%' OR Tszamla LIKE '8%') AND lezarva = 0 AND MONTH(teljesites) = {i}";
                string koltsegRafordK = $"SELECT ISNULL(SUM(Kosszeg), 0) FROM {schema}.fokonyv WHERE (Kszamla LIKE '5%' OR Kszamla LIKE '8%') AND lezarva = 0 AND MONTH(teljesites) = {i}";

                try
                {
                    SqlCommand cmd = new SqlCommand(bevetelLekeresK, connection);
                    puffer += Convert.ToDouble(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();

                    cmd.CommandText = bevetelLekeresT;
                    puffer -= Convert.ToDouble(cmd.ExecuteScalar());

                    egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Bevételek", puffer, i));
                    puffer = 0;

                    cmd.Parameters.Clear();
                    cmd.CommandText = koltsegRafordT;
                    puffer = Convert.ToDouble(cmd.ExecuteScalar());

                    cmd.Parameters.Clear();
                    cmd.CommandText = koltsegRafordK;
                    puffer -= Convert.ToDouble(cmd.ExecuteScalar());

                    egyenlegek.Add(new Zeusz.Lekerdezesek.KoltsegEgyenleg("Költésgek, ráfordítások", puffer, i));
                    puffer = 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hiba a bevétel-költség lekérdezésnél! -> " + ex.Message);
                } 
            }

            connection.Close();

            return egyenlegek;
        }
    }
}
