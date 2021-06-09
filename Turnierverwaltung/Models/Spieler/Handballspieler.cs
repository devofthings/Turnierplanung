/* Datei: Handballspieler.cs
 * Was passiert hier?: Erlaubt das erstellen von Handballspielern aus der abstrakten Klasse Spieler
 * Author: Christopher Winter
 * Klasse: IA119
 */

namespace Turnierplanung
{
    public class Handballspieler : Spieler
    {
        #region Attribute
        private string _starkerArm;

        #endregion

        #region Propertys
        public string StarkerArm { get => _starkerArm; set => _starkerArm = value; }

        #endregion

        #region Konstruktoren
        public Handballspieler() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Handballspieler";
            Status = "Gesund";
            StarkerArm = "Links";
        }

        public Handballspieler(int id, string name, string nachname, string geburtstag, string beruf, string status, string arm) : base(id, name, nachname, geburtstag, beruf, status)
        {
            ID = id;
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
            StarkerArm = arm;
        }
        #endregion

        #region Worker

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(ID, Vorname, Nachname, Geburtstag, 3, Status);
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