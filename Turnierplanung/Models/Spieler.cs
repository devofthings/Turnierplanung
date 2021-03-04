namespace Turnierplanung
{
    public abstract class Spieler : Teilnehmer
    {
        #region Attribute
        private string _status; // Gesund oder Verletzt
        #endregion

        #region Propertys
        public string Status { get => _status; set => _status = value; }
        #endregion

        #region Konstruktoren
        public Spieler()
        {
            Status = "Gesund";
        }

        public Spieler(string name,string nachname, string alter, string status) : base(name, nachname, alter)
        {
            Name = name;
            Nachname = nachname;
            Alter = alter;
            Status = status;
        }
        #endregion

        #region Worker
        public abstract void GebeGesundheitsStatusAus();
        #endregion
    }
}