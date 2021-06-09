/* Datei: Trainer.cs
 * Was passiert hier?: Erlaubt das erstellen von Trainern
 * Author: Christopher Winter
 * Klasse: IA119
 */

using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Trainer : Teilnehmer
    {
        #region Attribute
        private int _trainierteMannschaften;
        #endregion

        #region Propertys
        public int TrainierteMannschaften { get => _trainierteMannschaften; set => _trainierteMannschaften = value; }
        #endregion

        #region Konstruktoren
        public Trainer() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Trainer";
            Status = "Gesund";
            TrainierteMannschaften = 1;
        }

        public Trainer(int id, string name, string nachname, string geburtstag, string beruf, string status, int anzahlMannschaften) : base(id, name, nachname, geburtstag, beruf, status)
        {
            ID = id;
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
            TrainierteMannschaften = anzahlMannschaften;
        }
        #endregion

        #region Worker
        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(ID, Vorname, Nachname, Geburtstag, 4, Status);
        }

        public override bool InDatenbankAendern(Datenbank db)
        {
            return db.AendereTeilnehmer(ID, Vorname, Nachname, Geburtstag, GebeJobIdAus(Beruf), Status);
        }

        public override bool InDatenbankLoeschen(Datenbank db)
        {
            return db.LoescheTeilnehmer(1);
        }
        #endregion
    }
}