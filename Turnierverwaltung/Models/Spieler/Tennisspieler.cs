/* Datei: Tennisspieler.cs
 * Was passiert hier?: Erlaubt das erstellen von Tennisspielern aus der abstrakten Klasse Spieler
 * Author: Christopher Winter
 * Klasse: IA119
 */

namespace Turnierplanung
{
    public class Tennisspieler : Spieler
    {
        #region Attribute
        private int _schlagStaerke;
        #endregion

        #region Propertys
        public int SchlagStaerke { get => _schlagStaerke; set => _schlagStaerke = value; }
        #endregion

        #region Konstruktoren
        public Tennisspieler() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Tennisspieler";
            Status = "Gesund";
            SchlagStaerke = 10;
        }

        public Tennisspieler(int id, string name, string nachname, string geburtstag, string beruf, string status, int staerke) : base(id, name, nachname, geburtstag, beruf, status)
        {
            ID = id;
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
            SchlagStaerke = staerke;
        }
        #endregion

        #region Worker

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(ID, Vorname, Nachname, Geburtstag, 2, Status);
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