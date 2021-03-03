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

        #region Props
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
        
        public void GebeTeilnehmerAus()
        {
            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            // using --> ruft automatisch .Dispose() auf sobald, der Block verlassen wird. 
            using (MySqlConnection connection = new MySqlConnection(DBConfig))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT participant.id, name, surname, FLOOR (DATEDIFF(CURRENT_DATE, age) /365) AS age, job FROM participant INNER JOIN jobs ON participant.job_id = jobs.id ORDER BY participant.id ASC";
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine($"{rdr[0]}. Name: {rdr[1]} {rdr[2]} - Alter: {rdr[3]} Job: {rdr[4]}");
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                connection.Close();
            }
        }

        public void FuegeTeilnehmerHinzu(string name, string surname, string age, int job_id)
        {
            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            // using --> ruft automatisch .Dispose() auf sobald, der Block verlassen wird. 
            using (MySqlConnection connection = new MySqlConnection(DBConfig))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO participant (name, surname, age, job_id) VALUES (@name, @surname, @age, @job_id)";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@job_id", job_id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
            }
        }
        #endregion

    }
}
