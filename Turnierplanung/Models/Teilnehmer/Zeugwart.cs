using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Zeugwart : Teilnehmer
    {
        #region Attribute
        private string _beruf;
        private View view;
        #endregion

        #region Propertys
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Zeugwart() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Zeugwart";
            View = new View();
        }

        public Zeugwart(string name, int alter) : base(name, alter)
        {
            Name = name;
            Alter = alter;
            Beruf = "Zeugwart";
            View = new View();
        }
        #endregion

        #region Worker
        public void OrganisiereZeug()
        {
            View.LeseTextEin($"{Name} räumt die Bälle weg.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Ich bin Zeugwart und mein Name ist {Name}.");
            View.GebeTextAus();
        }

        public override void InDatenbankSpeichern(Datenbank DB)
        {
            DB.FuehreQueryAus("SELECT * FROM participant");
        }
        #endregion
    }
}