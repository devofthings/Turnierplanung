using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private string _rueckennummer;
        private string _beruf;
        private View view;
        #endregion

        #region Propertys
        public string Rueckennummer { get => _rueckennummer; set => _rueckennummer = value; }
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Fußballspieler";
            Rueckennummer = "0";
            View = new View();
        }

        public Fussballspieler(string name, int alter, string status, string rueckennummer) : base(name, alter, status)
        {
            Name = name;
            Alter = alter;
            Beruf = "Fußballspieler";
            Rueckennummer = rueckennummer;
            View = new View();
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            View.leseTextEin($"Der Spieler mit der Rückennummer {Rueckennummer} hat den Ball.");
            View.gebeTextAus();
        }

        public override void StellDichVor()
        {
            View.leseTextEin($"Mein Name ist {Name} ich bin {Beruf}.");
            View.gebeTextAus();
        }

        public override void GebeGesundheitsStatusAus()
        {
            View.leseTextEin($"Aktuell bin ich {Status}.");
            View.gebeTextAus();
        }

        public override void InDatenbankSpeichern()
        {
            MySqlConnection Connection = new MySqlConnection("Server=127.0.0.1;Database=tournament;User Id=root;Password=;");
            string SQLcommand = "select surname, name, job from paticipants" +
                "inner join jobs on participant.job_id = jobs.id";
        }
        #endregion
    }
}