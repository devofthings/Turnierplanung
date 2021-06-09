/* Datei: Controller.cs
 * Was passiert hier?: Kontrolliert den Anwendungsfluss und stellt dem Nutzer funktionen zur Verfügung
 * Author: Christopher Winter
 * Klasse: IA119
 */

using System.Collections.Generic;

namespace Turnierplanung
{
    public class Controller
    {
        #region Attribute
        private List<Teilnehmer> _teilnehmer;
        private List<Mannschaft> _mannschaften;
        private List<Teilnehmer> _tournament;
        private Datenbank _db;
        #endregion

        #region Propertys
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        public List<Mannschaft> Mannschaften { get => _mannschaften; set => _mannschaften = value; }
        public Datenbank DB { get => _db; set => _db = value; }
        public List<Teilnehmer> Tournament { get => _tournament; set => _tournament = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Teilnehmer = new List<Teilnehmer>();
            Mannschaften = new List<Mannschaft>();
            Tournament = new List<Teilnehmer>();
            DB = new Datenbank("127.0.0.1", "tournament", "jobs_read", "1234");
        }
        public Controller(List<Teilnehmer> teilnehmer, List<Mannschaft> mannschaften, string ip, string db, string user, string password)
        {
            Teilnehmer = teilnehmer;
            Mannschaften = mannschaften;
            Tournament = new List<Teilnehmer>();

            DB = new Datenbank(ip, db, user, password);
        }

        public Controller(List<Teilnehmer> teilnehmer, string ip, string db, string user, string password)
        {
            Teilnehmer = teilnehmer;
            Tournament = new List<Teilnehmer>();

            DB = new Datenbank(ip, db, user, password);
        }
        public Controller(List<Mannschaft> mannschaften, string ip, string db, string user, string password)
        {
            Mannschaften = mannschaften;
            Tournament = new List<Teilnehmer>();
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

        public bool TeilnehmerAendern(int id, Teilnehmer t)
        {
            return DB.AendereTeilnehmer(id, t.Vorname, t.Nachname, t.Geburtstag, t.GebeJobIdAus(t.Beruf), t.Status);
        }

        public bool TeilnehmerLoeschen(int id)
        {
            return DB.LoescheTeilnehmer(id);
        }

        public List<Mannschaft> AlleMannschaftenErhalten()
        {
            return DB.AlleMannschaftenAusgeben();
        }

        public bool MannschaftHinzufuegen(Mannschaft m)
        {
            return DB.FuegeMannschaftHinzu(m.Vorname);
        }

        public bool MannschaftAendern(int id, Mannschaft m)
        {
            return DB.AendereMannschaft(id, m.Vorname);
        }

        public bool MannschaftLoeschen(int id)
        {
            return DB.LoescheMannschaft(id);
        }

        public bool TeilnehmerZuMannschaftHinzufügen(int pID, int mID)
        {
            return DB.FuegeTeilnehmerZuMannschaftHinzu(pID, mID);
        }

        public bool TeilnehmerAusMannschaftEntfernen(int pID, int mID)
        {
            return DB.LoescheTeilnehmerAusMannschaft(pID, mID);
        }

        public List<Teilnehmer> TeilnehmerEinerMannschaftErhalten(int teamID)
        {
            return DB.AlleTeilnehmerEinerMannschaftAusgeben(teamID);
        }

        public void TurnierteilnehmerHinzufuegen(Teilnehmer t)
        {
            DB.FuegeTeilnehmerZuTurnierHinzu(t.ID);
        }
        public void TurnierteilnehmerEntfernen(int t)
        {
            DB.LoescheTeilnehmerAusTurnier(t);
        }
        public void TurniermannschaftHinzufuegen(Teilnehmer m)
        {
            DB.FuegeMannschaftZuTurnierHinzu(m.ID);
        }
        public void TurniermannschaftEntfernen(int m)
        {
            DB.LoescheMannschaftAusTurnier(m);
        }
        public List<Teilnehmer> TurnierbeteiligtenErhalten()
        {
            List<Teilnehmer> tmpT = new List<Teilnehmer>();
            tmpT = DB.AlleBeteiligtenTeilnehmerImTurnierErhalten();
            List<Teilnehmer> tmpM = new List<Teilnehmer>();
            tmpM = DB.AlleBeteiligtenTeamsImTurnierErhalten();
            tmpT.AddRange(tmpM);
            return tmpT;
        }
        #endregion
    }
}
