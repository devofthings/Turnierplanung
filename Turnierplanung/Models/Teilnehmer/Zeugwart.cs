namespace Turnierplanung
{
    public class Zeugwart : Teilnehmer
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
        public Zeugwart() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Zeugwart";
            View = new View();
        }

        public Zeugwart(string name, int alter) : base(name, alter)
        {
            Name = name;
            Alter = alter;
            Beruf = "Zeugwart";
            View = new View();
        }
        #endregion

        #region Worker
        public void OrganisiereZeug()
        {
            View.leseTextEin($"{Name} räumt die Bälle weg.");
            View.gebeTextAus();
        }

        public override void StellDichVor()
        {
            View.leseTextEin($"Ich bin Zeugwart und mein Name ist {Name}.");
            View.gebeTextAus();
        }
    }
    #endregion
}