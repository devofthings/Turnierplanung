
namespace Turnierplanung
{
    public class Physiologe : Teilnehmer
    {
        #region Attribute
        private View view;
        #endregion

        #region Propertys
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Physiologe() : base()
        {
            Vorname = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
            Beruf = "Physiologe";
            View = new View();
        }

        public Physiologe(string name, string nachname) : base()
        {
            Vorname = name;
            Nachname = nachname;
            Beruf = "Physiologe";
            View = new View();
        }
        #endregion

        #region Worker
        public void BaueMannschaftAuf()
        {
            View.LeseTextEin($"{Vorname} versucht die Gesundheit der mannschaft zu verbessern.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Ich bin Physiologe und mein Name ist {Vorname}.");
            View.GebeTextAus();
        }

        public override bool InDatenbankSpeichern(Datenbank db)
        {
            return db.FuegeTeilnehmerHinzu("Hans", "Schneider", "1990-01-01", 1);
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