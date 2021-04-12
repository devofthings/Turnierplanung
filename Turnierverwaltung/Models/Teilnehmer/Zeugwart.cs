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
            Alter = "1900-01-01";
            Beruf = "Zeugwart";
            View = new View();
        }

        public Zeugwart(string name, string nachname) : base()
        {
            Vorname = name;
            Nachname = nachname;
            Beruf = "Zeugwart";
            View = new View();
        }
        #endregion

        #region Worker
        public void OrganisiereZeug()
        {
            View.LeseTextEin($"{Vorname} räumt die Bälle weg.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Ich bin Zeugwart und mein Name ist {Vorname}.");
            View.GebeTextAus();
        }

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu("Hans", "Schneider", "1990-01-01", 1);
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