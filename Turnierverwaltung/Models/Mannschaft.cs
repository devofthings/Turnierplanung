/* Datei: Mannschaft.cs
 * Was passiert hier?: Erlaubt das Erstellen von Mannschaften
 * Author: Christopher Winter
 * Klasse: IA119
 */

using System.Collections.Generic;

namespace Turnierplanung
{
    public class Mannschaft : Teilnehmer
    {
        #region Attribute
        private List<Spieler> _kader;
        #endregion

        #region Propertys
        public List<Spieler> Kader { get => _kader; set => _kader = value; }
        #endregion

        #region Konstruktoren
        // Ohne Mannschaft
        public Mannschaft()
        {
            Vorname = "Borussia Dortmund";
            Geburtstag = "1900-01-01";
            Kader = new List<Spieler>();
        }

        // Mit bestehender Mannschaft
        public Mannschaft(int id, string name, List<Spieler> kader) : base(id, name)
        {
            ID = id;
            Vorname = name;
            Kader = kader;
        }

        // Neue Mannschaft
        public Mannschaft(int id, string name) : base()
        {
            ID = id;
            Vorname = name;
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
           
        }


        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeMannschaftHinzu("Die Gelben Nasen");
        }

        public override bool InDatenbankAendern(Datenbank db)
        {
            return db.AendereMannschaft(1, "Test");
        }

        public override bool InDatenbankLoeschen(Datenbank db)
        {
            return db.LoescheMannschaft(1);
        }
        #endregion
    }
}