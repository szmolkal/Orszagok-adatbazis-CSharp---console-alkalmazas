using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Orszagok_adatbazis_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost"; // 127.0.0.1
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "orszagok";
            //sb.CharacterSet = "latin2_hungarian_ci";
            MySqlConnection connection = new MySqlConnection(sb.ToString());
            try
            {
                MySqlCommand sql = connection.CreateCommand();
                sql.CommandText = "SELECT `orszag`, `nepesseg`, `terulet` FROM `orszagok`";
                connection.Open();
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string orszag = dr.GetString("orszag");
                        int nepesseg = dr.GetInt32("nepesseg");
                        double terulet = dr.GetDouble("terulet");
                        Console.WriteLine($"{orszag}; {nepesseg}; {terulet.ToString("0.00")}");
                    }
                    dr.Close();
                } //
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);                
            }
            connection.Close();
            Console.WriteLine("\nA program vége.");
            Console.WriteLine(connection.ToString());
            Console.ReadLine();
        }
    }
}
