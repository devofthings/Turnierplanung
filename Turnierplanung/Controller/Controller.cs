
using System;
using System.Collections.Generic;


namespace Turnierplanung
{
    public class Controller
    {
        #region Attribute
        private List<Teilnehmer> _teilnehmer;
        private Mannschaft _m1;
        private Mannschaft _m2;
        #endregion

        #region Propertys
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        public Mannschaft M1 { get => _m1; set => _m1 = value; }
        public Mannschaft M2 { get => _m2; set => _m2 = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Teilnehmer = new List<Teilnehmer>();
            M1 = new Mannschaft("AWE Kickers 2020", 1);
            M2 = new Mannschaft();
        }
        public Controller(List<Teilnehmer> t)
        {
            Teilnehmer = t;
            M1 = new Mannschaft("AWE Kickers 2020", 1);
            M2 = new Mannschaft();
        }
        public Controller(List<Teilnehmer> t, string mannschaft1, string mannschaft2)
        {
            Teilnehmer = t;
            M1 = new Mannschaft(mannschaft1, 1);
            M2 = new Mannschaft(mannschaft2, 1);
        }

        #endregion
        #region Worker
        public void Run()
        {
            #region Teilnehmer Anlegen
            Teilnehmer.Add(new Fussballspieler("Marco Reus", 30, "Gesund", "11"));
            Teilnehmer.Add(new Fussballspieler("Spieler2", 16, "Gesund", "10"));
            Teilnehmer.Add(new Fussballspieler("Spieler3", 18, "Verletzt", "09"));
            Teilnehmer.Add(new Fussballspieler("Spieler4", 20, "Gesund", "01"));
            Teilnehmer.Add(new Handballspieler());
            Teilnehmer.Add(new Tennisspieler("Klaus Kawinsky", 54, "Verletzt"));

            Teilnehmer.Add(new Physiologe("Der Doc", 62));
            Teilnehmer.Add(new Trainer("Jürgen Klopp", 45));
            Teilnehmer.Add(new Zeugwart("Hans Schneider", 67));

            Teilnehmer.Add(M1);
            Teilnehmer.Add(M2);
            #endregion

            foreach (Teilnehmer t in Teilnehmer)
            {
                t.StellDichVor();
            }

            #region Mannschafts Aktionen
            M1.FuegeSpielerZuMannschaftHinzu((Spieler)Teilnehmer[0]);
            M1.FuegeSpielerZuMannschaftHinzu((Spieler)Teilnehmer[1]);
            M2.FuegeSpielerZuMannschaftHinzu((Spieler)Teilnehmer[2]);
            M2.FuegeSpielerZuMannschaftHinzu((Spieler)Teilnehmer[3]);

            M1.GebeGroesseDesKadersAus();
            M2.GebeGroesseDesKadersAus();

            Spieler entlassen = M1.EntlasseSpielerAusMannschaft(Teilnehmer[0].Name);
            M1.GebeGroesseDesKadersAus();
            entlassen.StellDichVor();
            #endregion

            Console.ReadKey();
        }
        #endregion
    }
}
