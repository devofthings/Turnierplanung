namespace Turnierplanung
{
    public class Handballspieler : Spieler
    {
        #region Attribute
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Handballspieler() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Handballspieler";
        }

        public Handballspieler(string name, string nachname, string geburtstag, string beruf, string status) : base(name, nachname, geburtstag, beruf, status)
        {
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(Vorname, Nachname, Geburtstag, 3, Status);
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