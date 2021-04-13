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
            Alter = "1900-01-01";
            Beruf = "Tennisspieler";
        }

        public Tennisspieler(string name, string nachname, string alter, string beruf, string status) : base(name, nachname, alter, beruf, status)
        {
            Vorname = name;
            Nachname = nachname;
            Alter = alter;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker

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