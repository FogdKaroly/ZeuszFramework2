using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz
{
    internal class Jogosultsag
    {
        string felhasznalonev;
        Dictionary<string, byte> jogosultsagok;

        public string Felhasznalonev 
        { 
            get => felhasznalonev; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    felhasznalonev = value;
                }
                else
                {
                    throw new ArgumentException("A felhasználónév mező nem lehet üres!");
                }
            }
        }
        
        public Dictionary<string, byte> Jogosultsagok { get => jogosultsagok; }
        

        public Jogosultsag(string felhasznalonev, Dictionary<string, byte> jogosultsagok)
        {
            Felhasznalonev = felhasznalonev;
            this.jogosultsagok = jogosultsagok;
        }
    }
}
