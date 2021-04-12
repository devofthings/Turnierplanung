namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
            Beruf = "Fußballspieler";
        }

        public Fussballspieler(string name, string nachname, string alter, string status) : base(name, nachname, alter, status)
        {
            Vorname = name;
            Nachname = nachname;
            Alter = alter;
            Beruf = "Fußballspieler";
            Status = Status;
        }
        #endregion

        #region Worker
        public override void GebeGesundheitsStatusAus()
        {
            throw new System.NotImplementedException();
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