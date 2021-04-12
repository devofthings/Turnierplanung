using System;

namespace Turnierplanung
{
    public abstract class Spieler : Teilnehmer
    {
        #region Attribute
        private string _status; // Gesund oder Verletzt
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Spieler()
        {
            Status = "Gesund";
        }

        public Spieler(string name,string nachname, string alter, string status) : base(name, nachname, alter, "Fußballspieler", status)
        {
            Vorname = name;
            Nachname = nachname;
            Alter = alter;
            Status = status;
        }
        #endregion

        #region Worker
        public abstract void GebeGesundheitsStatusAus();
        public override void StellDichVor()
        {
            Console.Write("Hallo");
        }
        #endregion

    }
}