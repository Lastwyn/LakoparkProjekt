using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LakoparkProjekt
{
    internal class Database
    {
        static public MySqlCommand command;
        static public MySqlConnection connection;

        public Database(string server = "localhost", string user = "root", string password = "", string db = "lakopark")
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Password = password;
            builder.Database = db;
            connection = new MySqlConnection(builder.ConnectionString);
            if (Kapcsolatok())
            {
                command = connection.CreateCommand();
            }
        }
        private bool Kapcsolatok()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public HappyLiving getAllLakopark()
        {
            HappyLiving HL = new HappyLiving(new List<Lakopark>());
            command.CommandText = "SELECT * FROM adatok;";
            connection.Open();
            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int[] kette = Array.ConvertAll(dr.GetString("dimenzio").Split(';'), int.Parse);
                    string[] haz = dr.GetString("hazak").Split(';');
                    int[,] hazak = new int[kette[0],kette[1]];
                    foreach (string h in haz)
                    {
                        int[] haram = Array.ConvertAll(h.Split(','), int.Parse);
                        hazak[haram[0]-1, haram[1]-1] = haram[2];
                    }
                    Lakopark lakopark = new Lakopark(hazak, kette[0], dr.GetString("nev"), kette[1]);
                    HL.Lakoparkok.Add(lakopark);
                }
            }
            connection.Close();
            return HL;
        }
        public bool mentes(HappyLiving happy) {
            foreach (Lakopark item in happy.Lakoparkok)
            {
                string tarol = "";
                for (int i = 0; i < item.Hazak.GetLength(0); i++)
                {
                    for (int j = 0; j < item.Hazak.GetLength(1); j++)
                    {
                        if (item.Hazak[i,j] !=0)
                        {
                            tarol += $"{i+1},{j+1},{item.Hazak[i,j]};"; 
                        }
                    }
                }
                tarol = tarol.Remove(tarol.Length - 1);
                connection.Open();
                command.CommandText = "UPDATE adatok SET hazak= @hazak WHERE nev=@nev;";
                command.Parameters.AddWithValue("@nev", item.Nev);
                command.Parameters.AddWithValue("@hazak",tarol);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                connection.Close();
            }
            return true;
        }
    }
}
