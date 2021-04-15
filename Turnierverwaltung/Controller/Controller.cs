using System;
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
            DB = new Datenbank("127.0.0.1", "tournament", "root", "");
        }
        public Controller(List<Teilnehmer> teilnehmer, List<Mannschaft> mannschaften, string ip, string db, string user, string password)
        {
            Teilnehmer = teilnehmer;
            Mannschaften = mannschaften;
            DB = new Datenbank(ip, db, user, password);
        }

        public Controller(List<Teilnehmer> teilnehmer, string ip, string db, string user, string password)
        {
            Teilnehmer = teilnehmer;
            DB = new Datenbank(ip, db, user, password);
        }
        #endregion

        #region Worker
        public List<Teilnehmer> AlleTeilnehmerErhalten()
        {
            return DB.AlleTeilnehmerAusgeben();
        }

        public bool TeilnehmerHinzufuegen(Teilnehmer t)
        {
            switch (t.GebeJobIdAus(t.Beruf))
            {
                case 1:
                    Fussballspieler fussball = (Fussballspieler)t;
                    return DB.FuegeFussballspielerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status, fussball);
                case 2:
                    Tennisspieler tennis = (Tennisspieler)t;
                    return DB.FuegeTennisspielerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status, tennis);
                case 3:
                    Handballspieler handball = (Handballspieler)t;
                    return DB.FuegeHandballspielerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status, handball);
                case 4:
                    Trainer trainer = (Trainer)t;
                    return DB.FuegeTrainerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status, trainer);
                case 5:
                    return DB.FuegeTeilnehmerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status);
                case 6:
                    return DB.FuegeTeilnehmerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status);
                default:
                    return DB.FuegeTeilnehmerHinzu(t.ID, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status);
            }
        }

        // TODO: id erhalten
        public bool TeilnehmerAendern(int id, Teilnehmer t)
        {
            return DB.AendereTeilnehmer(id, t.Vorname, t.Nachname);
        }

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
            return DB.FuegeMannschaftHinzu(m.Vorname, m.Geburtstag);
        }

        // TODO: id erhalten
        public bool MannschaftAendern(int id, Mannschaft m)
        {
            return DB.AendereMannschaft(id, m.Vorname, m.Geburtstag);
        }

        // TODO: id erhalten
        public bool MannschaftLoeschen(int id)
        {
            return DB.LoescheMannschaft(id);
        }

        #endregion
    }
}
