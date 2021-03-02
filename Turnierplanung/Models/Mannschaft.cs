using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Mannschaft : Teilnehmer
    {
        #region Attribute
        private View _view;
        private List<Spieler> _kader;
        #endregion

        #region Propertys
        public View View { get => _view; set => _view = value; }
        public List<Spieler> Kader { get => _kader; set => _kader = value; }
        #endregion

        #region Konstruktoren
        // Ohne Mannschaft
        public Mannschaft()
        {
            Name = "Borussia Dortmund";
            Alter = 0;
            View = new View();
            Kader = new List<Spieler>();
        }

        // Mit bestehender Mannschaft
        public Mannschaft(string name, int alter, List<Spieler> kader) : base(name, alter)
        {
            Name = name;
            Alter = alter;
            View = new View();
            Kader = kader;

        }

        // Neue Mannschaft
        public Mannschaft(string name, int alter) : base(name, alter)
        {
            Name = name;
            Alter = alter;
            View = new View();
            Kader = new List<Spieler>();
        }
        #endregion

        #region Worker
        private Spieler FindeSpieler(string name)
        {
            int index = Kader.FindIndex(spieler => spieler.Name == name);
            return Kader[index];
        }
        public void FuegeSpielerZuMannschaftHinzu(Spieler spieler)
        {
            Kader.Add(spieler);
        }

        public Spieler EntlasseSpielerAusMannschaft(string name)
        {
            Spieler tmp = FindeSpieler(name);
            Kader.Remove(FindeSpieler(name));
            return tmp;
        }
        public void GebeGroesseDesKadersAus()
        {
            View.LeseTextEin($"Wir haben {Kader.Count} Spieler in unserer Mannschaft.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Wir sind die Mannschaft: '{Name}'!");
            View.GebeTextAus();
        }

        public override void InDatenbankSpeichern(Datenbank DB)
        {
            DB.FuehreQueryAus("SELECT * FROM participant");
        }
        #endregion
    }
}