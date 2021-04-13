using System.Collections.Generic;
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
        public List<Teilnehmer> AlleTeilnehmerAusgeben()
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
                    cmd.CommandText = $"SELECT * FROM participants";
                    List<Teilnehmer> tmp = new List<Teilnehmer>();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        switch(rdr[4])
                        {
                            case 1:
                                tmp.Add(new Fussballspieler(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Fußballspieler", rdr[5].ToString()));
                                break;
                            case 2:
                                tmp.Add(new Tennisspieler(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Tennisspieler", rdr[5].ToString()));
                                break;
                            case 3:
                                tmp.Add(new Handballspieler(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Handballspieler", rdr[5].ToString()));
                                break;
                            case 4:
                                tmp.Add(new Trainer(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Trainer", rdr[5].ToString()));
                                break;
                            case 5:
                                tmp.Add(new Physiologe(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Physiologe", rdr[5].ToString()));
                                break;
                            case 6:
                                tmp.Add(new Zeugwart(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Zeugwart", rdr[5].ToString()));
                                break;
                            default:
                                break;
                        }
                        System.Diagnostics.Debug.WriteLine(rdr[0].ToString() + ":" + rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString());
                    }
                    return tmp;
                }
                catch { }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return null;
            }
        }

        public bool FuegeTeilnehmerHinzu(string firstname, string lastname, string birthday, int job_id, string health_status)
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
                    cmd.CommandText = "INSERT INTO participants (firstname, lastname, birthday, job_id, health_status) VALUES (@firstname, @lastname, @birthday, @job, @health)";
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@birthday", birthday);
                    cmd.Parameters.AddWithValue("@job", job_id);
                    cmd.Parameters.AddWithValue("@health", health_status);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return true;
            }
        }

        public bool AendereTeilnehmer(int id, string name, string surname)
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
                    cmd.CommandText = $"UPDATE participant SET name = @name, surname = @surname WHERE id = {id};";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return true;
            }
        }

        public bool LoescheTeilnehmer(int id)
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
                    cmd.CommandText = $"DELETE FROM participant WHERE id = {id};";
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return true;
            }
        }

        public List<Mannschaft> AlleMannschaftenAusgeben()
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
                    cmd.CommandText = $"SELECT * FROM team";
                    List<Mannschaft> tmp = new List<Mannschaft>();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tmp.Add(new Mannschaft((string)rdr[1]));
                    }
                    rdr.Close();
                    return tmp;
                }
                catch { }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return null;
            }
        }

        public bool FuegeMannschaftHinzu(string name, string age)
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
                    cmd.CommandText = "INSERT INTO team (name, age) VALUES (@name, @age)";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return true;
            }
        }

        public bool AendereMannschaft(int id, string name, string age)
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
                    cmd.CommandText = $"UPDATE team SET name = @name, age = @age WHERE id = {id};";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return true;
            }
        }

        public bool LoescheMannschaft(int id)
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
                    cmd.CommandText = $"DELETE FROM team WHERE id = {id};";
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return true;
            }
        }
        #endregion

    }
}
