using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Konyveles
{
    enum FizetesiMod
    {
        Átutalás,
        Készpénz,
        Előreutalás
    }
    internal class KonyvelesiTetel
    {
        int ? id;
        string partnerkod;
        string szamlaszam;
        string tSzamla;
        string kSzamla;
        double tOsszeg;
        double kOsszeg;
        string gazdasagi_esemeny;
        FizetesiMod fizetesiMod;
        double afakulcs;
        DateTime teljesites;
        DateTime afaTeljesites;
        DateTime szamlaKelte;
        DateTime esedekesseg;
        DateTime konyvelesDatuma;
        string konyvelte;
        int honap;
        string szamlaNeve;

        public int? Id { get => id; set => id = value; }
        public string Partnerkod 
        {
            get => partnerkod;
            set
            {
                partnerkod = value;
            }
        }
        public string Szamlaszam 
        { 
            get => szamlaszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szamlaszam = value;
                }
                else
                {
                    throw new ArgumentException("A számlaszám kitöltése kötelező!");
                }
            }
        }
        public string TSzamla 
        {
            get => tSzamla;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tSzamla = value;
                }
                else
                {
                    throw new ArgumentException("Kérem válasszon Tartozik számlát!");
                }
            }
        }
        public string KSzamla 
        { 
            get => kSzamla;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    kSzamla = value;
                }
                else
                {
                    throw new ArgumentException("Kérem válasszon Követel számlát!");
                }
            }
        }
        public double TOsszeg 
        { 
            get => tOsszeg;
            set
            {
                tOsszeg = value;
            }
        }
        public double KOsszeg { get => kOsszeg; set => kOsszeg = value; }
        public string Gazdasagi_esemeny
        {
            get => gazdasagi_esemeny;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    gazdasagi_esemeny = value;
                }
                else
                {
                    throw new ArgumentException("A gazdasági esemény kitöltése kötelező!");
                }
            }
        }
        public FizetesiMod FizetesiMod 
        { 
            get => fizetesiMod;
            set
            {
                fizetesiMod = value;
            }
        }
        public double Afakulcs 
        { 
            get => afakulcs; 
            set => afakulcs = value;
        }
        public DateTime Teljesites 
        { 
            get => teljesites;
            set
            {
                teljesites = value;
            }
        }
        public DateTime AfaTeljesites 
        { 
            get => afaTeljesites; 
            set
            {
                afaTeljesites = value;
            }
        }
        public DateTime SzamlaKelte 
        { 
            get => szamlaKelte;
            set
            {
                if (value <= DateTime.Now)
                {
                    szamlaKelte = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("A számla kelte nem lehet jövőbeli dátum!");
                }
            }
        }
        public DateTime Esedekesseg { get => esedekesseg; set => esedekesseg = value; }
        public DateTime KonyvelesDatuma { get => konyvelesDatuma; set => konyvelesDatuma = value; }
        public string Konyvelte { get => konyvelte; set => konyvelte = value; }
        public int Honap { get => honap; set => honap = value; }
        public string SzamlaNeve { get => szamlaNeve; set => szamlaNeve = value; }

        public KonyvelesiTetel(int? id, string partnerkod, string szamlaszam, string tSzamla, string kSzamla, double tOsszeg, double kOsszeg, string gazdasagi_esemeny, FizetesiMod fizetesiMod, double afakulcs, DateTime teljesites, DateTime afaTeljesites, DateTime szamlaKelte, DateTime esedekesseg, DateTime konyvelesDatuma, string konyvelte)
        {
            Id = id;
            Partnerkod = partnerkod;
            Szamlaszam = szamlaszam;
            TSzamla = tSzamla;
            KSzamla = kSzamla;
            TOsszeg = tOsszeg;
            KOsszeg = kOsszeg;
            Gazdasagi_esemeny = gazdasagi_esemeny;
            FizetesiMod = fizetesiMod;
            Afakulcs = afakulcs;
            Teljesites = teljesites;
            AfaTeljesites = afaTeljesites;
            SzamlaKelte = szamlaKelte;
            Esedekesseg = esedekesseg;
            KonyvelesDatuma = konyvelesDatuma;
            Konyvelte = konyvelte;
        }

        public KonyvelesiTetel(int? id, string tSzamla, string kSzamla, double tOsszeg, double kOsszeg, string gazdasagiEsemeny, DateTime teljesites, DateTime konyvelesDatuma, string konyvelte)
        {
            Id = id;
            Partnerkod = partnerkod;
            TSzamla = tSzamla;
            KSzamla = kSzamla;
            TOsszeg = tOsszeg;
            KOsszeg = kOsszeg;
            Gazdasagi_esemeny = gazdasagiEsemeny;
            Teljesites = teljesites;
            KonyvelesDatuma = konyvelesDatuma;
            Konyvelte = konyvelte;
        }

        public KonyvelesiTetel(int? id, string partnerkod, string szamlaszam, string tSzamla, string kSzamla, double tOsszeg, double kOsszeg, string gazdasagiEsemeny, DateTime teljesites, DateTime konyvelesDatuma, string konyvelte)
        {
            Id = id;
            Partnerkod = partnerkod;
            Szamlaszam = szamlaszam;
            TSzamla = tSzamla;
            KSzamla = kSzamla;
            TOsszeg = tOsszeg;
            KOsszeg = kOsszeg;
            Gazdasagi_esemeny = gazdasagiEsemeny;
            Teljesites = teljesites;
            KonyvelesDatuma = konyvelesDatuma;
            Konyvelte = konyvelte;
        }

        public KonyvelesiTetel(string tSzamla, double tOsszeg, double kOsszeg)
        {
            TSzamla = tSzamla;
            TOsszeg = tOsszeg;
            KOsszeg = kOsszeg;
        }

        public KonyvelesiTetel(int honap, DateTime teljesites, string tSzamla, string ellenszamla, double tOsszeg, double kOsszeg, string gazdasagiEsemeny)
        {
            Honap = honap;
            Teljesites = teljesites;
            TSzamla = tSzamla;
            KSzamla = ellenszamla;
            TOsszeg = tOsszeg;
            KOsszeg= kOsszeg;
            Gazdasagi_esemeny = gazdasagiEsemeny;
        }

        public KonyvelesiTetel(int honap, double afakulcs, double afa_osszeg, string szamlaszam, string partnerkod, DateTime afaTeljesites, double nettoOsszeg)
        {
            Honap= honap;
            Afakulcs = afakulcs;
            AfaSzamitas();
            Szamlaszam = szamlaszam;
            Partnerkod = partnerkod;
            AfaTeljesites = afaTeljesites;
            TOsszeg = nettoOsszeg;
        }

        public double AfaSzamitas()
        {
            return tOsszeg * (afakulcs / 100);
        }

        public override string ToString()
        {
            return $"{AdatbazisMuveletek.Lekerdezesek.PartnerNevLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, partnerkod)} - {szamlaszam} - {gazdasagi_esemeny} - {AdatbazisMuveletek.Lekerdezesek.NyitottOsszegLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, id)} Ft - {esedekesseg.ToShortDateString()}";
        }
    }
}
