
namespace Turnierplanung
{
    public class Physiologe : Teilnehmer
    {
        #region Attribute
        private string _beruf;
        private View view;
        #endregion

        #region Propertys
        public string Beruf { get => _beruf; set => _beruf = value; }
        public View View { get => view; set => view = value; }
        #endregion

        #region Konstruktoren
        public Physiologe() : base()
        {
            Name = "Max";
            Nachname = "Mustermann";
            Alter = "1900-01-01";
            Beruf = "Physiologe";
            View = new View();
        }

        public Physiologe(string name, string nachname, string alter) : base(name, nachname, alter)
        {
            Name = name;
            Nachname = nachname;
            Alter = alter;
            Beruf = "Physiologe";
            View = new View();
        }
        #endregion

        #region Worker
        public void BaueMannschaftAuf()
        {
            View.LeseTextEin($"{Name} versucht die Gesundheit der mannschaft zu verbessern.");
            View.GebeTextAus();
        }

        public override void StellDichVor()
        {
            View.LeseTextEin($"Ich bin Physiologe und mein Name ist {Name}.");
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