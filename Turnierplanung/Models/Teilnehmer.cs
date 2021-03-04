namespace Turnierplanung
{
    public abstract class Teilnehmer
    {
        #region Attribute
        private string _vorname;
        private string _nachname;
        private string _alter;
        #endregion

        #region Propertys
        public string Name { get => _vorname; set => _vorname = value; }
        public string Nachname { get => _nachname; set => _nachname = value; }
        public string Alter { get => _alter; set => _alter = value; }

        #endregion

        #region Konstruktoren
        public Teilnehmer()
        {
            Name = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
        }
        public Teilnehmer(string name, string nachname, string alter)
        {
            Name = name;
            Nachname = nachname;
            Alter = alter;
        }

        // Mannschaftskonstruktor
        public Teilnehmer(string name, string alter)
        {
            Name = name;
            Alter = alter;
        }
        #endregion

        #region Worker
        public abstract void StellDichVor();

        public abstract bool InDatenbankSpeichern(Datenbank db);
        public abstract bool InDatenbankAendern(Datenbank db);
        public abstract bool InDatenbankLoeschen(Datenbank db)
        #endregion
    }
}