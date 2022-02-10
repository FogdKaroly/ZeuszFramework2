using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz.Beallitasok
{
    internal class BeszamoloSor
    {
        string sorszam;
        string megnevezes;

        public string Sorszam { get => sorszam; set => sorszam = value; }
        public string Megnevezes { get => megnevezes; set => megnevezes = value; }

        public BeszamoloSor(string sorszam, string megnevezes)
        {
            Sorszam = sorszam;
            Megnevezes = megnevezes;
        }

        public override string ToString()
        {
            return $"{sorszam} - {megnevezes}";
        }
    }
}
