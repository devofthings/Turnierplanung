/* Datei: Datenbank.cs
 * Was passiert hier?: Stellt alle Datenbankfunktionen zur verfügung
 * Author: Christopher Winter
 * Klasse: IA119
 */

using System;
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
                                // TODO TORE PER INNER JOIN ERHALTEN
                                tmp.Add(new Fussballspieler(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Fußballspieler", rdr[5].ToString(), 1));
                                break;
                            case 2:
                                // TODO Stärke PER INNER JOIN ERHALTEN
                                tmp.Add(new Tennisspieler(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Tennisspieler", rdr[5].ToString(), 1));
                                break;
                            case 3:
                                // TODO Arm PER INNER JOIN ERHALTEN
                                tmp.Add(new Handballspieler(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Handballspieler", rdr[5].ToString(), "Links"));
                                break;
                            case 4:
                                // TODO Anzahl PER INNER JOIN ERHALTEN
                                tmp.Add(new Trainer(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Trainer", rdr[5].ToString(), 1));
                                break;
                            case 5:
                                tmp.Add(new Physiologe(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Physiologe", rdr[5].ToString()));
                                break;
                            case 6:
                                tmp.Add(new Zeugwart(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Zeugwart", rdr[5].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                    return tmp;
                }
                catch { }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return null;
            }
        }

        public bool FuegeTeilnehmerHinzu(int id, string firstname, string lastname, string birthday, int job_id, string health_status)
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
                    cmd.CommandText = "INSERT INTO participants (id, firstname, lastname, birthday, job_id, health_status) VALUES (@id, @firstname, @lastname, @birthday, @job, @health)";
                    cmd.Parameters.AddWithValue("@id", id);
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

        public bool AendereTeilnehmer(int id, string firstname, string lastname, string birthday, int job_id, string health_status)
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
                    cmd.CommandText = $"UPDATE participants SET firstname = @firstname, lastname = @lastname, birthday = @birthday, job_id = @job, health_status = @health WHERE id = {id};";
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
                    cmd.CommandText = $"DELETE FROM participants WHERE id = {id};";
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
                    cmd.CommandText = $"SELECT * FROM teams";
                    List<Mannschaft> tmp = new List<Mannschaft>();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tmp.Add(new Mannschaft(Convert.ToInt32(rdr[0]), (string)rdr[1]));
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

        public bool FuegeMannschaftHinzu(string name)
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
                    cmd.CommandText = "INSERT INTO teams (name) VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", name);
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

        public bool AendereMannschaft(int id, string name)
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
                    cmd.CommandText = $"UPDATE teams SET name = @name WHERE id = {id};";
                    cmd.Parameters.AddWithValue("@name", name);
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
                    cmd.CommandText = $"DELETE FROM teams WHERE id = {id};";
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

        public List<Teilnehmer> AlleTeilnehmerEinerMannschaftAusgeben(int mannschaftsID)
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
                    cmd.CommandText = $"SELECT * FROM `participants` AS p INNER JOIN participants_teams pt ON pt.participant_id = p.id INNER JOIN teams t ON pt.team_id = t.id WHERE t.id = {mannschaftsID}";
                    List<Teilnehmer> tmp = new List<Teilnehmer>();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        switch (rdr[4])
                        {
                            case 1:
                                // TODO TORE PER INNER JOIN ERHALTEN
                                tmp.Add(new Fussballspieler(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Fußballspieler", rdr[5].ToString(), 1));
                                break;
                            case 2:
                                // TODO Stärke PER INNER JOIN ERHALTEN
                                tmp.Add(new Tennisspieler(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Tennisspieler", rdr[5].ToString(), 1));
                                break;
                            case 3:
                                // TODO Arm PER INNER JOIN ERHALTEN
                                tmp.Add(new Handballspieler(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Handballspieler", rdr[5].ToString(), "Links"));
                                break;
                            case 4:
                                // TODO Anzahl PER INNER JOIN ERHALTEN
                                tmp.Add(new Trainer(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Trainer", rdr[5].ToString(), 1));
                                break;
                            case 5:
                                tmp.Add(new Physiologe(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Physiologe", rdr[5].ToString()));
                                break;
                            case 6:
                                tmp.Add(new Zeugwart(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), "Zeugwart", rdr[5].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                    return tmp;
                }
                catch { }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return null;
            }
        }

        public bool FuegeTeilnehmerZuMannschaftHinzu(int teilnehmerID, int mannschaftsID)
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
                    cmd.CommandText = "INSERT INTO participants_teams (participant_id, team_id) VALUES (@pID, @mID)";
                    cmd.Parameters.AddWithValue("@pID", teilnehmerID);
                    cmd.Parameters.AddWithValue("@mID", mannschaftsID);
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

        public bool LoescheTeilnehmerAusMannschaft(int teilnehmerID, int mannschaftsID)
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
                    cmd.CommandText = $"DELETE FROM participants_teams WHERE participant_id = {teilnehmerID} AND team_id = {mannschaftsID}";
                    cmd.Parameters.AddWithValue("@pID", teilnehmerID);
                    cmd.Parameters.AddWithValue("@mID", mannschaftsID);
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

        public bool FuegeFussballspielerHinzu(int id, string firstname, string lastname, string birthday, int job_id, string health_status, Fussballspieler f)
        {
            FuegeTeilnehmerHinzu(id, firstname, lastname, birthday, job_id, health_status);

            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            // using --> ruft automatisch .Dispose() auf sobald, der Block verlassen wird. 
            using (MySqlConnection connection = new MySqlConnection(DBConfig))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO participants_properties (participant_id, property_id, property_value) VALUES (@participant_id, @property_id, @property_value)";
                    cmd.Parameters.AddWithValue("@participant_id", id);
                    cmd.Parameters.AddWithValue("@property_id", 5);
                    cmd.Parameters.AddWithValue("@property_value", f.GeschosseneTore);
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
        public bool FuegeTennisspielerHinzu(int id, string firstname, string lastname, string birthday, int job_id, string health_status, Tennisspieler t)
        {
            FuegeTeilnehmerHinzu(id, firstname, lastname, birthday, job_id, health_status);

            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            // using --> ruft automatisch .Dispose() auf sobald, der Block verlassen wird. 
            using (MySqlConnection connection = new MySqlConnection(DBConfig))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO participants_properties (participant_id, property_id, property_value) VALUES (@participant_id, @property_id, @property_value)";
                    cmd.Parameters.AddWithValue("@participant_id", id);
                    cmd.Parameters.AddWithValue("@property_id", 6);
                    cmd.Parameters.AddWithValue("@property_value", t.SchlagStaerke);
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
        public bool FuegeHandballspielerHinzu(int id, string firstname, string lastname, string birthday, int job_id, string health_status, Handballspieler h)
        {
            FuegeTeilnehmerHinzu(id, firstname, lastname, birthday, job_id, health_status);

            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            // using --> ruft automatisch .Dispose() auf sobald, der Block verlassen wird. 
            using (MySqlConnection connection = new MySqlConnection(DBConfig))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO participants_properties (participant_id, property_id, property_value) VALUES (@participant_id, @property_id, @property_value)";
                    cmd.Parameters.AddWithValue("@participant_id", id);
                    cmd.Parameters.AddWithValue("@property_id", 7);
                    cmd.Parameters.AddWithValue("@property_value", h.StarkerArm);
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
        public bool FuegeTrainerHinzu(int id, string firstname, string lastname, string birthday, int job_id, string health_status, Trainer t)
        {
            FuegeTeilnehmerHinzu(id, firstname, lastname, birthday, job_id, health_status);

            string DBConfig = $"server={Server};user={User};database={DB};password={Password}";
            // using --> ruft automatisch .Dispose() auf sobald, der Block verlassen wird. 
            using (MySqlConnection connection = new MySqlConnection(DBConfig))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO participants_properties (participant_id, property_id, property_value) VALUES (@participant_id, @property_id, @property_value)";
                    cmd.Parameters.AddWithValue("@participant_id", id);
                    cmd.Parameters.AddWithValue("@property_id", 8);
                    cmd.Parameters.AddWithValue("@property_value", t.TrainierteMannschaften);
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

        public bool FuegeTeilnehmerZuTurnierHinzu(int teilnehmerID)
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
                    cmd.CommandText = "INSERT INTO tournament_participants (participant_id) VALUES (@pID)";
                    cmd.Parameters.AddWithValue("@pID", teilnehmerID);
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

        public bool FuegeMannschaftZuTurnierHinzu(int mannschaftsID)
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
                    cmd.CommandText = "INSERT INTO tournament_participants (team_id) VALUES (@mID)";
                    cmd.Parameters.AddWithValue("@mID", mannschaftsID);
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

        public bool LoescheTeilnehmerAusTurnier(int teilnehmerID)
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
                    cmd.CommandText = $"DELETE FROM tournament_participants WHERE participant_id = {teilnehmerID}";
                    cmd.Parameters.AddWithValue("@pID", teilnehmerID);
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
        public bool LoescheMannschaftAusTurnier(int mannschaftsID)
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
                    cmd.CommandText = $"DELETE FROM tournament_participants WHERE team_id = {mannschaftsID}";
                    cmd.Parameters.AddWithValue("@mID", mannschaftsID);
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

        public List<Teilnehmer> AlleBeteiligtenTeamsImTurnierErhalten()
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
                    cmd.CommandText = $"SELECT * FROM `teams` AS t INNER JOIN tournament_participants AS tpt ON tpt.team_id = t.id";
                    List<Teilnehmer> tmp = new List<Teilnehmer>();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tmp.Add(new Fussballspieler(Convert.ToInt32(rdr[4]), rdr[1].ToString()));
                    }
                    return tmp;
                }
                catch { }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return null;
            }
        }

        public List<Teilnehmer> AlleBeteiligtenTeilnehmerImTurnierErhalten()
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
                    cmd.CommandText = $"SELECT* FROM `participants` AS p INNER JOIN tournament_participants AS tpt ON tpt.participant_id = p.id";
                    List<Teilnehmer> tmp = new List<Teilnehmer>();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tmp.Add(new Fussballspieler(Convert.ToInt32(rdr[7]), rdr[2].ToString()));
                    }
                    return tmp;
                }
                catch { }

                connection.Close();
                // connection.Dispose(); "Räum auf Befehl" für die Klasse - Nachdem es nicht mehr genutzt werden soll
                return null;
            }
        }
        #endregion

    }
}
