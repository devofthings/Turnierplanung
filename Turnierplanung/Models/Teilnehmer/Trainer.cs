using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Trainer : Teilnehmer
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
        public Trainer() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Trainer";
            View = new View();
        }

        public Trainer(string name, int alter) : base(name, alter)
        {
            Name = name;
            Alter = alter;
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

        public override void InDatenbankSpeichern(Datenbank DB)
        {
            DB.GebeTeilnehmerAus();
        }
        #endregion
    }
}