using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace fantasyanalizisdoga
{
    public class SzornyAdatbazis
    {
        private readonly string connectionString;
        
        public SzornyAdatbazis(string connectionString)
        {
            this.connectionString = "server=localhost; database=fantasybestariumdb; uid=root; password=";
            {
                List<Szorny> szornyek = new List<Szorny>();

                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM szornyek", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("nev");
                                int veszelyessegiSzint = reader.GetInt32("veszelyessegi_szint");
                                string elohely = reader.GetString("elohely");
                                string foGyengeseg = reader.GetString("fo_gyengeseg");
                                string leggyakoribbZsakmany = reader.GetString("leggyakoribb_zsakmany");
                                bool veszelyesE = reader.GetBoolean("veszelyes_e");
                                Szorny szorny = new Szorny(id, nev, veszelyessegiSzint, elohely, foGyengeseg, leggyakoribbZsakmany, veszelyesE);
                                szornyek.Add(szorny);
                            }
                        }
                    }
                }
            }
        }
    }
}
