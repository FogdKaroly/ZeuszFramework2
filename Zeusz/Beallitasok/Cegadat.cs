using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz
{
    enum KozteruletJellege
    {
        árok,
        dűlő,
        fasor,
        körönd,
        körtér,
        körút,
        köz,
        park,
        sétány,
        sor,
        tér,
        tere,
        út,
        utca
    }

    abstract class Cegadat
    {
        string rovidCegnev;
        string iranyitoszam;
        string varos;
        string kozteruletNeve;
        KozteruletJellege kozteruletJellege;
        string hazszam;
        string lepcsohaz;
        string ajto;
        string adoszam;
        string euAdoszam;
        string cegjegyzekszam;
        string bankszamlaszam;
        string email;
        string telefon;

        public string RovidCegnev
        {
            get => rovidCegnev;
            set => rovidCegnev = value;
        }
        public string Iranyitoszam
        {
            get => iranyitoszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    iranyitoszam = value;
                }
                else
                {
                    throw new ArgumentException("Az irányítószám kitöltése kötelező!");
                }
            }
        }
        public string Varos
        {
            get => varos;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    varos = value;
                }
                else
                {
                    throw new ArgumentException("A város kitöltése kötelező!");
                }
            }
        }
        public string KozteruletNeve
        {
            get => kozteruletNeve;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    kozteruletNeve = value;
                }
                else
                {
                    throw new ArgumentException("A közterület nevének kitöltése kötelező!");
                }
            }
        }
        public KozteruletJellege KozteruletJellege
        {
            get => kozteruletJellege;
            set
            {
                kozteruletJellege = value;
            }
        }
        public string Hazszam
        {
            get => hazszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    hazszam = value;
                }
                else
                {
                    throw new ArgumentException("A házszám mező kitöltése kötelező!");
                }
            }
        }
        public string Lepcsohaz { get => lepcsohaz; set => lepcsohaz = value; }
        public string Ajto { get => ajto; set => ajto = value; }
        public string Adoszam
        {
            get => adoszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    adoszam = value;
                }
                else
                {
                    throw new ArgumentException("Az adószám kitöltése kötelező!");
                }
            }
        }
        public string EuAdoszam { get => euAdoszam; set => euAdoszam = value; }
        public string Cegjegyzekszam
        {
            get => cegjegyzekszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    cegjegyzekszam = value;
                }
                else
                {
                    throw new ArgumentException("A cégjegyzékszám kitöltése kötelező!");
                }
            }
        }
        public string Bankszamlaszam
        {
            get => bankszamlaszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    bankszamlaszam = value;
                }
                else
                {
                    throw new ArgumentException("Az első bankszámlaszám kitöltése kötelező!");
                }
            }
        }
        public string Email { get => email; set => email = value; }
        public string Telefon { get => telefon; set => telefon = value; }

        protected Cegadat(string rovidCegnev, string iranyitoszam, string varos, string kozteruletNeve, KozteruletJellege kozteruletJellege, string hazszam, string lepcsohaz, string ajto, string adoszam, string euAdoszam, string cegjegyzekszam, string bankszamlaszam, string email, string telefon)
        {
            RovidCegnev = rovidCegnev;
            Iranyitoszam = iranyitoszam;
            Varos = varos;
            KozteruletNeve = kozteruletNeve;
            KozteruletJellege = kozteruletJellege;
            Hazszam = hazszam;
            Lepcsohaz = lepcsohaz;
            Ajto = ajto;
            Adoszam = adoszam;
            EuAdoszam = euAdoszam;
            Cegjegyzekszam = cegjegyzekszam;
            Bankszamlaszam = bankszamlaszam;
            Email = email;
            Telefon = telefon;
        }
    }
}
