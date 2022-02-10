using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz
{
    internal class Felhasznalo
    {
        string felhasznalonev;
        string jelszo;
        string beosztas;
        string email;

        public string Felhasznalonev 
        { 
            get => felhasznalonev; 
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    felhasznalonev = value;
                }
                else
                {
                    throw new ArgumentException("A felhasználónév kitöltése kötelező!");
                }
            }
        }
        public string Jelszo
        {
            get => jelszo;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    jelszo = value;
                }
                else
                {
                    throw new ArgumentException("A jelszó kitöltése kötelező!");
                }
            }
        }
        public string Beosztas
        { 
            get => beosztas; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    beosztas = value;
                }
                else
                {
                    throw new ArgumentException("A beosztás kitöltése kötelező!");
                }
            } 
        }
        public string Email { get => email; set => email = value; }

        public Felhasznalo(string felhasznalonev, string jelszo, string beosztas, string email)
        {
            Felhasznalonev = felhasznalonev;
            Jelszo = jelszo;
            Beosztas = beosztas;
            Email = email;
        }
    }
}
