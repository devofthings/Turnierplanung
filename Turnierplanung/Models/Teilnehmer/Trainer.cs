namespace Turnierplanung
{
    public class Trainer : Teilnehmer
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
        public Trainer() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Trainer";
            View = new View();
        }

        public Trainer(string name, int alter) : base(name, alter)
        {
            Name = name;
            Alter = alter;
            Beruf = "Trainer";
            View = new View();
        }
        #endregion

        #region Worker
        public void Trainiere()
        {
            View.leseTextEin($"{Name} trainiert seine Mannschaft.");
            View.gebeTextAus();
        }

        public override void StellDichVor()
        {
            View.leseTextEin($"Ich bin Trainer und mein Name ist {Name}.");
            View.gebeTextAus();
        }
        #endregion
    }
}