using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeusz.AdatbazisMuveletek
{
    internal static class AdatbazisKapcsolodas
    {
        /*
        public static SqlConnection Kapcsolodas(string adatbazis)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = @"fogdkaroly\SQLEXPRESS";
            stringBuilder.InitialCatalog = adatbazis;
            stringBuilder.IntegratedSecurity = true;

            string connectionString = stringBuilder.ToString();

            try
            {
                return new SqlConnection(connectionString);
                //connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az adatbázishoz kapcsolódás közben! -> " + ex.Message);
            }
        }
        */

        public static SqlConnection Kapcsolodas()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = @"fogdkaroly\SQLEXPRESS";
            stringBuilder.InitialCatalog = "zeusz";
            stringBuilder.IntegratedSecurity = true;

            string connectionString = stringBuilder.ToString();

            try
            {
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Hiba az adatbázishoz kapcsolódás közben! -> " + ex.Message);
            }
        }

        
    }
}
