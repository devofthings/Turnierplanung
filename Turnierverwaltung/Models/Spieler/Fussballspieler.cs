namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private string _rueckennummer;
        private View _view;
        #endregion

        #region Propertys
        public string Rueckennummer { get => _rueckennummer; set => _rueckennummer = value; }
        public View View { get => _view; set => _view = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            Name = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
            Beruf = "Fußballspieler";
            Rueckennummer = "0";
            View = new View();
        }

        public Fussballspieler(string name, string nachname, string alter, string status, string rueckennummer) : base(name, nachname, alter, status)
        {
            Name = name;
            Nachname = nachname;
            Alter = alter;
            Beruf = "Fußballspieler";
            Rueckennummer = rueckennummer;
            View = new View();
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            View.LeseTextEin($"Der Spieler mit der Rückennummer {Rueckennummer} hat den Ball.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Mein Name ist {Name} ich bin {Beruf}.");
            View.GebeTextAus();
        }

        public override void GebeGesundheitsStatusAus()
        {
            View.LeseTextEin($"Aktuell bin ich {Status}.");
            View.GebeTextAus();
        }

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu("Hans", "Schneider", "1990-01-01", 1);
        }

        public override bool InDatenbankAendern(Datenbank db)
        {
            return db.AendereTeilnehmer(1, "Test", "Lauf");
        }

        public override bool InDatenbankLoeschen(Datenbank db)
        {
            return db.LoescheTeilnehmer(1);
        }
        #endregion
    }
}