namespace Turnierplanung
{
    public class Tennisspieler : Spieler
    {
        #region Attribute
        private string _beruf;
        private View _view;
        #endregion

        #region Propertys
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => _view; set => _view = value; }
        #endregion

        #region Konstruktoren
        public Tennisspieler() : base()
        {
            Name = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
            Beruf = "Tennisspieler";
            View = new View();
        }

        public Tennisspieler(string name, string nachname, string alter, string status, string rueckennummer) : base(name, nachname, alter, status)
        {
            Name = name;
            Nachname = nachname;
            Alter = alter;
            Beruf = "Tennisspieler";
            View = new View();
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            View.LeseTextEin($"Der Spieler hat den Ball.");
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