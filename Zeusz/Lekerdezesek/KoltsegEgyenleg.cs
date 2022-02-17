using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz.Lekerdezesek
{
    internal class KoltsegEgyenleg
    {
        string fokonyviSzam;
        double egyenleg;
        int honap;

        public string FokonyviSzam { get => fokonyviSzam; set => fokonyviSzam = value; }
        public double Egyenleg { get => egyenleg; set => egyenleg = value; }
        public int Honap { get => honap; set => honap = value; }

        public KoltsegEgyenleg(string fokonyviSzam, double egyenleg)
        {
            FokonyviSzam = fokonyviSzam;
            Egyenleg = egyenleg;
        }

        public KoltsegEgyenleg(string fokonyviSzam, double egyenleg, int honap)
        {
            FokonyviSzam = fokonyviSzam;
            Egyenleg = egyenleg;
            Honap = honap;
        }
    }
}
