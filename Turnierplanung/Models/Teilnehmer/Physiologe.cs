namespace Turnierplanung
{
    public class Physiologe : Teilnehmer
    {
        #region Attribute
        private string _beruf;
        private View view;
        #endregion

        #region Propertys
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Physiologe() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Physiologe";
            View = new View();
        }

        public Physiologe(string name, int alter) : base(name, alter)
        {
            Name = name;
            Alter = alter;
            Beruf = "Physiologe";
            View = new View();
        }
        #endregion

        #region Worker
        public void BaueMannschaftAuf()
        {
            View.leseTextEin($"{Name} versucht die Gesundheit der mannschaft zu verbessern.");
            View.gebeTextAus();
        }

        public override void StellDichVor()
        {
            View.leseTextEin($"Ich bin Physiologe und mein Name ist {Name}.");
            View.gebeTextAus();
        }
        #endregion
    }
}