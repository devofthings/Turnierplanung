using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Datenbank
    {
        #region Attributes
        private string _ip;
        private string _db;
        private string _user;
        private string _password;
        private View _view;
        #endregion

        #region Propertys
        public string Server { get => _ip; set => _ip = value; }
        public string DB { get => _db; set => _db = value; }
        public string User { get => _user; set => _user = value; }
        public string Password { get => _password; set => _password = value; }
        public View View { get => _view; set => _view = value; }
        #endregion

        #region Constructors

        public Datenbank(string server, string db, string user, string password)
        {
            Server = server;
            DB = db;
            User = user;
            Password = password;
        }
        #endregion

        #region Worker
        
        public void FuehreQueryAus(string SQL)
        {
            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            MySqlConnection Connection= new MySqlConnection(DBConfig);
            try
            {
                Console.WriteLine("Verbinde zu Datenbank ..");
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand(SQL, Connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Connection.Close();
            Console.WriteLine("Query abgeschlossen.");
        }

        public void FuehreNonQueryAus(string SQL)
        {
            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            MySqlConnection Connection = new MySqlConnection(DBConfig);
            try
            {
                Console.WriteLine("Verbinde zu Datenbank ..");
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand(SQL, Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Connection.Close();
            Console.WriteLine("Query abgeschlossen.");
        }
        #endregion

    }
}
