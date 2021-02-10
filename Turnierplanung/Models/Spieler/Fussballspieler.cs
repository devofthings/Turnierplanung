using System;
namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private string _beruf;
        private int _rueckennummer;
        #endregion

        #region Propertys
        public string Beruf { get => _beruf; set => _beruf = value; }
        public int Rueckennummer { get => _rueckennummer; set => _rueckennummer = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            Beruf = "Fußballspieler";
            Rueckennummer = 0;
        }

        public Fussballspieler(int rueckennummer) : base()
        {
            Beruf = "Fußballspieler";
            Rueckennummer = rueckennummer;
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            /* Spieler.View.leseTextEin("Der Spieler mit der Rückennummer {} hat den Ball.");
            Spieler.View.gebeTextAus(); */
        }
        #endregion
    }
}