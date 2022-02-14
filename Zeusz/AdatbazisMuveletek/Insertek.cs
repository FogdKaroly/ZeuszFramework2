using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.AdatbazisMuveletek
{
    static class Insertek
    {
        static SqlConnection connection;

        public static void FelhasznaloModositas(Felhasznalo felhasznalo)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string userFeltoltes = "UPDATE felhasznalok SET felhasznalonev = @felhasznalonev, jelszo = @jelszo, beosztas = @beosztas, email = @email WHERE felhasznalonev = @felhasznalonev";

            try
            {
                SqlCommand command = new SqlCommand(userFeltoltes, connection);
                command.Parameters.AddWithValue("@felhasznalonev", felhasznalo.Felhasznalonev);
                command.Parameters.AddWithValue("@jelszo", felhasznalo.Jelszo);
                command.Parameters.AddWithValue("@beosztas", felhasznalo.Beosztas);
                command.Parameters.AddWithValue("@email", felhasznalo.Email);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("A felhasználó módosítása nem sikerült! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void CegAdatFeltoltes(KonyvelocegAdatai konyvelocegAdatai)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string query = "UPDATE cegadatok SET " +
                $"cegnev = @cegnev, " +
                $"rovid_cegnev = @rovid_cegnev, " +
                $"szekhely_iranyitoszam = @szekhely_iranyitoszam, " +
                $"szekhely_varos = @szekhely_varos, " +
                $"szekhely_kozterulet = @szekhely_kozterulet, " +
                $"szekhely_kozterulet_jellege = @szekhely_kozterulet_jellege, " +
                $"szekhely_hazszam = @szekhely_hazszam, " +
                $"szekhely_lepcsohaz = @szekhely_lepcsohaz, " +
                $"szekhely_ajto = @szekhely_ajto, " +
                $"adoszam = @adoszam, " +
                $"EU_adoszam = @EU_adoszam, " +
                $"cegjegyzekszam = @cegjegyzekszam, " +
                $"bankszamlaszam = @bankszamlaszam, " +
                $"bankszamlaszam2 = @bankszamlaszam2, " +
                $"bankszamlaszam3 = @bankszamlaszam3, " +
                $"email = @email, " +
                $"telefon = @telefon";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cegnev", konyvelocegAdatai.Cegnev);
                command.Parameters.AddWithValue("@rovid_cegnev", konyvelocegAdatai.RovidCegnev);
                command.Parameters.AddWithValue("@szekhely_iranyitoszam", konyvelocegAdatai.Iranyitoszam);
                command.Parameters.AddWithValue("@szekhely_varos", konyvelocegAdatai.Varos);
                command.Parameters.AddWithValue("@szekhely_kozterulet", konyvelocegAdatai.KozteruletNeve);
                command.Parameters.AddWithValue("@szekhely_kozterulet_jellege", konyvelocegAdatai.KozteruletJellege.ToString());
                command.Parameters.AddWithValue("@szekhely_hazszam", konyvelocegAdatai.Hazszam);
                command.Parameters.AddWithValue("@szekhely_lepcsohaz", konyvelocegAdatai.Lepcsohaz);
                command.Parameters.AddWithValue("@szekhely_ajto", konyvelocegAdatai.Ajto);
                command.Parameters.AddWithValue("@adoszam", konyvelocegAdatai.Adoszam);
                command.Parameters.AddWithValue("@EU_adoszam", konyvelocegAdatai.EuAdoszam);
                command.Parameters.AddWithValue("@cegjegyzekszam", konyvelocegAdatai.Cegjegyzekszam);
                command.Parameters.AddWithValue("@bankszamlaszam", konyvelocegAdatai.Bankszamlaszam);
                command.Parameters.AddWithValue("@bankszamlaszam2", konyvelocegAdatai.Bankszamlaszam2);
                command.Parameters.AddWithValue("@bankszamlaszam3", konyvelocegAdatai.Bankszamlaszam3);
                command.Parameters.AddWithValue("@email", konyvelocegAdatai.Email);
                command.Parameters.AddWithValue("@telefon", konyvelocegAdatai.Telefon);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Sikeres feltöltés!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a könyvelőcég adatainak beillesztésénél! -> " + ex.Message);
            }
        }

        public static void UjCegFeltoltes(string schema, KonyveltCegAdatai konyveltcegAdatai)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string cegadatok = "INSERT INTO " + schema + ".cegadatok (cegnev, rovid_cegnev, szekhely_iranyitoszam, szekhely_varos, szekhely_kozterulet, szekhely_kozterulet_jellege, szekhely_hazszam, szekhely_lepcsohaz, szekhely_ajto, adoszam, EU_adoszam, cegjegyzekszam, bankszamlaszam, bankszamlaszam2, bankszamlaszam3, email, telefon, osszkoltseg, forgalmikoltseg) VALUES (@cegnev, @rovid_Cegnev, @szekhely_iranyitoszam, @szekhely_varos, @szekhely_kozterulet, @szekhely_kozterulet_jellege, @szekhely_hazszam, @szekhely_lepcsohaz, @szekhely_ajto, @adoszam, @EU_adoszam, @cegjegyzekszam, @bankszamlaszam, @bankszamlaszam2, @bankszamlaszam3, @email, @telefon, @osszkoltseg, @forgalmikoltseg);";

            try
            {
                SqlCommand command = new SqlCommand(cegadatok, connection);
                //command.Parameters.AddWithValue("@schema", schema);
                command.Parameters.AddWithValue("@cegnev", konyveltcegAdatai.Cegnev);
                command.Parameters.AddWithValue("@rovid_cegnev", konyveltcegAdatai.RovidCegnev);
                command.Parameters.AddWithValue("@szekhely_iranyitoszam", konyveltcegAdatai.Iranyitoszam);
                command.Parameters.AddWithValue("@szekhely_varos", konyveltcegAdatai.Varos);
                command.Parameters.AddWithValue("@szekhely_kozterulet", konyveltcegAdatai.KozteruletNeve);
                command.Parameters.AddWithValue("@szekhely_kozterulet_jellege", konyveltcegAdatai.KozteruletJellege.ToString());
                command.Parameters.AddWithValue("@szekhely_hazszam", konyveltcegAdatai.Hazszam);
                command.Parameters.AddWithValue("@szekhely_lepcsohaz", konyveltcegAdatai.Lepcsohaz);
                command.Parameters.AddWithValue("@szekhely_ajto", konyveltcegAdatai.Ajto);
                command.Parameters.AddWithValue("@adoszam", konyveltcegAdatai.Adoszam);
                command.Parameters.AddWithValue("@EU_adoszam", konyveltcegAdatai.EuAdoszam);
                command.Parameters.AddWithValue("@cegjegyzekszam", konyveltcegAdatai.Cegjegyzekszam);
                command.Parameters.AddWithValue("@bankszamlaszam", konyveltcegAdatai.Bankszamlaszam);
                command.Parameters.AddWithValue("@bankszamlaszam2", konyveltcegAdatai.Bankszamlaszam2);
                command.Parameters.AddWithValue("@bankszamlaszam3", konyveltcegAdatai.Bankszamlaszam3);
                command.Parameters.AddWithValue("@email", konyveltcegAdatai.Email);
                command.Parameters.AddWithValue("@telefon", konyveltcegAdatai.Telefon);
                command.Parameters.AddWithValue("@osszkoltseg", konyveltcegAdatai.Osszkoltseg);
                command.Parameters.AddWithValue("@forgalmikoltseg", konyveltcegAdatai.Forgalmikoltseg);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Sikeres feltöltés!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az új cégadatok feltöltésénél! -> " + ex.Message);
            }
        }

        public static void UjFelhasznalo(Felhasznalo felhasznalo)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string feltoltes = "INSERT INTO felhasznalok VALUES (" +
                $"'{felhasznalo.Felhasznalonev}'," +
                $"'{felhasznalo.Jelszo}'," +
                $"'{felhasznalo.Beosztas}'," +
                $"'{felhasznalo.Email}');";

            string jogosultsag = $"INSERT INTO jogosultsagok(menupont, menupont_neve, felhasznalonev, jogosultsag) VALUES" +
                $"('afaAnalitikaBtn', 'ÁFA analitika', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('beallitasokBtn', 'Beállítások', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('cegvaltasBtn', 'Cégváltás', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('eredmenyKesziteseBtn', 'Eredmény készítés', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('evNyitasBtn', 'Évnyitás', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('evZarasBtn', 'Évzárás', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('felhasznalokKezeleseBtn', 'Felhasználók kezelése', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('jogosultsagKezelesBtn', 'Jogosultságok kezelése', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('kartonBtn', 'Főkönyvi karton', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('kezikonyvBtn', 'Kézikönyv', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('kivonatBtn', 'Főkönyvi kivonat', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('konyvelesBtn', 'Könyvelés', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('konyveloCegAdataiBtn', 'Könyvelő cég adatai', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('konyveltCegAdataiBtn', 'Könyvelt cégek adatai', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('lekerdezesekBtn', 'Lekérdezések', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('merlegKesziteseBtn', 'Mérleg készítés', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('nevjegyBtn', 'Névjegy', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('nyitottSzallitoBtn', 'Nyitott szállítók', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('nyitottVevoBtn', 'Nyitott vevők', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('sugoBtn', 'Súgó', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('ujTetelKonyveleseBtn', 'Új tétel könyvelése', '{felhasznalo.Felhasznalonev}', 0)," +
                $"('vezetoiInfoBtn', 'Vezetői infók', '{felhasznalo.Felhasznalonev}', 0)";

            try
            {
                SqlCommand user = new SqlCommand(feltoltes, connection);
                user.ExecuteNonQuery();

                SqlCommand jogok = new SqlCommand(jogosultsag, connection);
                jogok.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a felhasználó és jogosultság létrehozásánál -> " + ex.Message);
            }

            connection.Close();
        }

        public static void JogosultsagFeltoltes(string felhasznalonev, string menupontNeve, byte jogosultsag)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string jogosultsagFeltoltes = "UPDATE jogosultsagok SET jogosultsag = @jogosultsag WHERE felhasznalonev = @felhasznalonev and menupont_neve = @menupont_neve";

            try
            {
                SqlCommand feltoltes = new SqlCommand(jogosultsagFeltoltes, connection);
                feltoltes.Parameters.AddWithValue("@felhasznalonev", felhasznalonev);
                feltoltes.Parameters.AddWithValue("@jogosultsag", jogosultsag);
                feltoltes.Parameters.AddWithValue("@menupont_neve", menupontNeve);

                feltoltes.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a jogosultság feltöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void UjPartner(string schema, PartnercegAdatai partnercegAdatai)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string partnerFeltoltes =
                $"INSERT INTO {schema}.partnertorzs(cegnev, szamlazasi_nev, szamlazasi_cim_iranyitoszam, szamlazasi_cim_varos, szamlazasi_cim_kozterulet, szamlazasi_cim_kozterulet_jellege, szamlazasi_cim_hazszam, szamlazasi_cim_lepcsohaz, szamlazasi_cim_ajto, szallitasi_cim_iranyitoszam, szallitasi_cim_varos, szallitasi_cim_kozterulet, szallitasi_cim_kozterulet_jellege, szallitasi_cim_hazszam, szallitasi_cim_lepcsohaz, szallitasi_cim_ajto, adoszam, EU_adoszam, cegjegyzekszam, bankszamlaszam, email, telefon) " +
                $"VALUES(" +
                $"'{partnercegAdatai.RovidCegnev}'," +
                $"'{partnercegAdatai.SzamlazasiNev}'," +
                $"'{partnercegAdatai.Iranyitoszam}'," +
                $"'{partnercegAdatai.Varos}'," +
                $"'{partnercegAdatai.KozteruletNeve}'," +
                $"'{partnercegAdatai.KozteruletJellege.ToString()}'," +
                $"'{partnercegAdatai.Hazszam}'," +
                $"'{partnercegAdatai.Lepcsohaz}'," +
                $"'{partnercegAdatai.Ajto}'," +
                $"'{partnercegAdatai.SzallitasiIranyitoszam}'," +
                $"'{partnercegAdatai.SzallitasiVaros}'," +
                $"'{partnercegAdatai.SzallitasiKozteruletNeve}'," +
                $"'{partnercegAdatai.SzallitasiKozteruletJellege.ToString()}'," +
                $"'{partnercegAdatai.SzallitasiHazszam}'," +
                $"'{partnercegAdatai.SzallitasiLepcsohaz}'," +
                $"'{partnercegAdatai.SzallitasiAjto}'," +
                $"'{partnercegAdatai.Adoszam}'," +
                $"'{partnercegAdatai.EuAdoszam}'," +
                $"'{partnercegAdatai.Cegjegyzekszam}'," +
                $"'{partnercegAdatai.Bankszamlaszam}'," +
                $"'{partnercegAdatai.Email}'," +
                $"'{partnercegAdatai.Telefon}');";
            try
            {
                SqlCommand command = new SqlCommand(partnerFeltoltes, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az új partner feltöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void PartnerModositas(string schema, PartnercegAdatai partnercegAdatai)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string partnerFeltoltes = $"UPDATE {schema}.partnertorzs SET cegnev = @cegnev, szamlazasi_nev = @szamlazasi_nev, szamlazasi_cim_iranyitoszam = @szamlazasi_cim_iranyitoszam, szamlazasi_cim_varos = @szamlazasi_cim_varos, szamlazasi_cim_kozterulet = @szamlazasi_cim_kozterulet, szamlazasi_cim_kozterulet_jellege = @szamlazasi_cim_kozterulet_jellege, szamlazasi_cim_hazszam = @szamlazasi_cim_hazszam, szamlazasi_cim_lepcsohaz = @szamlazasi_cim_lepcsohaz, szamlazasi_cim_ajto = @szamlazasi_cim_ajto, szallitasi_cim_iranyitoszam = @szallitasi_cim_iranyitoszam, szallitasi_cim_varos = @szallitasi_cim_varos, szallitasi_cim_kozterulet = @szallitasi_cim_kozterulet, szallitasi_cim_kozterulet_jellege = @szallitasi_cim_kozterulet_jellege, szallitasi_cim_hazszam = @szallitasi_cim_hazszam, szallitasi_cim_lepcsohaz = @szallitasi_cim_lepcsohaz, szallitasi_cim_ajto = @szallitasi_cim_ajto, adoszam = @adoszam, EU_adoszam = @eu_adoszam, cegjegyzekszam = @cegjegyzekszam, bankszamlaszam = @bankszamlaszam, email = @email, telefon = @telefon WHERE partnerkod = @partnerkod";

            try
            {
                SqlCommand command = new SqlCommand(partnerFeltoltes, connection);
                command.Parameters.AddWithValue("@cegnev", partnercegAdatai.RovidCegnev);
                command.Parameters.AddWithValue("@szamlazasi_nev", partnercegAdatai.SzamlazasiNev);
                command.Parameters.AddWithValue("@szamlazasi_cim_iranyitoszam", partnercegAdatai.Iranyitoszam);
                command.Parameters.AddWithValue("@szamlazasi_cim_varos", partnercegAdatai.Varos);
                command.Parameters.AddWithValue("@szamlazasi_cim_kozterulet", partnercegAdatai.KozteruletNeve);
                command.Parameters.AddWithValue("@szamlazasi_cim_kozterulet_jellege", partnercegAdatai.KozteruletJellege).ToString();
                command.Parameters.AddWithValue("@szamlazasi_cim_hazszam", partnercegAdatai.Hazszam);
                command.Parameters.AddWithValue("@szamlazasi_cim_lepcsohaz", partnercegAdatai.Lepcsohaz);
                command.Parameters.AddWithValue("@szamlazasi_cim_ajto", partnercegAdatai.Ajto);
                command.Parameters.AddWithValue("@szallitasi_cim_iranyitoszam", partnercegAdatai.SzallitasiIranyitoszam);
                command.Parameters.AddWithValue("@szallitasi_cim_varos", partnercegAdatai.SzallitasiVaros);
                command.Parameters.AddWithValue("@szallitasi_cim_kozterulet", partnercegAdatai.SzallitasiKozteruletNeve);
                command.Parameters.AddWithValue("@szallitasi_cim_kozterulet_jellege", partnercegAdatai.SzallitasiKozteruletJellege.ToString());
                command.Parameters.AddWithValue("@szallitasi_cim_hazszam", partnercegAdatai.SzallitasiHazszam);
                command.Parameters.AddWithValue("@szallitasi_cim_lepcsohaz", partnercegAdatai.SzallitasiLepcsohaz);
                command.Parameters.AddWithValue("@szallitasi_cim_ajto", partnercegAdatai.SzallitasiAjto);
                command.Parameters.AddWithValue("@adoszam", partnercegAdatai.Adoszam);
                command.Parameters.AddWithValue("@eu_adoszam", partnercegAdatai.EuAdoszam);
                command.Parameters.AddWithValue("@cegjegyzekszam", partnercegAdatai.Cegjegyzekszam);
                command.Parameters.AddWithValue("@bankszamlaszam", partnercegAdatai.Bankszamlaszam);
                command.Parameters.AddWithValue("@email", partnercegAdatai.Email);
                command.Parameters.AddWithValue("@telefon", partnercegAdatai.Telefon);
                command.Parameters.AddWithValue("@partnerkod", partnercegAdatai.Partnerkod);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az új partner feltöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void SzamlatukorModositas(string schema, Konyveles.Szamla szamla)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string szamlaModositas = $"UPDATE {schema}.szamlatukor SET szamlaszam = @szamlaszam, szamla_neve = @szamla_neve, kapcsolodik_ide = @kapcsolodik_ide, konyvelheto = @konyvelheto, beszamolo = @beszamolo WHERE szamlaszam = @szamlaszam";

            try
            {
                SqlCommand command = new SqlCommand(szamlaModositas, connection);
                command.Parameters.AddWithValue("@szamlaszam", szamla.Szamlaszam);
                command.Parameters.AddWithValue("@szamla_neve", szamla.SzamlaNeve);
                command.Parameters.AddWithValue("@kapcsolodik_ide", szamla.KapcsolodikIde);
                command.Parameters.AddWithValue("@konyvelheto", szamla.Konyvelheto);
                command.Parameters.AddWithValue("@beszamolo", szamla.HelyeABeszamoloban);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("A számla módosítása sikertelen! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void UjSzamlaFelvitele(string schema, Konyveles.Szamla ujSzamla)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string ujSzamlaFelvitel = $"INSERT INTO {schema}.szamlatukor VALUES(@szamlaszam, @szamla_neve, @kapcsolodik_ide, @konyvelheto, @beszamolo)";
            string kapcsolodoLetiltas = $"UPDATE {schema}.szamlatukor SET konyvelheto = 0 WHERE szamlaszam = @kapcsolodik_ide";

            try
            {
                SqlCommand command = new SqlCommand(ujSzamlaFelvitel, connection);
                command.Parameters.AddWithValue("@szamlaszam", ujSzamla.Szamlaszam);
                command.Parameters.AddWithValue("@szamla_neve", ujSzamla.SzamlaNeve);
                command.Parameters.AddWithValue("@kapcsolodik_ide", ujSzamla.KapcsolodikIde);
                command.Parameters.AddWithValue("@konyvelheto", ujSzamla.Konyvelheto);
                command.Parameters.AddWithValue("@beszamolo", ujSzamla.HelyeABeszamoloban);
                command.ExecuteNonQuery();

                SqlCommand tiltas = new SqlCommand(kapcsolodoLetiltas, connection);
                tiltas.Parameters.AddWithValue("@kapcsolodik_ide", ujSzamla.KapcsolodikIde);
                tiltas.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az új számla feltöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void UjVevoTetelFelvitele(string schema, Konyveles.KonyvelesiTetel tetel)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string konyvelesT = $"INSERT INTO {schema}.fokonyv(partnerkod, szamlaszam, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, fizetesimod, teljesites, afa_teljesites, kelt, esedekesseg, konyveles_datuma, konyvelte, nyitott_vevo, lezarva) OUTPUT INSERTED.id VALUES(@partnerkod, @szamlaszam, @Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @fizetesi_mod, @teljesites, @afa_teljesites, @kelt, @esedekesseg, @konyveles_datuma, @konyvelte, @nyitott_vevo, 0)";

            string konyvelesK = $"INSERT INTO {schema}.fokonyv(partnerkod, szamlaszam, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, fizetesimod, teljesites, afa_teljesites, kelt, esedekesseg, konyveles_datuma, konyvelte, nyitott_vevo, lezarva) VALUES(@partnerkod, @szamlaszam, @Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @fizetesi_mod, @teljesites, @afa_teljesites, @kelt, @esedekesseg, @konyveles_datuma, @konyvelte, @nyitott_vevo, 0)";

            string afa = $"INSERT INTO {schema}.afa(fokonyv_id, Tszamla, Kszamla, Tosszeg, Kosszeg, afakulcs) VALUES(@fokonyv_id, @Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @afakulcs)";

            try
            {
                SqlCommand konyvFeltoltT = new SqlCommand(konyvelesT, connection);
                konyvFeltoltT.Parameters.AddWithValue("@partnerkod", tetel.Partnerkod);
                konyvFeltoltT.Parameters.AddWithValue("@szamlaszam", tetel.Szamlaszam);
                konyvFeltoltT.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                konyvFeltoltT.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                konyvFeltoltT.Parameters.AddWithValue("@Tosszeg", tetel.TOsszeg + tetel.AfaSzamitas());
                konyvFeltoltT.Parameters.AddWithValue("@Kosszeg", 0);
                konyvFeltoltT.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                konyvFeltoltT.Parameters.AddWithValue("@fizetesi_mod", tetel.FizetesiMod.ToString());
                konyvFeltoltT.Parameters.AddWithValue("@teljesites", tetel.Teljesites);
                konyvFeltoltT.Parameters.AddWithValue("@afa_teljesites", tetel.AfaTeljesites);
                konyvFeltoltT.Parameters.AddWithValue("@kelt", tetel.SzamlaKelte);
                konyvFeltoltT.Parameters.AddWithValue("@esedekesseg", tetel.Esedekesseg);
                konyvFeltoltT.Parameters.AddWithValue("@konyveles_datuma", tetel.KonyvelesDatuma);
                konyvFeltoltT.Parameters.AddWithValue("@konyvelte", tetel.Konyvelte);
                konyvFeltoltT.Parameters.AddWithValue("@nyitott_vevo", true);

                tetel.Id = (int)konyvFeltoltT.ExecuteScalar();

                SqlCommand afaFeltolt = new SqlCommand(afa, connection);

                afaFeltolt.Parameters.AddWithValue("@fokonyv_id", tetel.Id);
                afaFeltolt.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                afaFeltolt.Parameters.AddWithValue("@Kszamla", "467");
                afaFeltolt.Parameters.AddWithValue("@Tosszeg", 0);
                afaFeltolt.Parameters.AddWithValue("@Kosszeg", tetel.AfaSzamitas());
                afaFeltolt.Parameters.AddWithValue("@afakulcs", tetel.Afakulcs);
                afaFeltolt.ExecuteNonQuery();

                SqlCommand konyvFeltoltK = new SqlCommand(konyvelesK, connection);
                konyvFeltoltK.Parameters.AddWithValue("@partnerkod", tetel.Partnerkod);
                konyvFeltoltK.Parameters.AddWithValue("@szamlaszam", tetel.Szamlaszam);
                konyvFeltoltK.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                konyvFeltoltK.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                konyvFeltoltK.Parameters.AddWithValue("@Tosszeg", 0);
                konyvFeltoltK.Parameters.AddWithValue("@Kosszeg", tetel.KOsszeg);
                konyvFeltoltK.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                konyvFeltoltK.Parameters.AddWithValue("@fizetesi_mod", tetel.FizetesiMod.ToString());
                konyvFeltoltK.Parameters.AddWithValue("@teljesites", tetel.Teljesites);
                konyvFeltoltK.Parameters.AddWithValue("@afa_teljesites", tetel.AfaTeljesites);
                konyvFeltoltK.Parameters.AddWithValue("@kelt", tetel.SzamlaKelte);
                konyvFeltoltK.Parameters.AddWithValue("@esedekesseg", tetel.Esedekesseg);
                konyvFeltoltK.Parameters.AddWithValue("@konyveles_datuma", tetel.KonyvelesDatuma);
                konyvFeltoltK.Parameters.AddWithValue("@konyvelte", tetel.Konyvelte);
                konyvFeltoltK.Parameters.AddWithValue("@nyitott_vevo", false);
                konyvFeltoltK.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a VEVŐ tétel / ÁFA feltöltésénél! -> " + ex.Message);
            }

            connection.Close(); 
        }

        public static void UjSzallitoTetelFelvitele(string schema, Konyveles.KonyvelesiTetel tetel)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string konyvelesT = $"INSERT INTO {schema}.fokonyv(partnerkod, szamlaszam, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, fizetesimod, teljesites, afa_teljesites, kelt, esedekesseg, konyveles_datuma, konyvelte, nyitott_szallito, lezarva) VALUES(@partnerkod, @szamlaszam, @Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @fizetesi_mod, @teljesites, @afa_teljesites, @kelt, @esedekesseg, @konyveles_datuma, @konyvelte, @nyitott_szallito, 0)";

            string konyvelesK = $"INSERT INTO {schema}.fokonyv(partnerkod, szamlaszam, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, fizetesimod, teljesites, afa_teljesites, kelt, esedekesseg, konyveles_datuma, konyvelte, nyitott_szallito, lezarva) OUTPUT INSERTED.id VALUES(@partnerkod, @szamlaszam, @Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @fizetesi_mod, @teljesites, @afa_teljesites, @kelt, @esedekesseg, @konyveles_datuma, @konyvelte, @nyitott_szallito, 0)";

            string afa = $"INSERT INTO {schema}.afa(fokonyv_id, Tszamla, Kszamla, Tosszeg, Kosszeg, afakulcs) VALUES(@fokonyv_id, @Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @afakulcs)";

            try
            {
                SqlCommand konyvFeltoltK = new SqlCommand(konyvelesK, connection);
                konyvFeltoltK.Parameters.AddWithValue("@partnerkod", tetel.Partnerkod);
                konyvFeltoltK.Parameters.AddWithValue("@szamlaszam", tetel.Szamlaszam);
                konyvFeltoltK.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                konyvFeltoltK.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                konyvFeltoltK.Parameters.AddWithValue("@Tosszeg", 0);
                konyvFeltoltK.Parameters.AddWithValue("@Kosszeg", tetel.KOsszeg + tetel.AfaSzamitas());
                konyvFeltoltK.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                konyvFeltoltK.Parameters.AddWithValue("@fizetesi_mod", tetel.FizetesiMod.ToString());
                konyvFeltoltK.Parameters.AddWithValue("@teljesites", tetel.Teljesites);
                konyvFeltoltK.Parameters.AddWithValue("@afa_teljesites", tetel.AfaTeljesites);
                konyvFeltoltK.Parameters.AddWithValue("@kelt", tetel.SzamlaKelte);
                konyvFeltoltK.Parameters.AddWithValue("@esedekesseg", tetel.Esedekesseg);
                konyvFeltoltK.Parameters.AddWithValue("@konyveles_datuma", tetel.KonyvelesDatuma);
                konyvFeltoltK.Parameters.AddWithValue("@konyvelte", tetel.Konyvelte);
                konyvFeltoltK.Parameters.AddWithValue("@nyitott_szallito", true);

                tetel.Id = (int)konyvFeltoltK.ExecuteScalar();

                SqlCommand konyvFeltoltT = new SqlCommand(konyvelesT, connection);
                konyvFeltoltT.Parameters.AddWithValue("@partnerkod", tetel.Partnerkod);
                konyvFeltoltT.Parameters.AddWithValue("@szamlaszam", tetel.Szamlaszam);
                konyvFeltoltT.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                konyvFeltoltT.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                konyvFeltoltT.Parameters.AddWithValue("@Tosszeg", tetel.TOsszeg);
                konyvFeltoltT.Parameters.AddWithValue("@Kosszeg", 0);
                konyvFeltoltT.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                konyvFeltoltT.Parameters.AddWithValue("@fizetesi_mod", tetel.FizetesiMod.ToString());
                konyvFeltoltT.Parameters.AddWithValue("@teljesites", tetel.Teljesites);
                konyvFeltoltT.Parameters.AddWithValue("@afa_teljesites", tetel.AfaTeljesites);
                konyvFeltoltT.Parameters.AddWithValue("@kelt", tetel.SzamlaKelte);
                konyvFeltoltT.Parameters.AddWithValue("@esedekesseg", tetel.Esedekesseg);
                konyvFeltoltT.Parameters.AddWithValue("@konyveles_datuma", tetel.KonyvelesDatuma);
                konyvFeltoltT.Parameters.AddWithValue("@konyvelte", tetel.Konyvelte);
                konyvFeltoltT.Parameters.AddWithValue("@nyitott_szallito", false);
                konyvFeltoltT.ExecuteNonQuery();

                SqlCommand afaFeltolt = new SqlCommand(afa, connection);

                afaFeltolt.Parameters.AddWithValue("@fokonyv_id", tetel.Id);
                afaFeltolt.Parameters.AddWithValue("@Tszamla", "466");
                afaFeltolt.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                afaFeltolt.Parameters.AddWithValue("@Tosszeg", tetel.AfaSzamitas());
                afaFeltolt.Parameters.AddWithValue("@Kosszeg", 0);
                afaFeltolt.Parameters.AddWithValue("@afakulcs", tetel.Afakulcs);
                afaFeltolt.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a SZÁLLÍTÓ tétel / ÁFA feltöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void UjVegyesTetelFelvitele(string schema, Konyveles.KonyvelesiTetel tetel)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string konyvelesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, 0)";

            string konyvelesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, 0)";

            try
            {
                SqlCommand command = new SqlCommand(konyvelesT, connection);
                command.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                command.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                command.Parameters.AddWithValue("@Tosszeg", tetel.TOsszeg);
                command.Parameters.AddWithValue("@Kosszeg", 0);
                command.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                command.Parameters.AddWithValue("@teljesites", tetel.Teljesites);
                command.Parameters.AddWithValue("@konyveles_datuma", tetel.KonyvelesDatuma);
                command.Parameters.AddWithValue("@konyvelte", tetel.Konyvelte);

                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = konyvelesK;
                command.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                command.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                command.Parameters.AddWithValue("@Tosszeg", 0);
                command.Parameters.AddWithValue("@Kosszeg", tetel.KOsszeg);
                command.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                command.Parameters.AddWithValue("@teljesites", tetel.Teljesites);
                command.Parameters.AddWithValue("@konyveles_datuma", tetel.KonyvelesDatuma);
                command.Parameters.AddWithValue("@konyvelte", tetel.Konyvelte);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a VEGYES konyvelés feltöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void NyitottVevoLezaras(string schema, Konyveles.KonyvelesiTetel konyvelesiTetel)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string lezaras = $"UPDATE {schema}.fokonyv SET nyitott_vevo = 0 WHERE id = {konyvelesiTetel.Id}";

            string lezarasKonyveleseK = $"INSERT INTO {schema}.fokonyv(partnerkod, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@partnerkod, @Tszamla, @Kszamla, 0, @Kosszeg, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, 0)";

            string lezarasKonyveleseT = $"INSERT INTO {schema}.fokonyv(partnerkod, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@partnerkod, @Tszamla, @Kszamla, @Tosszeg, 0, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, 0)";

            try
            {
                SqlCommand lezar = new SqlCommand(lezaras, connection);
                lezar.ExecuteNonQuery();

                SqlCommand konyvelesK = new SqlCommand(lezarasKonyveleseK, connection);
                konyvelesK.Parameters.AddWithValue("@partnerkod", konyvelesiTetel.Partnerkod);
                konyvelesK.Parameters.AddWithValue("@Tszamla", konyvelesiTetel.TSzamla);
                konyvelesK.Parameters.AddWithValue("@Kszamla", konyvelesiTetel.KSzamla);
                //konyvelesK.Parameters.AddWithValue("@Tosszeg", konyvelesiTetel.TOsszeg);
                konyvelesK.Parameters.AddWithValue("@Kosszeg", konyvelesiTetel.KOsszeg);
                konyvelesK.Parameters.AddWithValue("@gazdasagi_esemeny", konyvelesiTetel.Gazdasagi_esemeny);
                konyvelesK.Parameters.AddWithValue("@teljesites", konyvelesiTetel.Teljesites);
                konyvelesK.Parameters.AddWithValue("@konyveles_datuma", konyvelesiTetel.KonyvelesDatuma);
                konyvelesK.Parameters.AddWithValue("@konyvelte", konyvelesiTetel.Konyvelte);

                konyvelesK.ExecuteNonQuery();

                SqlCommand konyvelesT = new SqlCommand(lezarasKonyveleseT, connection);
                konyvelesT.Parameters.AddWithValue("@partnerkod", konyvelesiTetel.Partnerkod);
                konyvelesT.Parameters.AddWithValue("@Tszamla", konyvelesiTetel.TSzamla);
                konyvelesT.Parameters.AddWithValue("@Kszamla", konyvelesiTetel.KSzamla);
                konyvelesT.Parameters.AddWithValue("@Tosszeg", konyvelesiTetel.TOsszeg);
                //konyvelesK.Parameters.AddWithValue("@Kosszeg", konyvelesiTetel.KOsszeg);
                konyvelesT.Parameters.AddWithValue("@gazdasagi_esemeny", konyvelesiTetel.Gazdasagi_esemeny);
                konyvelesT.Parameters.AddWithValue("@teljesites", konyvelesiTetel.Teljesites);
                konyvelesT.Parameters.AddWithValue("@konyveles_datuma", konyvelesiTetel.KonyvelesDatuma);
                konyvelesT.Parameters.AddWithValue("@konyvelte", konyvelesiTetel.Konyvelte);

                konyvelesT.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a vevő lezárásnál! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void NyitottSzallitoLezaras(string schema, Konyveles.KonyvelesiTetel konyvelesiTetel)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string lezaras = $"UPDATE {schema}.fokonyv SET nyitott_szallito = 0 WHERE id = {konyvelesiTetel.Id}";

            string lezarasKonyveleseT = $"INSERT INTO {schema}.fokonyv(partnerkod, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@partnerkod, @Tszamla, @Kszamla, @Tosszeg, 0, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, 0)";

            string lezarasKonyveleseK = $"INSERT INTO {schema}.fokonyv(partnerkod, Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@partnerkod, @Tszamla, @Kszamla, 0, @Kosszeg, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, 0)";

            try
            {
                SqlCommand lezar = new SqlCommand(lezaras, connection);
                lezar.ExecuteNonQuery();

                SqlCommand konyvelesT = new SqlCommand(lezarasKonyveleseT, connection);
                konyvelesT.Parameters.AddWithValue("@partnerkod", konyvelesiTetel.Partnerkod);
                konyvelesT.Parameters.AddWithValue("@Tszamla", konyvelesiTetel.TSzamla);
                konyvelesT.Parameters.AddWithValue("@Kszamla", konyvelesiTetel.KSzamla);
                konyvelesT.Parameters.AddWithValue("@Tosszeg", konyvelesiTetel.TOsszeg);
                //konyveles.Parameters.AddWithValue("@Kosszeg", konyvelesiTetel.KOsszeg);
                konyvelesT.Parameters.AddWithValue("@gazdasagi_esemeny", konyvelesiTetel.Gazdasagi_esemeny);
                konyvelesT.Parameters.AddWithValue("@teljesites", konyvelesiTetel.Teljesites);
                konyvelesT.Parameters.AddWithValue("@konyveles_datuma", konyvelesiTetel.KonyvelesDatuma);
                konyvelesT.Parameters.AddWithValue("@konyvelte", konyvelesiTetel.Konyvelte);

                konyvelesT.ExecuteNonQuery();

                SqlCommand konyvelesK = new SqlCommand(lezarasKonyveleseK, connection);
                konyvelesK.Parameters.AddWithValue("@partnerkod", konyvelesiTetel.Partnerkod);
                konyvelesK.Parameters.AddWithValue("@Tszamla", konyvelesiTetel.TSzamla);
                konyvelesK.Parameters.AddWithValue("@Kszamla", konyvelesiTetel.KSzamla);
                //konyvelesT.Parameters.AddWithValue("@Tosszeg", konyvelesiTetel.TOsszeg);
                konyvelesK.Parameters.AddWithValue("@Kosszeg", konyvelesiTetel.KOsszeg);
                konyvelesK.Parameters.AddWithValue("@gazdasagi_esemeny", konyvelesiTetel.Gazdasagi_esemeny);
                konyvelesK.Parameters.AddWithValue("@teljesites", konyvelesiTetel.Teljesites);
                konyvelesK.Parameters.AddWithValue("@konyveles_datuma", konyvelesiTetel.KonyvelesDatuma);
                konyvelesK.Parameters.AddWithValue("@konyvelte", konyvelesiTetel.Konyvelte);

                konyvelesK.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a vevő lezárásnál! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void EredmenyZaras(string schema)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            for (int i = 5; i <= 9; i++)
            {
                List<Konyveles.KonyvelesiTetel> tetelek = AdatbazisMuveletek.Lekerdezesek.KivonatLekeres(Convert.ToInt32(schema.Substring(schema.Length - 4, 4)), schema, 0, 12, i.ToString());

                foreach (var tetel in tetelek)
                {
                    double egyenleg = Math.Floor(tetel.TOsszeg - tetel.KOsszeg);
                    string feltoltesT = "";
                    string feltoltesK = "";

                    if (egyenleg >= 0)
                    {
                        feltoltesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES ('493', @szamla, 0, @egyenleg, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                        feltoltesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES ('493', @szamla, @egyenleg, 0, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                    }
                    else
                    {
                        feltoltesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES (@szamla, '493', @egyenleg, 0, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                        feltoltesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES (@szamla, '493', 0, @egyenleg, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                    }

                    try
                    {
                        SqlCommand cmd = new SqlCommand(feltoltesT, connection);
                        cmd.Parameters.AddWithValue("@szamla", tetel.TSzamla);
                        cmd.Parameters.AddWithValue("@egyenleg", Math.Abs(egyenleg));
                        cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                        cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        cmd.CommandText = feltoltesK;
                        cmd.Parameters.AddWithValue("@szamla", tetel.TSzamla);
                        cmd.Parameters.AddWithValue("@egyenleg", Math.Abs(egyenleg));
                        cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                        cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);

                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Hiba a záró tételek feltöltésénél! -> " + ex.Message);
                    }
                }
                AdatbazisMuveletek.Lekerdezesek.KivonatTorles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            }

            connection.Close();
        }

        public static void EredmenyKonyveles(string schema)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            int eredmeny = AdatbazisMuveletek.Lekerdezesek.EredmenyLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            string konyvelesT = "";
            string konyvelesK = "";

            if (eredmeny <= 0)
            {
                konyvelesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(" +
                $"'493'," +
                $"'419'," +
                $"{Math.Abs(eredmeny)}," +
                $"0," +
                $"'Adózott eredmény könyvelése'," +
                $"@teljesites," +
                $"@konyveles_datuma," +
                $"@konyvelte," +
                $"0" +
                $")";

                konyvelesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(" +
                $"'493'," +
                $"'419'," +
                $"0," +
                $"{Math.Abs(eredmeny)}," +
                $"'Adózott eredmény könyvelése'," +
                $"@teljesites," +
                $"@konyveles_datuma," +
                $"@konyvelte," +
                $"0" +
                $")";
            }
            else
            {
                konyvelesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(" +
                $"'419'," +
                $"'493'," +
                $"{Math.Abs(eredmeny)}," +
                $"0," +
                $"'Adózott eredmény könyvelése'," +
                $"@teljesites," +
                $"@konyveles_datuma," +
                $"@konyvelte," +
                $"0" +
                $")";

                konyvelesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(" +
                $"'419'," +
                $"'493'," +
                $"0," +
                $"{Math.Abs(eredmeny)}," +
                $"'Adózott eredmény könyvelése'," +
                $"@teljesites," +
                $"@konyveles_datuma," +
                $"@konyvelte," +
                $"0" +
                $")";
            }

            try
            {
                SqlCommand cmd = new SqlCommand(konyvelesT, connection);
                cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = konyvelesK;
                cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az adótott eredmény könyvelésénél! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void MerlegZaras(string schema)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            for (int i = 1; i <= 4; i++)
            {
                List<Konyveles.KonyvelesiTetel> tetelek = AdatbazisMuveletek.Lekerdezesek.KivonatLekeres(Convert.ToInt32(schema.Substring(schema.Length - 4, 4)), schema, 0, 12, i.ToString());

                foreach (var tetel in tetelek)
                {
                    if (!tetel.TSzamla.Equals("491") || !tetel.TSzamla.Equals("493"))
                    {
                        double egyenleg = Math.Floor(tetel.TOsszeg - tetel.KOsszeg);
                        string feltoltesT = "";
                        string feltoltesK = "";

                        if (egyenleg >= 0)
                        {
                            feltoltesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES ('492', @szamla, 0, @egyenleg, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                            feltoltesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES ('492', @szamla, @egyenleg, 0, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                        }
                        else
                        {
                            feltoltesT = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES (@szamla, '492', @egyenleg, 0, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                            feltoltesK = $"INSERT INTO {schema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES (@szamla, '492', 0, @egyenleg, 'Számla zárás', @teljesites, @konyveles_datuma, @konyvelte, 1)";
                        }

                        try
                        {
                            SqlCommand cmd = new SqlCommand(feltoltesT, connection);
                            cmd.Parameters.AddWithValue("@szamla", tetel.TSzamla);
                            cmd.Parameters.AddWithValue("@egyenleg", Math.Abs(egyenleg));
                            cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                            cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                            cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);

                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();

                            cmd.CommandText = feltoltesK;
                            cmd.Parameters.AddWithValue("@szamla", tetel.TSzamla);
                            cmd.Parameters.AddWithValue("@egyenleg", Math.Abs(egyenleg));
                            cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                            cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                            cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);

                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hiba a záró tételek feltöltésénél! -> " + ex.Message);
                        } 
                    }
                }
                AdatbazisMuveletek.Lekerdezesek.KivonatTorles(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);
            }

            connection.Close();
        }

        public static void EvLezarasa(string schema)
        {
            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            string zaras = $"UPDATE lezart_schemak SET lezarva = 1 WHERE schema_neve = '{schema}'";

            try
            {
                SqlCommand cmd = new SqlCommand(zaras, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("A schema lezárása nem sikerült! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void ZarasVisszavonasa(string schema)
        {
            connection = AdatbazisKapcsolodas.Kapcsolodas();

            connection.Open();

            string visszavonas = $"UPDATE {schema}.fokonyv SET Tosszeg = 0, Kosszeg = 0 WHERE lezarva = 1";
            string lezaras_visszavonas = $"UPDATE lezart_schemak SET lezarva = 0 WHERE schema_neve = '{schema}'";

            try
            {
                SqlCommand command = new SqlCommand(visszavonas, connection);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = lezaras_visszavonas;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba a zárás visszavonásánál! -> " + ex.Message);
            }

            connection.Close();
        }

        public static void Nyitas(string schema)
        {
            string ujEvSchema = schema.Replace(schema.Substring(schema.Length - 4, 4), (Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) + 1).ToString());

            connection = AdatbazisMuveletek.AdatbazisKapcsolodas.Kapcsolodas();
            connection.Open();

            AdatbazisMuveletek.Createek.UjEvLetrehozas(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            List<Konyveles.KonyvelesiTetel> zartTetelek = AdatbazisMuveletek.Lekerdezesek.LezartMerlegSzamlak(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis);

            foreach (var tetel in zartTetelek)
            {
                string puffer = tetel.TSzamla;
                tetel.TSzamla = tetel.KSzamla;
                tetel.KSzamla = puffer;

                if (tetel.TSzamla == "492")
                {
                    tetel.TSzamla = "491";
                }
                else if (tetel.KSzamla == "492")
                {
                    tetel.KSzamla = "491";
                }

                if (tetel.TSzamla != "493" || tetel.KSzamla != "493")
                {
                    string feltoltes = $"INSERT INTO {ujEvSchema}.fokonyv(Tszamla, Kszamla, Tosszeg, Kosszeg, gazdasagi_esemeny, teljesites, konyveles_datuma, konyvelte, lezarva) VALUES(@Tszamla, @Kszamla, @Tosszeg, @Kosszeg, @gazdasagi_esemeny, @teljesites, @konyveles_datuma, @konyvelte, @lezarva);";
                    SqlCommand cmd = new SqlCommand(feltoltes, connection);
                    cmd.Parameters.AddWithValue("@Tszamla", tetel.TSzamla);
                    cmd.Parameters.AddWithValue("@Kszamla", tetel.KSzamla);
                    cmd.Parameters.AddWithValue("@Tosszeg", tetel.TOsszeg);
                    cmd.Parameters.AddWithValue("@Kosszeg", tetel.KOsszeg);
                    cmd.Parameters.AddWithValue("@gazdasagi_esemeny", tetel.Gazdasagi_esemeny);
                    cmd.Parameters.AddWithValue("@teljesites", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@konyveles_datuma", DateTime.Now);
                    cmd.Parameters.AddWithValue("@konyvelte", BejelentkezesFrm.Felhasznalo.Felhasznalonev);
                    cmd.Parameters.AddWithValue("@lezarva", 0);
                    cmd.ExecuteNonQuery();
                }
            }

            string attoltes = $"INSERT INTO {ujEvSchema}.fokonyv SELECT * FROM {schema}.fokonyv WHERE YEAR('teljesites') = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) + 1};" +
                $"DELETE FROM {schema}.fokonyv WHERE YEAR('teljesites') = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) + 1};" +
                $"INSERT INTO {ujEvSchema}.afa(fokonyv_id, Tszamla, Kszamla, Tosszeg, Kosszeg, afakulcs) SELECT {schema}.fokonyv.id AS 'fokonyv_id', {schema}.afa.Tszamla, {schema}.afa.Kszamla, {schema}.fokonyv.Tosszeg, {schema}.afa.Kosszeg, {schema}.afa.afakulcs FROM {schema}.afa FULL JOIN {schema}.fokonyv ON {schema}.fokonyv.id = {schema}.afa.fokonyv_id WHERE YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) + 1} AND {schema}.afa.afakulcs IS NOT NULL;" +
                $"DELETE FROM {schema}.afa INNER JOIN {schema}.fokonyv ON {schema}.fokonyv.id = {schema}.afa.fokonyv_id WHERE YEAR({schema}.fokonyv.teljesites) = {Convert.ToInt32(schema.Substring(schema.Length - 4, 4)) + 1};";

            try
            {
                SqlCommand cmd = new SqlCommand(attoltes, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az újévi könyvelt adatok áttöltésénél! -> " + ex.Message);
            }

            connection.Close();
        }
    }
}
