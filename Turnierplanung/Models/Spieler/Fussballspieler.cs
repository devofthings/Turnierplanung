using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private string _rueckennummer;
        private string _beruf;
        private View _view;
        #endregion

        #region Propertys
        public string Rueckennummer { get => _rueckennummer; set => _rueckennummer = value; }
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => _view; set => _view = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Fußballspieler";
            Rueckennummer = "0";
            View = new View();
        }

        public Fussballspieler(string name, int alter, string status, string rueckennummer) : base(name, alter, status)
        {
            Name = name;
            Alter = alter;
            Beruf = "Fußballspieler";
            Rueckennummer = rueckennummer;
            View = new View();
        }
        #endregion

        #region Worker
        public void spielDenBall()
        {
            View.LeseTextEin($"Der Spieler mit der Rückennummer {Rueckennummer} hat den Ball.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Mein Name ist {Name} ich bin {Beruf}.");
            View.GebeTextAus();
        }

        public override void GebeGesundheitsStatusAus()
        {
            View.LeseTextEin($"Aktuell bin ich {Status}.");
            View.GebeTextAus();
        }

        public override void InDatenbankSpeichern(Datenbank DB)
        {
            DB.FuehreQueryAus("SELECT * FROM participant");
            DB.FuehreNonQueryAus($"INSERT INTO participant (name, surname, job_id) VALUES ('Marco', 'Reus', 1)");
            DB.FuehreQueryAus("SELECT * FROM participant");
        }
        #endregion
    }
}