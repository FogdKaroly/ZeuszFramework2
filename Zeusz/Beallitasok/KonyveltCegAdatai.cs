using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz
{
    internal class KonyveltCegAdatai : KonyvelocegAdatai
    {
        bool osszkoltseg;
        bool forgalmikoltseg;
        
        public bool Osszkoltseg { get => osszkoltseg; set => osszkoltseg = value; }
        public bool Forgalmikoltseg { get => forgalmikoltseg; set => forgalmikoltseg = value; }

        public KonyveltCegAdatai(bool osszkoltseg, bool forgalmikoltseg, string cegnev, string bankszamlaszam2, string bankszamlaszam3, string rovidCegnev, string iranyitoszam, string varos, string kozteruletNeve, KozteruletJellege kozteruletJellege, string hazszam, string lepcsohaz, string ajto, string adoszam, string euAdoszam, string cegjegyzekszam, string bankszamlaszam, string email, string telefon) : base(cegnev, bankszamlaszam2, bankszamlaszam3, rovidCegnev, iranyitoszam, varos, kozteruletNeve, kozteruletJellege, hazszam, lepcsohaz, ajto, adoszam, euAdoszam, cegjegyzekszam, bankszamlaszam, email, telefon)
        {
            Osszkoltseg = osszkoltseg;
            Forgalmikoltseg = forgalmikoltseg;
        }
    }
}
