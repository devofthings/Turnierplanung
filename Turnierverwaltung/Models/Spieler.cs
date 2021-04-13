using System;

namespace Turnierplanung
{
    public abstract class Spieler : Teilnehmer
    {
        #region Attribute
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Spieler()
        {
            Status = "Gesund";
        }

        public Spieler(string name,string nachname, string geburtstag, string beruf, string status) : base(name, nachname, geburtstag, beruf, status)
        {
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker
        
        #endregion

    }
}