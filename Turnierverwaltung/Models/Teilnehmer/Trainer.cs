using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Trainer : Teilnehmer
    {
        #region Attribute
        private View view;
        #endregion

        #region Propertys
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Trainer() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Trainer";
            View = new View();
        }

        public Trainer(string name, string nachname, string geburtstag, string beruf, string status) : base(name, nachname, geburtstag, beruf, status)
        {
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker
        public void Trainiere()
        {
            View.LeseTextEin($"{Vorname} trainiert seine Mannschaft.");
            View.GebeTextAus();
        }

       

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(Vorname, Nachname, Geburtstag, 4, Status);
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