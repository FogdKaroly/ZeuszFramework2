using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz
{
    internal class PartnercegAdatai : Cegadat
    {
        int partnerkod;
        string szamlazasiNev;
        string szallitasiIranyitoszam;
        string szallitasiVaros;
        string szallitasiKozteruletNeve;
        KozteruletJellege szallitasiKozteruletJellege;
        string szallitasiHazszam;
        string szallitasiLepcsohaz;
        string szallitasiAjto;

        public int Partnerkod 
        { 
            get => partnerkod; 
            set
            {
                partnerkod = value;
            }
        }
        public string SzamlazasiNev
        {
            get => szamlazasiNev;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szamlazasiNev = value;
                }
                else
                {
                    throw new ArgumentException("A számlázási név mező kitöltése kötelező!");
                }
            }
        }
        public string SzallitasiIranyitoszam 
        { 
            get => szallitasiIranyitoszam; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szallitasiIranyitoszam = value;
                }
                else
                {
                    throw new ArgumentException("Az szállítási cím irányítószám kitöltése kötelező!");
                }
            }
        }
        public string SzallitasiVaros 
        { 
            get => szallitasiVaros;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szallitasiVaros = value;
                }
                else
                {
                    throw new ArgumentException("A szállítási cím városa kötelezően kitöltendő!");
                }
            }
        }
        public string SzallitasiKozteruletNeve 
        { 
            get => szallitasiKozteruletNeve;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szallitasiKozteruletNeve = value;
                }
                else
                {
                    throw new ArgumentException("A szállítási cím közterület neve kötelezően kitöltendő!");
                }
            }
        }
        public string SzallitasiHazszam 
        {
            get => szallitasiHazszam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szallitasiHazszam = value;
                }
                else
                {
                    throw new ArgumentException("A szállítási cím házszáma köztelező!");
                }
            }
        }
        public string SzallitasiLepcsohaz { get => szallitasiLepcsohaz; set => szallitasiLepcsohaz = value; }
        public string SzallitasiAjto { get => szallitasiAjto; set => szallitasiAjto = value; }
        internal KozteruletJellege SzallitasiKozteruletJellege { get => szallitasiKozteruletJellege; set => szallitasiKozteruletJellege = value; }

        public PartnercegAdatai(int partnerkod, string szamlazasiNev, string szallitasiIranyitoszam, string szallitasiVaros, string szallitasiKozteruletNeve, string szallitasiHazszam, string szallitasiLepcsohaz, string szallitasiAjto, KozteruletJellege szallitasiKozteruletJellege, string rovidCegnev, string iranyitoszam, string varos, string kozteruletNeve, KozteruletJellege kozteruletJellege, string hazszam, string lepcsohaz, string ajto, string adoszam, string euAdoszam, string cegjegyzekszam, string bankszamlaszam, string email, string telefon) : base(rovidCegnev, iranyitoszam, varos, kozteruletNeve, kozteruletJellege, hazszam, lepcsohaz, ajto, adoszam, euAdoszam, cegjegyzekszam, bankszamlaszam, email, telefon)
        {
            Partnerkod = partnerkod;
            SzamlazasiNev = szamlazasiNev;
            SzallitasiIranyitoszam = szallitasiIranyitoszam;
            SzallitasiVaros = szallitasiVaros;
            SzallitasiKozteruletNeve = szallitasiKozteruletNeve;
            SzallitasiHazszam = szallitasiHazszam;
            SzallitasiLepcsohaz = szallitasiLepcsohaz;
            SzallitasiAjto = szallitasiAjto;
            SzallitasiKozteruletJellege = szallitasiKozteruletJellege;
        }

        public override string ToString()
        {
            return RovidCegnev + " (" + partnerkod + ")";
        }
    }
}
