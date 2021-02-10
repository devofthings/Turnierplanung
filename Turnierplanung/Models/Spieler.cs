using System;
namespace Turnierplanung
{
    public class Spieler :Teilnehmer
    {
        #region Attribute
        private string _name;
        private View _view;
        #endregion

        #region Propertys
        public string Name { get => _name; set => _name = value; }
        public View View { get => _view; set => _view = value; }
        #endregion

        #region Konstruktoren
        public Spieler() :base()
        {
            Name = "Max Mustermann";
        }

        public Spieler(string name) : base()
        {
            Name = name;
        }
        #endregion

        #region Worker
        public string sageName()
        {
            View.leseTextEin($"Hallo, mein Name ist {Name}.");
            return View.gebeTextAus();
        }
        #endregion
    }
}