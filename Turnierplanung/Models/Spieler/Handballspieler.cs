namespace Turnierplanung
{
    public class Handballspieler : Spieler
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
        public Handballspieler() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Handballspieler";
            Rueckennummer = "0";
            View = new View();
        }

        public Handballspieler(string name, int alter, string status, string rueckennummer) : base(name, alter, status)
        {
            Name = name;
            Alter = alter;
            Beruf = "Handballspieler";
            Rueckennummer = rueckennummer;
            View = new View();
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            View.leseTextEin($"Der Spieler mit der Rückennummer {Rueckennummer} hat den Ball.");
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