using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz.AdatbazisMuveletek
{
    static class AktualisAdatbazis
    {
        static string kivalasztottSema;

        public static string KivalasztottAdatbazis
        {
            get => kivalasztottSema;
            set => kivalasztottSema = value;
        }
    }
}
