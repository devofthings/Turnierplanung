/* Datei: Spieler.cs
 * Was passiert hier?: Leitet abstrakte Klasse Spieler von Teilnehmer ab
 * Author: Christopher Winter
 * Klasse: IA119
 */

namespace Turnierplanung
{
    public abstract class Spieler : Teilnehmer
    {
        #region Attribute
        #endregion

        #region Propertys
        #endregion

        #region Konstruktoren
        public Spieler()
        {
            Status = "Gesund";
        }

        public Spieler(int id, string name,string nachname, string geburtstag, string beruf, string status) : base(id, name, nachname, geburtstag, beruf, status)
        {
            ID = id;
            Vorname = name;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }

        public Spieler(int id, string name, string nachname, string geburtstag, string beruf, string status, int tore) : this(id, name, nachname, geburtstag, beruf, status)
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

        #endregion

    }
}