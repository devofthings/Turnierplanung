/* Datei: Zeugwart.cs
 * Was passiert hier?: Erlaubt das erstellen von Zeugwärten
 * Author: Christopher Winter
 * Klasse: IA119
 */

using System;
using MySql.Data.MySqlClient;

namespace Turnierplanung
{
    public class Zeugwart : Teilnehmer
    {
        #region Attribute
        private View view;
        #endregion

        #region Propertys
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Zeugwart() : base()
        {
            Vorname = "Max";
            Geburtstag = "1900-01-01";
            Beruf = "Zeugwart";
            View = new View();
        }

        public Zeugwart(int id, string name, string nachname, string geburtstag, string beruf, string status) : base(id, name, nachname, geburtstag, beruf, status)
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
        public void OrganisiereZeug()
        {
            View.LeseTextEin($"{Vorname} räumt die Bälle weg.");
            View.GebeTextAus();
        }

       
        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu(ID, Vorname, Nachname, Geburtstag, 6, Status);
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