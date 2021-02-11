using System;
namespace Turnierplanung
{
    public abstract class Spieler :Teilnehmer
    {
        #region Attribute
        private string _status; // Gesund oder Verletzt
        private View _view;
        #endregion

        #region Propertys
        public string Status { get => _status; set => _status = value; }
        public View View { get => _view; set => _view = value; }
        #endregion

        #region Konstruktoren
        public Spieler() :base()
        {
            Status = "Gesund";
        }

        public Spieler(string name, int alter, string beruf, string status) : base()
        {
            Name = name;
            Alter = alter;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker
        public override abstract void StellDichVor();
        #endregion
    }
}