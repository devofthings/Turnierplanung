
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

        
        }
        #endregion
    }
}
