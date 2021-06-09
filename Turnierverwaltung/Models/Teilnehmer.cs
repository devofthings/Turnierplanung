/* Datei: Teilnehmer.cs
 * Was passiert hier?: Stellt dem Programm die Abstrkate Klasse Teilnehemr zur verfügung
 * Author: Christopher Winter
 * Klasse: IA119
 */

namespace Turnierplanung
{
    public abstract class Teilnehmer
    {
        #region Attribute
        private int _id;
        private string _vorname;
        private string _nachname;
        private string _alter;
        private string _beruf;
        private string _status;
        private string _punkte;
        #endregion

        #region Propertys
        public int ID { get => _id; set => _id = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        public string Nachname { get => _nachname; set => _nachname = value; }
        public string Geburtstag { get => _alter; set => _alter = value; }
        public string Beruf { get => _beruf; set => _beruf = value; }
        public string Status { get => _status; set => _status = value; }
        public string Name { get; }
        public string Punkte { get => _punkte; set => _punkte = value; }
        #endregion

        #region Konstruktoren
        public Teilnehmer()
        {
            ID = 0;
            Vorname = "Max";
            Nachname = "Mustermann";
            Geburtstag = "1900-01-01";
            Beruf = "Fußballspieler";
        }
        public Teilnehmer(int id, string vorname, string nachname, string geburtstag, string beruf, string status)
        {
            ID = id;
            Vorname = vorname;
            Nachname = nachname;
            Geburtstag = geburtstag;
            Beruf = beruf;
            Status = status;
        }

        // Mannschaftskonstruktor
        public Teilnehmer(int id, string name)
        {
            ID = id;
            Vorname = name;
        }

        public Teilnehmer(string name)
        {
            Name = name;
        }
        #endregion

        #region Worker

        public abstract bool InDatenbankSpeichern(Datenbank db);
        public abstract bool InDatenbankAendern(Datenbank db);
        public abstract bool InDatenbankLoeschen(Datenbank db);
        public int GebeJobIdAus(string job)
        {
            switch (job)
            {
                case "Fußballspieler":
                    return 1;
                case "Tennisspieler":
                    return 2;
                case "Handballspieler":
                    return 3;
                case "Trainer":
                    return 4;
                case "Physiologe":
                    return 5;
                case "Zeugwart":
                    return 6;
                default:
                    return 0;
            }
        }
        #endregion
    }
}