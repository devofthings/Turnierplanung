using System;
namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private int _rueckennummer;
        #endregion

        #region Propertys
        public int Rueckennummer { get => _rueckennummer; set => _rueckennummer = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Fußballspieler";
            Rueckennummer = 0;
        }

        public Fussballspieler(string name, int alter, int rueckennummer) : base()
        {
            Beruf = "Fußballspieler";
            Alter = alter;
            Rueckennummer = rueckennummer;
        }
        #endregion

        #region Worker
        public override void StellDichVor()
        {
            View.leseTextEin($"Ich bin Spieler, mein Name ist {Name} ich bin {Beruf}. Aktuell bin ich {Status}.");
            View.gebeTextAus();
        }
        public void spielDenBall()
        {
            View.leseTextEin($"Der Spieler mit der Rückennummer {Rueckennummer} hat den Ball.");
            View.gebeTextAus();
        }
    }
}