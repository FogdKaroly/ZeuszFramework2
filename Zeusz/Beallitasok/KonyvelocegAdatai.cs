using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz
{
    internal class KonyvelocegAdatai : Cegadat
    {
        string cegnev;
        string bankszamlaszam2;
        string bankszamlaszam3;

        public string Cegnev 
        {
            get => cegnev;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    cegnev = value;
                }
                else
                {
                    throw new ArgumentException("A teljes cégnév nem lehet üres!");
                }
            }
        }
        public string Bankszamlaszam2 { get => bankszamlaszam2; set => bankszamlaszam2 = value; }
        public string Bankszamlaszam3 { get => bankszamlaszam3; set => bankszamlaszam3 = value; }

        public KonyvelocegAdatai(string cegnev, string bankszamlaszam2, string bankszamlaszam3, string rovidCegnev, string iranyitoszam, string varos, string kozteruletNeve, KozteruletJellege kozteruletJellege, string hazszam, string lepcsohaz, string ajto, string adoszam, string euAdoszam, string cegjegyzekszam, string bankszamlaszam, string email, string telefon) : base(rovidCegnev, iranyitoszam, varos, kozteruletNeve, kozteruletJellege, hazszam, lepcsohaz, ajto, adoszam, euAdoszam, cegjegyzekszam, bankszamlaszam, email, telefon)
        {
            Cegnev = cegnev;
            Bankszamlaszam2 = bankszamlaszam2;
            Bankszamlaszam3 = bankszamlaszam3;
        }
    }
}
