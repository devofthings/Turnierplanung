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
            Name = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
            Beruf = "Trainer";
            View = new View();
        }

        public Trainer(string name, string nachname) : base(name, nachname)
        {
            Name = name;
            Nachname = nachname;
            Beruf = "Trainer";
            View = new View();
        }
        #endregion

        #region Worker
        public void Trainiere()
        {
            View.LeseTextEin($"{Name} trainiert seine Mannschaft.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Ich bin Trainer und mein Name ist {Name}.");
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