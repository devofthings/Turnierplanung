/* Datei: Physiologe.cs
 * Was passiert hier?: Erlaubt das erstellen von Physiologen
 * Author: Christopher Winter
 * Klasse: IA119
 */

namespace Turnierplanung
{
    public class Physiologe : Teilnehmer
    {
        #region Attribute
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Physiologe() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Physiologe";
        }

        public Physiologe(int id, string name, string nachname, string geburtstag, string beruf, string status) : base(id, name, nachname, geburtstag, beruf, status)
        {
            ID = id;
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }
        #endregion

        #region Worker

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(ID, Vorname, Nachname, Geburtstag, 5, Status);
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