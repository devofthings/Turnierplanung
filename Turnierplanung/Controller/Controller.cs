using System.Collections.Generic;

namespace Turnierplanung
{
    public class Controller
    {
        #region Attribute
        private List<Teilnehmer> _teilnehmer;
        private List<Mannschaft> _mannschaften;
        private Datenbank _db;
        #endregion

        #region Propertys
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        public List<Mannschaft> Mannschaften { get => _mannschaften; set => _mannschaften = value; }
        public Datenbank DB { get => _db; set => _db = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Teilnehmer = new List<Teilnehmer>();
            Mannschaften = new List<Mannschaft>();
            DB = new Datenbank("192.168.64.2", "tournament", "root", "");
        }
        public Controller(List<Teilnehmer> teilnehmer, List<Mannschaft> mannschaften, string ip, string db, string user, string password)
        {
            Teilnehmer = teilnehmer;
            Mannschaften = mannschaften;
            DB = new Datenbank(ip, db, user, password);
        }

        #endregion
        #region Worker
        public List<Teilnehmer> AlleTeilnehmerErhalten()
        {
            return DB.AlleTeilnehmerAusgeben();
        }

        public bool TeilnehmerHinzufügen(Teilnehmer t)
        {
            return DB.FuegeTeilnehmerHinzu(t.Name, t.Nachname, t.Alter, t.GebeJobIdAus(t.Beruf));
        }

        // TODO: id erhalten
        public bool TeilnehmerAendern(int id, Teilnehmer t)
        {
            return DB.AendereTeilnehmer(id, t.Name, t.Nachname);
        }

        // TODO: id erhalten
        public bool TeilnehmerLoeschen(int id)
        {
            return DB.LoescheTeilnehmer(id);
        }

        public List<Mannschaft> AlleMannschaftenErhalten()
        {
            return DB.AlleMannschaftenAusgeben();
        }

        public bool MannschaftHinzufügen(Mannschaft m)
        {
            return DB.FuegeMannschaftHinzu(m.Name, m.Alter);
        }

        // TODO: id erhalten
        public bool MannschaftAendern(int id, Mannschaft m)
        {
            return DB.AendereMannschaft(id, m.Name, m.Alter);
        }

        // TODO: id erhalten
        public bool MannschaftLoeschen(int id)
        {
            return DB.LoescheMannschaft(id);
        }

        #endregion
    }
}
