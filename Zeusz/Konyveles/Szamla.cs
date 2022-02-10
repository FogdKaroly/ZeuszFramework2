using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz.Konyveles
{
    internal class Szamla
    {
        string szamlaszam;
        string szamlaNeve;
        string kapcsolodikIde;
        bool konyvelheto;
        string helyeABeszamoloban;

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
                    throw new ArgumentException("A számlaszám kitöltése kötelező");
                }
            }
        }
        public string SzamlaNeve 
        { 
            get => szamlaNeve; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    szamlaNeve = value;
                }
                else
                {
                    throw new ArgumentException("A számla nevének kitöltése kötelező!");
                }
            }
        }
        public string KapcsolodikIde
        { 
            get => kapcsolodikIde; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    kapcsolodikIde = value;
                }
                else
                {
                    throw new ArgumentException("A kapcsolódó számlát kötelező megadni!");
                }
            }
        }
        public bool Konyvelheto { get => konyvelheto; set => konyvelheto = value; }
        public string HelyeABeszamoloban 
        {
            get => helyeABeszamoloban;
            set
            {
                helyeABeszamoloban = value;
            }
        }

        public Szamla(string szamlaszam, string szamlaNeve, string kapcsolodikIde, bool konyvelheto, string helyeABeszamoloban)
        {
            Szamlaszam = szamlaszam;
            SzamlaNeve = szamlaNeve;
            KapcsolodikIde = kapcsolodikIde;
            Konyvelheto = konyvelheto;
            HelyeABeszamoloban = helyeABeszamoloban;
        }

        public override string ToString()
        {
            return $"{szamlaszam} - {szamlaNeve}";
        }
    }
}
