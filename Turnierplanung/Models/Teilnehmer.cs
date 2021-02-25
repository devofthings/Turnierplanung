namespace Turnierplanung
{
    public abstract class Teilnehmer
    {
        #region Attribute
        private string _name;
        private int _alter;
        #endregion

        #region Propertys
        public string Name { get => _name; set => _name = value; }
        public int Alter { get => _alter; set => _alter = value; }

        #endregion

        #region Konstruktoren
        public Teilnehmer()
        {
            Name = "Max Mustermann";
            Alter = 0;
        }
        public Teilnehmer(string name, int alter)
        {
            Name = name;
            Alter = alter;
        }
        #endregion

        #region Worker
        public abstract void StellDichVor();

        public abstract void InDatenbankSpeichern();
        #endregion
    }
}