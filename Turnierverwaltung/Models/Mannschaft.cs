using System.Collections.Generic;

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
            Vorname = "Borussia Dortmund";
            Alter = "1900-01-01";
            View = new View();
            Kader = new List<Spieler>();
        }

        // Mit bestehender Mannschaft
        public Mannschaft(string name, string alter, List<Spieler> kader) : base(name)
        {
            Vorname = name;
            View = new View();
            Kader = kader;
        }

        // Neue Mannschaft
        public Mannschaft(string name) : base()
        {
            Vorname = name;
            View = new View();
            Kader = new List<Spieler>();
        }
        #endregion

        #region Worker
        private Spieler FindeSpieler(string name)
        {
            int index = Kader.FindIndex(spieler => spieler.Vorname == name);
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
            View.LeseTextEin($"Wir sind die Mannschaft: '{Vorname}'!");
            View.GebeTextAus();
        }

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeMannschaftHinzu("Die Gelben Nasen", "1990-01-01");
        }

        public override bool InDatenbankAendern(Datenbank db)
        {
            return db.AendereMannschaft(1, "Test", "1900-01-01");
        }

        public override bool InDatenbankLoeschen(Datenbank db)
        {
            return db.LoescheMannschaft(1);
        }
        #endregion
    }
}