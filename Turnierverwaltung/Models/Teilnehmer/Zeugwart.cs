using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Zeugwart : Teilnehmer
    {
        #region Attribute
        private View view;
        #endregion

        #region Propertys
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Zeugwart() : base()
        {
            Vorname = "Max";
            Geburtstag = "1900-01-01";
            Beruf = "Zeugwart";
            View = new View();
        }

        public Zeugwart(string name, string nachname, string geburtstag, string beruf, string status) : base(name, nachname, geburtstag, beruf, status)
        {
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker
        public void OrganisiereZeug()
        {
            View.LeseTextEin($"{Vorname} räumt die Bälle weg.");
            View.GebeTextAus();
        }

       
        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(Vorname, Nachname, Geburtstag, 6, Status);
        }

        public override bool InDatenbankAendern(Datenbank db)
        {
            return db.AendereTeilnehmer(1, "Test", "Lauf");
        }

        public override bool InDatenbankLoeschen(Datenbank db)
        {
            return db.LoescheTeilnehmer(1);
        }
        #endregion
    }
}