namespace Turnierplanung
{
    public class Tennisspieler : Spieler
    {
        #region Attribute
        private string _rueckennummer;
        private string _beruf;
        private View view;
        #endregion

        #region Propertys
        public string Rueckennummer { get => _rueckennummer; set => _rueckennummer = value; }
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Tennisspieler() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Tennisspieler";
            Rueckennummer = "0";
            View = new View();
        }

        public Tennisspieler(string name, int alter, string status) : base(name, alter, status)
        {
            Name = name;
            Alter = alter;
            Beruf = "Tennisspieler";
            View = new View();
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            View.leseTextEin($"{Name} hat den Ball.");
            View.gebeTextAus();
        }

        public override void StellDichVor()
        {
            View.leseTextEin($"Mein Name ist {Name} ich bin {Beruf}.");
            View.gebeTextAus();
        }

        public override void GebeGesundheitsStatusAus()
        {
            View.leseTextEin($"Aktuell bin ich {Status}.");
            View.gebeTextAus();
        }
        #endregion
    }
}