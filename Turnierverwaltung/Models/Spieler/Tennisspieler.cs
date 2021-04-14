namespace Turnierplanung
{
    public class Tennisspieler : Spieler
    {
        #region Attribute
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Tennisspieler() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Tennisspieler";
        }

        public Tennisspieler(int id, string name, string nachname, string geburtstag, string beruf, string status) : base(id, name, nachname, geburtstag, beruf, status)
        {
            ID = id;
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
            return db.FuegeTeilnehmerHinzu(Vorname, Nachname, Geburtstag, 2, Status);
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