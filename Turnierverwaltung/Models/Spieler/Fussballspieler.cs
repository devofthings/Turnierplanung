using System.Collections.Generic;
using System.Linq;

namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private int _geschosseneTore;

        #endregion

        #region Propertys
        public int GeschosseneTore { get => _geschosseneTore; set => _geschosseneTore = value; }

        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {
            ID = 0;
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Fußballspieler";
            Status = "Gesund";
            GeschosseneTore = 0;
        }

        public Fussballspieler(int id, string name, string nachname, string geburtstag, string beruf, string status, int tore) : base(id, name, nachname, geburtstag, beruf, status, tore)
        {
            ID = id;
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
            GeschosseneTore = tore;
        }
        #endregion

        #region Worker
        
        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(ID, Vorname, Nachname, Geburtstag, 1, Status);
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