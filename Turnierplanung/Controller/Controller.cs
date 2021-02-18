
using System;
using System.Collections.Generic;


namespace Turnierplanung
{
    public class Controller
    {
        #region Attribute
        private List<Teilnehmer> _teilnehmer;
        #endregion

        #region Propertys
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Teilnehmer = new List<Teilnehmer>();
        }
        public Controller(List<Teilnehmer> t)
        {
            Teilnehmer = t;
        }

        #endregion
        #region Worker
        public void Run()
        {
            Teilnehmer.Add(new Fussballspieler("Marco Reus", 30, "Gesund", "11"));
            Teilnehmer.Add(new Handballspieler());
            Teilnehmer.Add(new Tennisspieler("Klaus Kawinsky", 54, "Verletzt"));
            Teilnehmer.Add(new Physiologe("Der Doc", 62));
            Teilnehmer.Add(new Trainer("Jürgen Klopp", 45));
            Teilnehmer.Add(new Zeugwart("Hans Schneider", 67));
            Teilnehmer.Add(new Mannschaft("AWE Kickers 2020", 1));

            foreach(Teilnehmer t in Teilnehmer)
            {
                t.StellDichVor();
            }
            Console.ReadKey();
        }
        #endregion
    }
}
